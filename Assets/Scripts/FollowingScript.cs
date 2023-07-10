using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingScript : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    private Transform target;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();

        // Find the object with the "player" tag and get its transform
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            target = playerObject.transform;
        }
        else
        {
            Debug.LogError("Unable to find object with the 'Player' tag.");
        }
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

    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("inRange", true) ;
        }
    }
}
