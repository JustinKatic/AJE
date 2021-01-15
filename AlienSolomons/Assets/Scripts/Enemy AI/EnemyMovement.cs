using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform destination;
    public NavMeshAgent navMeshAgent;
    GameObject player;
    public float _defaultMoveSpeed;



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


    private void OnDisable()
    {
        SetEnemyMoveSpeed(_defaultMoveSpeed);
    }

    private void Update()
    {
            navMeshAgent.SetDestination(destination.position);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            navMeshAgent.velocity = Vector3.zero;
            navMeshAgent.isStopped = true;          
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == player)
            navMeshAgent.isStopped = false;
    }

    public void SetEnemyMoveSpeed(float enemyMoveSpeed)
    {
        if (navMeshAgent != null)
            navMeshAgent.speed = enemyMoveSpeed;
    }

    public float GetEnemyMoveSpeed()
    {
        return navMeshAgent.speed;
    }
}
