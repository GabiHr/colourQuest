using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public GameObject character;

    
    
    //movement
    float horizontalMove = 0f;
    float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    //death
    [SerializeField] public GameObject startPosition;
    private int counter = 0;
    [SerializeField] private TextMeshProUGUI TMPro;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);

        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);

    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove*Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("obstacle"))
        {
            character.transform.position = startPosition.transform.position;
            counter++;
            Debug.Log("Deaths: " + counter);
            TMPro.text = counter.ToString();
        }
    }


}
