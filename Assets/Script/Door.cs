using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float openOffset = 2f;
    [SerializeField] private float speed = 2f;

    private Vector3 closedPos;
    private Vector3 openPos;
    private bool isOpen = false;

    void Start()
    {
        closedPos = transform.position;
        openPos = closedPos + Vector3.up * openOffset;
    }

    void Update()
    {
        Vector3 target = isOpen ? openPos : closedPos;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public void OpenDoor()
    {
        isOpen = true;
    }

    public void CloseDoor()
    {
        isOpen = false;
    }

}
