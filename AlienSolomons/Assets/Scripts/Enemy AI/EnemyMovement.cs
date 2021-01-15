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

    public bool _slowDebuff;
    [SerializeField] float _slowedDuration = 2.0f;
    float _slowDurationTimer;

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
        _slowDebuff = false;
    }

    private void Update()
    {
        navMeshAgent.SetDestination(destination.position);

        if (_slowDebuff == true)
        {
            _slowDurationTimer += Time.deltaTime;
            if (_slowDurationTimer > _slowedDuration)
            {
                SetEnemyMoveSpeed(_defaultMoveSpeed);
                _slowDurationTimer = 0;
                _slowDebuff = false;
            }
        }
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

    public void SetSlowDebuffTrue(float reduceSpeedByX)
    {
        SetEnemyMoveSpeed(_defaultMoveSpeed - reduceSpeedByX);
        _slowDebuff = true;
        _slowDurationTimer = 0;
    }
}
