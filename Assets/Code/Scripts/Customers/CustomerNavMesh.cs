using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerNavMesh : MonoBehaviour
{
    [SerializeField]
    private Vector3 orderApproachPosition;
    [SerializeField]
    private Vector3 orderContactPosition;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private bool reachedOrderApproachPosition = false;
    private bool reachedOrderContactPosition = false;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        navMeshAgent.destination = orderApproachPosition;
    }

    private void Update()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
        {
            if (!reachedOrderApproachPosition)
            {
                reachedOrderApproachPosition = true;
                navMeshAgent.destination = orderContactPosition;
            }

            else if (!reachedOrderContactPosition)
            {
                reachedOrderContactPosition = true;
            }

            else
            {
                animator.SetFloat("Speed_f", 0);
            }
        }
    }
}
