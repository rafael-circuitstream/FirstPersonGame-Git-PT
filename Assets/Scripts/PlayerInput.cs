using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector3 movementDirection;
    [SerializeField] private float moveSpeed;

    public Vector3 lookRotation;
    [SerializeField] private float lookSpeed;

    [SerializeField] private float jumpForce;

    private CharacterController characterController;
    private CustomPhysicsModule customPhysicsModule;
    private ShootingModule shootingModule;
    private Camera characterHead;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        customPhysicsModule = GetComponent<CustomPhysicsModule>();
        shootingModule = GetComponent<ShootingModule>();

        characterHead = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        HandleJumpInput();
        HandleLookInput();
        HandleMoveInput();
        HandleShootInput();
    }

    private void HandleMoveInput()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.z = Input.GetAxisRaw("Vertical");

        movementDirection = movementDirection.normalized;

        Vector3 forwardMovement = characterController.transform.forward * movementDirection.z;
        Vector3 rightMovement = characterController.transform.right * movementDirection.x;

        Vector3 totalMovement = (forwardMovement + rightMovement) * moveSpeed;

        totalMovement += customPhysicsModule.upDownForce;

        characterController.Move(totalMovement * Time.deltaTime);
    }

    private void HandleLookInput()
    {

        lookRotation.y += Input.GetAxis("Mouse X") * Time.deltaTime * lookSpeed;
        lookRotation.x -= Input.GetAxis("Mouse Y") * Time.deltaTime * lookSpeed;

        lookRotation.x = Mathf.Clamp(lookRotation.x, -80, 80);

        characterController.transform.eulerAngles = new Vector3(0, lookRotation.y, 0);
        characterHead.transform.localEulerAngles = new Vector3(lookRotation.x, 0, 0);
    }

    private void HandleJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            customPhysicsModule.AddJumpForce(jumpForce);
        }
    }

    private void HandleShootInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            shootingModule.Shoot();
        }
    }
}
