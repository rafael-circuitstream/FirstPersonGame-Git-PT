using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;

    private void OnTriggerEnter(Collider other)
    {
        ForceDoorOpen();

    }

    private void OnTriggerExit(Collider other)
    {
        ForceDoorClose();
        
    }

    public void ForceDoorOpen()
    {
        doorAnimator.SetBool("IsOpen", true);

    }

    public void ForceDoorClose()
    {
        doorAnimator.SetBool("IsOpen", false);
    }


}
