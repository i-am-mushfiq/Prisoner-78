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

        bool isShooting = animator.GetBool("isShooting");
        bool shootPress = Input.GetMouseButton(0);

        bool forwardPress = Input.GetKey("w");
        bool rightPress = Input.GetKey("d");
        bool leftPress = Input.GetKey("a");

        void otherLogic()
        {
            if(aimPress)
            {
                animator.SetBool("isAiming", true);
            }
            if(!aimPress)
            {
                animator.SetBool("isAiming", false);
            }
            if(shootPress)
            {
                animator.SetBool("isShooting", true);
            }
            if(!shootPress)
            {
                animator.SetBool("isShooting", false);
            }
        }
        
        if (forwardPress)
        {
            animator.SetBool("isRunning", true);
            otherLogic();
        }
        if (!forwardPress)
        {
            animator.SetBool("isRunning", false);
            otherLogic();
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
