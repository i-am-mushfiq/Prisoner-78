using UnityEngine;

public class CameraAim : MonoBehaviour
{
    public Vector3 aimPosition;
    public Vector3 aimRotation;
    public CharacterMovement characterMovement; // Reference to the CharacterMovement script

    private Transform parentObject;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Start()
    {
        // Assuming the parent object is the player object
        parentObject = transform.parent;

        // Store the initial position and rotation of the camera
        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation;
    }

    private void Update()
    {
        if (characterMovement != null && characterMovement.Update())
        {
            // Calculate the camera's new position and rotation relative to the parent object
            Vector3 newPosition = parentObject.TransformPoint(aimPosition);
            Quaternion newRotation = Quaternion.Euler(parentObject.eulerAngles + aimRotation);

            // Move the camera to the new position and rotation
            transform.position = newPosition;
            transform.rotation = newRotation;
        }
        else
        {
            // Return the camera to its initial position and rotation
            transform.localPosition = initialPosition;
            transform.localRotation = initialRotation;
        }
    }
}
