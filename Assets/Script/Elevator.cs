using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform player; // Référence au joueur
    public Transform elevatorswitch; // Référence au bouton ou interrupteur de l’ascenseur
    public Transform downpos; // Position basse de l’ascenseur
    public Transform upperpos; // Position haute de l’ascenseur

    public float speed; // Vitesse de déplacement de l’ascenseur
    bool iselevatordown; // État de l’ascenseur : vrai s’il est en bas, faux s’il est en haut

    void Update()
    {
        StartElevator();
    }

    void StartElevator() // Gere l'entrée du joueur et le déplacement
    {
        if(Vector2.Distance(player.position, elevatorswitch.position)<1f && Input.GetKeyDown("e")) // Si le joueur est proche du bouton (< 1 unité) et qu’il appuie sur la touche E
        {
            if(transform.position.y <= downpos.position.y) // Si l’ascenseur est en bas, on prépare le mouvement vers le haut
            {
                iselevatordown = true; // On monte
            }
            else if (transform.position.y >= upperpos.position.y) // Si l’ascenseur est en haut, on prépare le mouvement vers le bas
            {
                iselevatordown = false; // On descend
            
            }
        }
        
        if(iselevatordown) // Si on doit monter
        {
            transform.position = Vector2.MoveTowards(transform.position,upperpos.position,speed * Time.deltaTime); // On monte vers le haut
        }
        else // Sinon on descend
        {
            transform.position = Vector2.MoveTowards(transform.position,downpos.position,speed * Time.deltaTime); // On descend vers le bas
        }
    }

     void OnTriggerEnter2D(Collider2D other)
    {
     if (other.CompareTag("Player"))
     {
         other.transform.parent = transform; // Le joueur devient enfant de l'ascenseur
     }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null; // Le joueur n’est plus enfant de l’ascenseur
     }
    }

}
