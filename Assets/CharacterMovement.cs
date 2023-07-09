using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;
    public float movementSpeed = 2f;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        bool isRunning = animator.GetBool("isRunning");
        bool forwardPress = Input.GetKey("w");
        bool rightPress = Input.GetKey("d");
        bool leftPress = Input.GetKey("a");

        if (!isRunning && forwardPress)
        {
            animator.SetBool("isRunning", true);
        }
        if (isRunning && !forwardPress)
        {
            animator.SetBool("isRunning", false);
        }

        if (isRunning)
        {
            Vector3 movement = transform.TransformDirection(Vector3.forward) * movementSpeed;
            characterController.SimpleMove(movement);

            if (rightPress)
            {
                transform.Rotate(Vector3.up, 90f * Time.deltaTime);
            }
            if (leftPress)
            {
                transform.Rotate(Vector3.up, -90f * Time.deltaTime);
            }
        }
    }
}
