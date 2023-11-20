using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Collectables : MonoBehaviour
{
    //id -> put keys in the dictionary
    private int idO = 0;
    private int idL = 0;


    //red orbs
    [SerializeField] private GameObject[] orbsR;
    Dictionary<int,GameObject> redOrbs = new Dictionary<int,GameObject>();

    //red letters
    [SerializeField] private GameObject[] lettersR;
    Dictionary<int, GameObject> redLetters = new Dictionary<int, GameObject>();


    public Dictionary<int, GameObject> CreateRedOrbsDictionary()
    {
        foreach (GameObject orb in orbsR)
        {
            redOrbs.Add(idO,orb);
            idO++;
        }
        return redOrbs;
    }

    public Dictionary<int, GameObject> CreateRedLettersDictionary()
    {
        foreach (GameObject letter in lettersR)
        {
            redLetters.Add(idL, letter);
            idL++;
        }
        return redLetters;
    }


}
