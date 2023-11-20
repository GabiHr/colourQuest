using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    [SerializeField] private int position;

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
    public int GetPosition()
    {
        return position;
    }


}
