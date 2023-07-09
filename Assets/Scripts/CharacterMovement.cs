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

    public bool Update() //returns wheter the player is aiming or not
    {
        bool aimPress = Input.GetMouseButton(1);
        bool isRunning = animator.GetBool("isRunning");
        bool isAiming = animator.GetBool("isAiming");

        bool forwardPress = Input.GetKey("w");
        bool rightPress = Input.GetKey("d");
        bool leftPress = Input.GetKey("a");

        
        

        if (forwardPress)
        {
            animator.SetBool("isRunning", true);
            if(aimPress)
            {
                animator.SetBool("isAiming", true);
            }
            if(!aimPress)
            {
                animator.SetBool("isAiming", false);
            }
        }
        if (!forwardPress)
        {
            animator.SetBool("isRunning", false);
            if(aimPress)
            {
                animator.SetBool("isAiming", true);
            }
            if(!aimPress)
            {
                animator.SetBool("isAiming", false);
            }
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
        return aimPress;
    }
}
