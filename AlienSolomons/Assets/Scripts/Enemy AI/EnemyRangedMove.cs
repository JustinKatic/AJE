using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRangedMove : MonoBehaviour
{
    Transform destination;
    NavMeshAgent navMeshAgent;
    Transform player;
    [SerializeField] float _range;
    public bool _shooting;

    void Start()
    {
        destination = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (navMeshAgent == null)
        {
            Debug.LogError(gameObject.name + "does not have a nav mesh agent.");
        }
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);
        if (dist > _range)
        {
            navMeshAgent.isStopped = false;
            _shooting = false;
            navMeshAgent.SetDestination(destination.position);
        }
        else
        {
            navMeshAgent.isStopped = true;
            _shooting = true;
            transform.LookAt(player);
        }
    }
}
