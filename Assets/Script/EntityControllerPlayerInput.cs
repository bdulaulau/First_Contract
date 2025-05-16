using UnityEngine;
using UnityEngine.InputSystem;

public class EntityControllerPlayerInput : MonoBehaviour
{
    private float _axis;

    [Tooltip("Définit la vitesse de déplacement")]
    public float speed = 3.0f;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Déplacement
        transform.position += Vector3.right * _axis * speed * Time.deltaTime;

        // Gestion du flip sprite
        if ((_axis > 0 && !isFacingRight) || (_axis < 0 && isFacingRight))
        {
            Flip();
        }

        // Animation : activer marche si la vitesse absolue est > 0.3
        float pseudoSpeed = Mathf.Abs(_axis * speed);
        animator.SetBool("isWalking", pseudoSpeed > 0.3f);
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void OnJump()
    {
        Debug.Log("JUMP");
    }
    private void OnMove(InputValue value)
    {
        _axis = value.Get<float>();
    }
}
