using UnityEngine;

public class DoorMechanic : MonoBehaviour
{
    [SerializeField] private Door door;
    [SerializeField] private DigitalDisplay display;
    [SerializeField] private KeypadManager associatedKeypad;

    //private void OnEnable()
    //{
    //    if (display != null)
    //        display.OnCodeCorrect += HandleCorrectCode;
    //}

    //private void OnDisable()
    //{
    //    if (display != null)
    //        display.OnCodeCorrect -= HandleCorrectCode;
    //}

    //private void HandleCorrectCode(KeypadManager triggeringKeypad)
    //{
    //    Debug.Log($"{gameObject.name} received signal from {triggeringKeypad.name} (expected: {associatedKeypad.name})");
    //    if (triggeringKeypad == associatedKeypad)
    //    {
    //        door.OpenDoor();
    //    }
    //}
}
