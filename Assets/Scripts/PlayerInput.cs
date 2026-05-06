using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector3 movementDirection;
    [SerializeField] private float moveSpeed;

    public Vector3 lookRotation;
    [SerializeField] private float lookSpeed;

    private CharacterController characterController;
    private Camera characterHead;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        characterHead = GetComponentInChildren<Camera>();
    }


    void Update()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.z = Input.GetAxisRaw("Vertical");

        movementDirection = movementDirection.normalized;
        
        Vector3 forwardMovement = characterController.transform.forward * movementDirection.z;
        Vector3 rightMovement = characterController.transform.right * movementDirection.x;

        characterController.Move( ( forwardMovement + rightMovement ) * Time.deltaTime * moveSpeed);


        lookRotation.y += Input.GetAxis("Mouse X") * Time.deltaTime * lookSpeed;
        lookRotation.x -= Input.GetAxis("Mouse Y") * Time.deltaTime * lookSpeed;

        lookRotation.x = Mathf.Clamp(lookRotation.x, -80, 80);

        characterController.transform.eulerAngles = new Vector3(0, lookRotation.y, 0);
        characterHead.transform.localEulerAngles = new Vector3(lookRotation.x, 0, 0);
    }
}
