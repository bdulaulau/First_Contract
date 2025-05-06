using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseInventory : MonoBehaviour
{
    public bool InvStatue = false;
    public bool Left = false;
    public bool Right = false;
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

    private void OnClose()
    {
        InvStatue = false;
    }

    private void OnLeft()
    {
        if(Left == false)
        {
            Left = true;
        }
        else
        {
            Left = false;
        }
    }
    private void OnRight()
    {
        if (Right == false)
        {
            Right = true;
        }
        else
        {
            Right = false;
        }
    }
}
