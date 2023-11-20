using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    private bool isCollected = false;
    private int id;



    public void SetIsCollected(bool isCollected)
    {
        this.isCollected = isCollected;
    }

    public bool GetIsCollected()
    {
        return isCollected;
    }
}


