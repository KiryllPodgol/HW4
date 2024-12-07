using UnityEngine;
using UnityEngine.InputSystem;

public class RobotMove : MonoBehaviour
{
    public float movementSpeed = 5f;   
    public float rotationSpeed = 700f;
    public float mouseSensitivity = 1f; 
    private CharacterController characterController;
    private InputAsset inputAsset; 
    private Vector2 moveInput;
    private float yRotation;
    void Awake()
    {
        inputAsset = new InputAsset();
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnEnable()
    {
        inputAsset.Gameplay.Enable();
        inputAsset.Gameplay.Move.performed += OnMove;
        inputAsset.Gameplay.Move.canceled += CancelMove; 
        inputAsset.Gameplay.Look.performed += OnLook;
    }

    void OnDisable()
    {
        inputAsset.Gameplay.Move.performed -= OnMove;
        inputAsset.Gameplay.Move.canceled -= CancelMove; 
        inputAsset.Gameplay.Disable();
    }

    void Update()
    {
        Vector3 cameraForward = transform.forward;
        cameraForward.y = 0;
        Vector3 cameraRight = transform.right;

        Vector3 moveDirection = (cameraForward * moveInput.y + cameraRight * moveInput.x).normalized;

        if (moveDirection.sqrMagnitude > 0.01f)
        {
           
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        Vector3 velocity = moveDirection * movementSpeed;
        velocity.y = Physics.gravity.y; 
        characterController.Move(velocity * Time.deltaTime);
        
       
        if (moveInput.sqrMagnitude > 0.01f)
        {
            yRotation += Input.GetAxis("Mouse X") * mouseSensitivity; 
            transform.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void CancelMove(InputAction.CallbackContext context)
    {
        moveInput = Vector2.zero; 
    }

    private void OnLook(InputAction.CallbackContext context)
    {
        Vector2 lookInput = context.ReadValue<Vector2>();
        
        yRotation += lookInput.x * mouseSensitivity;

        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}