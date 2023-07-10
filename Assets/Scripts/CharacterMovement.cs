using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;

    public Transform cameraTransform;

    public float movementSpeed = 2f;
    public float rotationSpeed = 5f;

    private float cameraRotationX = 0f;

    [SerializeField]
    private AudioSource shootingSoundSource;
    [SerializeField]
    private GameObject muzzleFlash;


    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

        // Find and assign the camera's transform
        cameraTransform = Camera.main.transform;
    }
    

    public bool Update() //returns wheter the player is aiming or not
    {
        bool aimPress = Input.GetMouseButton(1);
        bool isRunning = animator.GetBool("isRunning");
        bool isAiming = animator.GetBool("isAiming");

        bool isShooting = animator.GetBool("isShooting");
        bool shootPress = Input.GetMouseButton(0);

        bool forwardPress = Input.GetKey("w");
        bool backPress = Input.GetKey("s");
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

                //Sound
                shootingSoundSource.Play(); 
                if(muzzleFlash != null)
                {
                    muzzleFlash.SetActive(true);
                }  
            }
            if(!shootPress)
            {
                animator.SetBool("isShooting", false);
                if(muzzleFlash != null)
                {
                    muzzleFlash.SetActive(false);
                }      
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

        if (backPress)
        {
            animator.SetBool("isBackwards", true);

            Vector3 movement = transform.TransformDirection(-Vector3.forward) * (movementSpeed/2);
            characterController.SimpleMove(movement);
        }
        if (!backPress)
        {
            animator.SetBool("isBackwards", false);
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

        // Rotate character based on mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseX * rotationSpeed);

        if(!isAiming)
        {
            
        }
            float mouseY = Input.GetAxis("Mouse Y");
            float rotationX = -mouseY * rotationSpeed;
            cameraRotationX += rotationX;
            cameraRotationX = Mathf.Clamp(cameraRotationX, -30f, 30f);
            cameraTransform.localRotation = Quaternion.Euler(cameraRotationX, 0f, 0f);

        return aimPress;
    }
}