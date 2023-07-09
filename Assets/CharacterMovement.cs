using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Animator animator;

    public float movementSpeed = 3f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        bool isRunning = animator.GetBool("isRunning");
        bool ForwardPress = Input.GetKey("w");
        bool RightPress = Input.GetKey("d");
        bool LeftPress = Input.GetKey("a");

        if (!isRunning && ForwardPress)
        {
            animator.SetBool("isRunning", true);
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
        if (isRunning && !ForwardPress)
        {
            animator.SetBool("isRunning", false);
        }
        if (RightPress)
        {
            animator.SetBool("isRunning", true);
        }

        if (LeftPress)
        {
            animator.SetBool("isRunning", true);
        }
    }
}
