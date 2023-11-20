using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Collectables : MonoBehaviour
{

    //red orbs
    [SerializeField] private GameObject[] orbsR;
    Dictionary<int,GameObject> redOrbs = new Dictionary<int,GameObject>();

    //red letters
    [SerializeField] private GameObject[] lettersR;
    Dictionary<int, GameObject> redLetters = new Dictionary<int, GameObject>();


    public Dictionary<int, GameObject> CreateRedOrbsDictionary()
    {
        int id = 0;
        foreach (GameObject orb in orbsR)
        {
            redOrbs.Add(id,orb);
            id++;
        }
        return redOrbs;
    }

    public Dictionary<int, GameObject> CreateRedLettersDictionary()
    {
        int id = 0;
        foreach (GameObject letter in lettersR)
        {
            redLetters.Add(id, letter);
            id++;
        }
        return redLetters;
    }


}
