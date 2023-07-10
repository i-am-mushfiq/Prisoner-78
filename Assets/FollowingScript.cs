using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingScript : MonoBehaviour
{

    private UnityEngine.AI.NavMeshAgent agent;
    public Transform target;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && animator.GetInteger("Health") > 0)
        {
            // Set the destination of the NavMeshAgent to the target position
            agent.SetDestination(target.position);
        }
    }

}
