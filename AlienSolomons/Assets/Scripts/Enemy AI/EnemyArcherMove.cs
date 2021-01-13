using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyArcherMove : MonoBehaviour
{
    Transform destination;
    public NavMeshAgent navMeshAgent;
    GameObject player;
    public float _defaultMoveSpeed;

    [SerializeField] float _range;
    public bool _shooting;



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
        float dist = Vector3.Distance(transform.position, player.transform.position);
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
            transform.LookAt(player.transform);
        }

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