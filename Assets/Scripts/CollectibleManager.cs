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
    private int countOrbs = 0;
    private GameObject currentOrb;
    private Dictionary<int, GameObject> orbs;

    //Red Letters
    private GameObject currentLetter;
    private Dictionary<int, GameObject> letters;
    private int collectedCount = 0;

    private void Start()
    {
        //orbs
        orbs = new Dictionary<int, GameObject>();
        orbs = collectables.CreateRedOrbsDictionary();
        //letters
        letters = new Dictionary<int, GameObject>();
        letters = collectables.CreateRedLettersDictionary();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Orb"))
        {
            currentOrb = collision.gameObject;
            for (int i = 0; i < orbs.Count; i++)
            {
                if (orbs[i] == currentOrb)
                {
                    Destroy(currentOrb);
                    Orb orb = orbs[i].gameObject.GetComponent<Orb>();
                    
                    if (!orb.GetIsCollected())
                    {
                        countOrbs++;
                        orb.SetIsCollected(true);
                        orb.PlayAudio();
                    }


                    TMPro.text = countOrbs + " / 4";


                    // debuging
                    Debug.Log(orbs[i].gameObject.name);
                    Debug.Log("Count -> " + countOrbs);
                    Debug.Log("Current Orb: Key = " + i + " , Value = " + orbs[i] + "isCollected: " + orb.GetIsCollected());
                }
            }

        }
        else if (collision.tag.Contains("Letter"))
        {
            currentLetter = collision.gameObject;
            for (int i = 0; i < letters.Count; i++)
            {
                if (letters[i] == currentLetter)
                {
                    Destroy(currentLetter);
                    Letter letter = letters[i].gameObject.GetComponent<Letter>();
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
                    Debug.Log("Current Letter: Key = " + i + " , Value = " + letters[i] + "isCollected: " + letter.GetIsCollected());
                }
            }
            if(collectedCount == letters.Count)
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
