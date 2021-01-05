using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform destination;
    NavMeshAgent navMeshAgent;
    GameObject player;


    void Start()
    {
        destination = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError(gameObject.name + "does not have a nav mesh agent.");
        }
    }

    private void Update()
    {
        navMeshAgent.SetDestination(destination.position);      
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
            navMeshAgent.isStopped = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == player)
            navMeshAgent.isStopped = false;
    }
}
