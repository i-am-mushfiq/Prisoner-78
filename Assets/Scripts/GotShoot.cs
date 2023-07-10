using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotShoot : MonoBehaviour
{
    private Animator animator;
    int Health = 10;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("Health", Health);
        //sets initial health at 10
    }

    void Update()
    {
        
    }

    public void gotShoot()
    {
        Health = Health - 1;
        animator.SetInteger("Health", Health);

        animator.SetBool("isShot", true);
        StartCoroutine(ResetShotState());
        
    }

    private IEnumerator ResetShotState()
    {
        yield return new WaitForSeconds(1f); // 1 second delay
        
        animator.SetBool("isShot", false);
    }
}
