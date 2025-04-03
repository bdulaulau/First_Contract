using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    private bool interactPressed;

    private void OnInteraction()
    {
        interactPressed = true;
    }

    public bool CanInteract()
    {
        return interactPressed;
    }


    private void LateUpdate()
    {
        // Reset après chaque frame pour éviter les interactions continues
        interactPressed = false;
    }

}
