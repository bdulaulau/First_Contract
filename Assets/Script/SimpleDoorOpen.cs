using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDoorOpen : MonoBehaviour
{
    public float openOffset = 4f;
    public float speed = 2f;
    public bool isOpen = false;

    void Update()
    {
        if (isOpen)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, openOffset, transform.position.z), speed * Time.deltaTime);
        }
    }

    public void Open()
    {
        isOpen = true;
        Debug.Log("Door opened!");
    }
}
