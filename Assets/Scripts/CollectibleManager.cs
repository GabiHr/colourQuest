using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    [SerializeField] private Collectables collectables;

    //Red Orbs
    private int countRedOrbs;
    private GameObject currentOrb;
    private Dictionary<int, GameObject> redOrbs;

    //Red Letters
    private GameObject currentLetter;
    private Dictionary<int, GameObject> redLetters;

    private void Start()
    {
        //orbs
        redOrbs = new Dictionary<int, GameObject>();
        redOrbs = collectables.CreateRedOrbsDictionary();
        //letters
        redLetters = new Dictionary<int, GameObject>();
        redLetters = collectables.CreateRedLettersDictionary();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Orb"))
        {
            currentOrb = collision.gameObject;
            for (int i = 0; i < redOrbs.Count; i++)
            {
                if (redOrbs[i] == currentOrb)
                {
                    Destroy(currentOrb);
                    Orb orb = redOrbs[i].gameObject.GetComponent<Orb>();
                    orb.SetIsCollected(true);
                    // debuging
                    Debug.Log(currentOrb.gameObject.name);
                    Debug.Log("Count -> " + countRedOrbs);
                    Debug.Log("Current Orb: Key = " + i + " , Value = " + redOrbs[i] + "isCollected: " + orb.GetIsCollected());
                    countRedOrbs++;
                }
            }

        }
        else if (collision.tag.Contains("Letter"))
        {
            currentLetter = collision.gameObject;
            for (int i = 0; i < redLetters.Count; i++)
            {
                if (redLetters[i] == currentLetter)
                {
                    Destroy(currentLetter);
                    Letter letter = redLetters[i].gameObject.GetComponent<Letter>();
                    letter.SetIsCollected(true);
                    // debuging
                    Debug.Log(currentLetter.gameObject.name);
                    Debug.Log("Current Letter: Key = " + i + " , Value = " + redLetters[i] + "isCollected: " + letter.GetIsCollected());
                }
            }

        }
    }

}
