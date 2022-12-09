using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Navigation : MonoBehaviour
{
    GameObject destination;
    NavMeshAgent agent;

    private void Update()
    {
        destination = GameObject.Find("AgentTarget");
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destination.transform.position);
    }
}

