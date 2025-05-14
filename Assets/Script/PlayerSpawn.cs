using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class PlayerSpawn : MonoBehaviour
{

    private void Awake()
    {
        // Déplacement du joueur au point de spawn
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = transform.position;
        }
    }
}