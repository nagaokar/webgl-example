using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float jumpForce = 7.0f;
    public float gravity = 9.81f;
    public float mouseSensitivity = 2.0f;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private float verticalRotation = 0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // String Args From Unity Input Manager
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        moveDirection = move * movementSpeed;

            // Mouse input for looking around
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            // Rotate the player horizontally
            transform.Rotate(Vector3.up * mouseX);

            // Rotate the camera vertically
            verticalRotation -= mouseY;
            verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
            Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        }

        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;

        // Apply movement
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
