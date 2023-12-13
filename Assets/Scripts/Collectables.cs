using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Collectables : MonoBehaviour
{

    //red orbs
    [SerializeField] private GameObject[] orbsList;
    Dictionary<int,GameObject> orbs = new Dictionary<int,GameObject>();

    //red letters
    [SerializeField] private GameObject[] lettersList;
    Dictionary<int, GameObject> letters = new Dictionary<int, GameObject>();


    public Dictionary<int, GameObject> CreateRedOrbsDictionary()
    {
        int id = 0;
        foreach (GameObject orb in orbsList)
        {
            orbs.Add(id,orb);
            id++;
        }
        return orbs;
    }

    public Dictionary<int, GameObject> CreateRedLettersDictionary()
    {
        int id = 0;
        foreach (GameObject letter in lettersList)
        {
            letters.Add(id, letter);
            id++;
        }
        return letters;
    }


}
