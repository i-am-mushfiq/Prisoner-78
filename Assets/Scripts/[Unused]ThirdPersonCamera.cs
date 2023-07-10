using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Camera offset from the player

    public float rotationSpeed = 3f; // Speed of camera rotation
    public float damping = 5f; // Damping factor for camera movement

    private float mouseX; // Mouse X-axis input for rotation
    private float mouseY; // Mouse Y-axis input for rotation

    private Vector3 targetPosition; // Desired position for the camera
    private Quaternion targetRotation; // Desired rotation for the camera

    private void Start()
    {
        if (player == null)
        {
            Debug.LogError("No player assigned to the ThirdPersonCamera script!");
        }

        // Lock cursor to the game window and hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            // Get mouse input for rotation
            mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
            mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
            mouseY = Mathf.Clamp(mouseY, -80f, 80f); // Limit vertical rotation angle

            // Calculate the desired position and rotation of the camera
            Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0f);
            targetPosition = player.position + rotation * offset;
            targetRotation = Quaternion.LookRotation(player.position - transform.position, Vector3.up);

            // Smoothly move the camera towards the desired position and rotation
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * damping);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * damping);
        }
    }
}
