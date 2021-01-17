using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBarbarianMovement : MonoBehaviour
{
    Transform destination;
    public NavMeshAgent navMeshAgent;
    GameObject player;

    [SerializeField] FloatVariable _barbarianMoveSpeed;
    [SerializeField] FloatVariable SlowTowerDuration;




    private bool _slowDebuff;
    private float _slowDurationTimer;

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
        SetEnemyMoveSpeed(_barbarianMoveSpeed.Value);
        _slowDebuff = false;
    }

    private void Update()
    {
        navMeshAgent.SetDestination(destination.position);
        SlowDebuff(_barbarianMoveSpeed.Value);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            navMeshAgent.velocity = Vector3.zero;
            navMeshAgent.isStopped = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        {
            if (other.gameObject == player)
                navMeshAgent.isStopped = false;
        }
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
        SetEnemyMoveSpeed(_barbarianMoveSpeed.Value - reduceSpeedByX);
        _slowDebuff = true;
        _slowDurationTimer = 0;
    }

    public void SlowDebuff(float EnemyDefaultSpeed)
    {
        if (_slowDebuff == true)
        {
            _slowDurationTimer += Time.deltaTime;
            if (_slowDurationTimer > SlowTowerDuration.Value)
            {
                SetEnemyMoveSpeed(EnemyDefaultSpeed);
                _slowDurationTimer = 0;
                _slowDebuff = false;
            }
        }
    }
}
