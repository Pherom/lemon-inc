using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerNavMesh : MonoBehaviour
{   
    private Vector3 orderContactPosition;
    [SerializeField]
    private Vector3 exitPosition;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private bool reachedOrderApproachPosition = false;
    private bool reachedOrderContactPosition = false;
    private bool reachedExitPosition = false;
    private bool isUpNext = false;
    private bool isDone = false;

    public Vector3 OrderContactPosition
    {
        get { return orderContactPosition; }
        set { orderContactPosition = value; }
    }

    public bool IsUpNext
    {
        get { return isUpNext; }
        set { isUpNext = value; }
    }

    public bool IsDone
    {
        get { return isDone; }
        set { isDone = value; }
    }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isDone)
        {
            animator.SetFloat("Speed_f", 0.3f);
            navMeshAgent.destination = exitPosition;
        }

        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
        {
            if (!reachedOrderApproachPosition)
            {
                reachedOrderApproachPosition = true;
                if (isUpNext)
                {
                    navMeshAgent.destination = orderContactPosition;
                }
            }

            else if (isUpNext && !reachedOrderContactPosition)
            {
                navMeshAgent.destination = orderContactPosition;
                animator.SetFloat("Speed_f", 0.3f);
                reachedOrderContactPosition = true;
            }

            else if(isDone)
            {
                if (!reachedExitPosition)
                {
                    reachedExitPosition = true;
                }
                else
                {
                    Destroy(gameObject);
                }
            }

            else
            {
                animator.SetFloat("Speed_f", 0);
                transform.LookAt(GameObject.Find("XR Rig").transform);
            }
        }
    }
}
