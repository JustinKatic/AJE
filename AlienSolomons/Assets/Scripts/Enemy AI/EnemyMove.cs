using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMove : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    private Transform targetDestination;

    [SerializeField] FloatVariable MyMoveSpeed;
    [SerializeField] FloatVariable SlowTowerDuration;
    [SerializeField] FloatVariable MyAttackRange;
    [SerializeField] StringVariable TagOfTargetDestination;
    [SerializeField] FloatVariable LookTowardsSpeed;


    private bool _slowDebuff;
    private float _slowDurationTimer;


    void Start()
    {
        targetDestination = GameObject.FindGameObjectWithTag(TagOfTargetDestination.Value).transform;

        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
        {
            Debug.LogError(gameObject.name + "does not have a nav mesh agent.");
        }
    }


    private void OnDisable()
    {
        _slowDebuff = false;
        SetEnemyMoveSpeed(MyMoveSpeed.Value);
    }

    private void Update()
    {
        SlowDebuff(MyMoveSpeed.Value);

        float dist = Vector3.Distance(transform.position, targetDestination.position);
        if (dist > MyAttackRange.Value)
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(targetDestination.position);
        }
        else
        {
            navMeshAgent.isStopped = true;
            transform.LookAt(targetDestination);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == TagOfTargetDestination.Value)
        {
            navMeshAgent.velocity = Vector3.zero;
            navMeshAgent.isStopped = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == TagOfTargetDestination.Value)
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
        SetEnemyMoveSpeed(MyMoveSpeed.Value - reduceSpeedByX);
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

    void LookTowards()
    {
        if (targetDestination != null)
        {
            Vector3 lookPos = targetDestination.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * LookTowardsSpeed.Value);
        }
    }
}
