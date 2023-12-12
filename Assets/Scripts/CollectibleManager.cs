using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleManager : MonoBehaviour
{
    [SerializeField] private Collectables collectables;
    [SerializeField] private TextMeshProUGUI TMPro;
    [SerializeField] private Image[] images;
    [SerializeField] private GameObject word;
    [SerializeField] private PlayerMovement character;

    //Red Orbs
    private int countRedOrbs = 0;
    private GameObject currentOrb;
    private Dictionary<int, GameObject> redOrbs;

    //Red Letters
    private GameObject currentLetter;
    private Dictionary<int, GameObject> redLetters;
    private int collectedCount = 0;

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
                    
                    if (!orb.GetIsCollected())
                    {
                        countRedOrbs++;
                        orb.SetIsCollected(true);
                        orb.PlayAudio();
                    }


                    TMPro.text = countRedOrbs + " / 4";


                    // debuging
                    Debug.Log(redOrbs[i].gameObject.name);
                    Debug.Log("Count -> " + countRedOrbs);
                    Debug.Log("Current Orb: Key = " + i + " , Value = " + redOrbs[i] + "isCollected: " + orb.GetIsCollected());
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
                    
                    foreach (Image img in images)
                    {
                        if(img.name.Contains(letter.GetPosition().ToString()))
                        {
                            img.enabled = true;
                        }
                    }

                    if (!letter.GetIsCounted())
                    {
                        collectedCount++;
                        letter.SetIsCounted(true);
                        letter.PlayAudio();
                    }

                    // debuging
                    Debug.Log("Counterrrr: " + collectedCount);
                    Debug.Log(currentLetter.gameObject.name);
                    Debug.Log("Current Letter: Key = " + i + " , Value = " + redLetters[i] + "isCollected: " + letter.GetIsCollected());
                }
            }
            if(collectedCount == redLetters.Count)
            {
                StartCoroutine(CheckWord());
            }

        }
    }


    public IEnumerator CheckWord()
    {
        
        word.SetActive(true);
        yield return new WaitForSeconds(5);
        word.SetActive(false);
    }

}
