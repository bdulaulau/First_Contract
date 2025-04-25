using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Transform playerSpawn;

    void Awake()
    {
        // Utilise la version singulière pour obtenir un seul GameObject
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Déplace le spawn au checkpoint actuel
            playerSpawn.position = transform.position;
        }
    }
}
