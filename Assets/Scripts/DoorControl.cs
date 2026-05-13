using UnityEngine;

public class DoorControl : MonoBehaviour
{
    [SerializeField] private GameObject trigger;
    [SerializeField] private MeshRenderer doorRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LockDoor();
    }

    public void UnlockDoor()
    {
        trigger.SetActive(true);
        doorRenderer.material.color = Color.green;

    }

    public void LockDoor()
    {
        trigger.SetActive(false);
        doorRenderer.material.color = Color.red;

    }
}
