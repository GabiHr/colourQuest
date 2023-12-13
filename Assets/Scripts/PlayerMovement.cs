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
    float invulnerabilityTime = 0;

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


        if (invulnerabilityTime > 0)
        {
            invulnerabilityTime -= Time.deltaTime;
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
        if (collision.gameObject.tag.Contains("obstacle") && invulnerabilityTime <= 0)
        {
            counter++;
            character.transform.position = startPosition.transform.position;
            TMPro.text = counter.ToString();
            invulnerabilityTime = 0.5f;
        }
    }


}
