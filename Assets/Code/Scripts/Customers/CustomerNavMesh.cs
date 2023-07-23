using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class CustomerNavMesh : MonoBehaviour
{   
    private Vector3 orderContactPosition;
    [SerializeField]
    private Vector3 exitPosition;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private bool reachedOrderApproachPosition = false;
    private bool headingToOrderContactPosition = false;
    private bool reachedOrderContactPosition = false;
    private bool reachedExitPosition = false;
    private bool isUpNext = false;
    private bool isDone = false;
    private GameObject xrRig;
    [SerializeField]
    private UnityEvent reachedOrderContactPositionEvent;

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

    private void Start()
    {
        xrRig = GameObject.Find("XR Rig");
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
            }

            else if (isUpNext && !reachedOrderContactPosition)
            {
                if (!headingToOrderContactPosition)
                {
                    navMeshAgent.destination = orderContactPosition;
                    animator.SetFloat("Speed_f", 0.3f);
                    headingToOrderContactPosition = true;
                }
                
                else
                {
                    reachedOrderContactPosition = true;
                    reachedOrderContactPositionEvent.Invoke();
                }
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
                /*if (reachedOrderContactPosition)
                {
                    reachedOrderContactPositionEvent.Invoke();
                }*/

                animator.SetFloat("Speed_f", 0);
                transform.LookAt(xrRig.transform);
            }
        }
    }
}
