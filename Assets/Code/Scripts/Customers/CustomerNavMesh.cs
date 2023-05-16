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

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.destination = orderApproachPosition;
    }

    private void Update()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
        {
            navMeshAgent.destination = orderContactPosition;
        }
    }
}
