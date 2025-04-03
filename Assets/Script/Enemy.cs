using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int pv = 100;

    public void TakeDamage(int damage)
    {
        pv -= damage;
        if (pv <= 0)
        {
            Destroy(gameObject);
        } 
    }

}
