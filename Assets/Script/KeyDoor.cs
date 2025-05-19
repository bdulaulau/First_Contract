using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private float openOffset = 2f;
    [SerializeField] private float speed = 2f;

    private Vector3 closedPos;
    private Vector3 openPos;
    public Animator animator;
    public bool isOpen = false;
    public ObjectInteraction objectInteraction;

    private void Start()
    {
        closedPos = transform.position;
        openPos = closedPos + Vector3.up * openOffset;
    }

    private void Update()
    {
        if (objectInteraction.OpenTheDoor == true)
        {
            if (animator.enabled)
            {
                animator.enabled = false;
            }
            transform.position = Vector3.MoveTowards(transform.position, openPos, speed * Time.deltaTime);
        }
    }

}
