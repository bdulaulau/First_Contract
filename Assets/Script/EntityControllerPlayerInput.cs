using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class EntityControllerPlayerInput : MonoBehaviour
{
    private float _axis;

    [Tooltip("Définit la vitesse de déplacement")]
    public float speed = 3.0f;


    public Rigidbody2D rb;
    // public Animator animator;
    public bool isFacingRight = true; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // animator = GetComponent<Animator>();
    }
    private void Update()
    {
        transform.position += Vector3.right * _axis * speed * Time.deltaTime;
        if ((_axis > 0 && !isFacingRight) || (_axis < 0 && isFacingRight)) //détecter si le personnage change de direction, et donc, s'il faut le retourner avec la méthode Flip()
        {
            Flip();
        }
    }

    public void Flip() //
    {
        isFacingRight = !isFacingRight; //on vérifie si il est face à droite ou non
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z); //inverse l'axe X du personnage en multipliant localScale.x par -1
    }
    private void OnJump()
    {
        Debug.Log("JUMP");
    }

    // void FixedUpdate()
    // {
    //     animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
    // }
    private void OnMove(InputValue value)
    {
        _axis = value.Get<float>();
        // animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
            // animator.SetTrigger("Marche");

    }
}
