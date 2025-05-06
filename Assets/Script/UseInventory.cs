using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseInventory : MonoBehaviour
{
    public bool InvStatue = false; 
    private void OnInventory()
    {
        if (InvStatue == false)
        {
            InvStatue = true;
        }
        else
        {
            InvStatue = false;
        }
    }
}
