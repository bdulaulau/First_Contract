using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public InputActionAsset inputAsset; // On récupère les inputs dans actions maps
    public float speed = 1.0f;
    public float sprintspeed = 4.0f;

    private float _axis;
    private bool _usesecondary = false;
    

    private void OnEnable() //OnEnable quand l'entité est activé, on s'abonne aux boutons avec +=
    {
        inputAsset.FindAction("Player/Jump").started += HandleJump; //On récupère l'action de jump

        inputAsset.FindAction("Player/Interaction").started += HandleInteraction; // On récupère l'action de l'intéraction

        inputAsset.FindAction("Player/Shoot").started += HandleShoot;

        inputAsset.FindAction("Player/Interaction").started += HandleInteraction;

        inputAsset.FindAction("Player/Move").performed += HandleMove;
        inputAsset.FindAction("Player/Move").canceled += HandleMove;

        inputAsset.FindAction("Player/Secondary").started += HandleSecondary;
        inputAsset.FindAction("Player/Secondary").canceled += HandleSecondary;

        inputAsset.FindAction("Player/Rechargement").started += HandleRechargement;

        inputAsset.FindAction("Player/Weapon").started += HandleWeapon;
        inputAsset.FindAction("Player/Inventory").started += HandleInventory;

        inputAsset.FindAction("Player/Left").started += HandleLeft;
        inputAsset.FindAction("Player/Right").started += HandleRight;

        inputAsset.FindAction("Player/Close").started += HandleClose;

        inputAsset.Enable();
    }

    private void OnDisable() //OnDisable quand l'obj est désactivé, on fait -= pour se désabonner aux boutons
    {
        inputAsset.FindAction("Player/Interaction").started -= HandleInteraction; 

        inputAsset.FindAction("Player/Shoot").started -= HandleShoot;

        inputAsset.FindAction("Player/Interaction").started -= HandleInteraction;

        inputAsset.FindAction("Player/Move").performed -= HandleMove;
        inputAsset.FindAction("Player/Move").canceled -= HandleMove;

        inputAsset.FindAction("Player/Secondary").started -= HandleSecondary;
        inputAsset.FindAction("Player/Secondary").canceled -= HandleSecondary;

        inputAsset.FindAction("Player/Rechargement").started -= HandleRechargement;

        inputAsset.FindAction("Player/Weapon").started -= HandleWeapon;
        inputAsset.FindAction("Player/Inventory").started -= HandleInventory;

        inputAsset.FindAction("Player/Left").started -= HandleLeft;
        inputAsset.FindAction("Player/Right").started -= HandleRight;

        inputAsset.FindAction("Player/Close").started -= HandleClose;

        inputAsset.Disable();
    }

    private void Update()
    {
        if (_usesecondary)
        {
            transform.position += Vector3.right * _axis * sprintspeed * Time.deltaTime; //le * deltatime pour ne pas être dépendant du frame rate 
        }
        else
        {
            transform.position += Vector3.right * _axis * speed * Time.deltaTime;
        }
    }

    private void HandleJump(InputAction.CallbackContext ctx) //ctx pour context
    {
        // Debug.Log($"JUMP: Phase = {ctx.phase}"); //$ Permet d'inserer des variables dans le texte
    }
    
    
    private void HandleShoot(InputAction.CallbackContext ctx) //ctx pour context
    {
        // Debug.Log($"SHOOT: Phase = {ctx.phase}"); //$ Permet d'inserer des variables dans le texte
    }
    private void HandleInteraction(InputAction.CallbackContext ctx)
    {
        // Debug.Log($"Interaction : Phase = {ctx.phase}");
    }
    private void HandleMove(InputAction.CallbackContext ctx) //ctx pour context
    {
        _axis = ctx.ReadValue<float>();
        // Debug.Log($"MOVE: Phase = {ctx.phase}, Axis = {_axis}"); //$ Permet d'inserer des variables dans le texte
    }

    private void HandleSecondary(InputAction.CallbackContext ctx)
    {
        _usesecondary = !ctx.canceled; //! permet de savoir si ça était start = true, si c'est cancel = false
    }

    private void HandleRechargement(InputAction.CallbackContext ctx)
    {
        // Debug.Log($"Interaction : Rechargement = {ctx.phase}");
    }

    private void HandleWeapon(InputAction.CallbackContext ctx)
    {
        // Debug.Log($"Interaction : Weapon = {ctx.phase}");
    }

    private void HandleInventory(InputAction.CallbackContext ctx)
    {
        //Debug.Log($"Interaction : Inventory = {ctx.phase}");
    }

    private void HandleLeft(InputAction.CallbackContext ctx)
    {

    }

    private void HandleRight(InputAction.CallbackContext ctx)
    {

    }

    private void HandleClose(InputAction.CallbackContext ctx)
    {
    }

}
