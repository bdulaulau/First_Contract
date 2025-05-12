using UnityEngine;
using Cinemachine;

public class CameraSwitchInteraction : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera playerCamera;
    [SerializeField] private CinemachineVirtualCamera staticCamera;
    [SerializeField] private KeyCode interactionKey = KeyCode.E;
    [SerializeField] private KeyCode exitKey = KeyCode.Escape;

    private bool isInView = false;

    private void OnTriggerStay(Collider other)
    {
        if (!isInView && other.CompareTag("Player") && Input.GetKeyDown(interactionKey))
        {
            EnterCameraView();
        }
    }

    private void Update()
    {
        if (isInView && Input.GetKeyDown(exitKey))
        {
            ExitCameraView();
        }
    }

    private void EnterCameraView()
    {
        isInView = true;
        playerCamera.Priority = 0;
        staticCamera.Priority = 10;
    }

    private void ExitCameraView()
    {
        isInView = false;
        staticCamera.Priority = 0;
        playerCamera.Priority = 10;
    }
}
