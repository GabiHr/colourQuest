using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    [SerializeField] private int position;

    private bool isCollected = false;
    private bool isCounted = false;
    private int id;

    public void SetIsCollected(bool isCollected)
    {
        this.isCollected = isCollected;
    }

    public void SetIsCounted(bool isCounted) 
    {  
        this.isCounted = isCounted;
    }

    public bool GetIsCounted()
    {
        return this.isCounted;
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
