using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanic : MonoBehaviour
{

    [SerializeField] private Door door;

    private void OnEnable()// unity apelle cette méthode quand l'objet devient actif
    {
        DigitalDisplay.OnCodeCorrect += HandleCorrectCode; //on abonne la méthode HandleCorrectCode à l'event OnCodeCorrect.
    }

    private void OnDisable()
    {
        DigitalDisplay.OnCodeCorrect -= HandleCorrectCode; //on se désabonne quand l'objet est désactivé pour éviter les bugs
    }

    private void HandleCorrectCode()
    {
        door.OpenDoor(); //la fonction est appelée automatiquement par l'event quand le code est correct
    }
}
