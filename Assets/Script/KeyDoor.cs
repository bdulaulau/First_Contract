using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private float openOffset = 2f;
    [SerializeField] private float speed = 2f;

    private Vector3 closedPos;
    private Vector3 openPos;
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
            transform.position = Vector3.MoveTowards(transform.position, openPos, speed * Time.deltaTime);
        }
    }

    // public void Open()
    // {
    //     if (objectInteraction.OpenTheDoor == true)
    //     {
    //         Debug.Log("✅ Porte: méthode Open() appelée !");
    //         isOpen = true;
    // }
}
