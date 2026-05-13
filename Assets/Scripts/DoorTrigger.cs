using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;

    private void OnTriggerEnter(Collider other)
    {
        doorAnimator.SetBool("IsOpen", true);
    }

    private void OnTriggerExit(Collider other)
    {
        doorAnimator.SetBool("IsOpen", false);
    }


}
