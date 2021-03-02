using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMove : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    protected Transform targetDestination;

    [SerializeField] protected FloatVariable MyMoveSpeed;
    [SerializeField] FloatVariable SlowTowerDuration;
    [SerializeField] StringVariable TagOfTargetDestination;
    [SerializeField] FloatVariable LookTowardsSpeed;
    [SerializeField] FloatVariable SlowAmount;



    private bool _slowDebuff;
    private float _slowDurationTimer;

    void Start()
    {
        GetTargetPos();
        GetNavComponent();
    }
    private void Update()
    {
        SlowDebuff();
        Move();
    }


    public void GetTargetPos()
    {
        targetDestination = GameObject.FindGameObjectWithTag(TagOfTargetDestination.Value).transform;
    }

    public void GetNavComponent()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
        {
            Debug.LogError(gameObject.name + "does not have a nav mesh agent.");
        }
    }

    private void OnDisable()
    {
        _slowDebuff = false;
        SetEnemyMoveSpeed(MyMoveSpeed.RuntimeValue);
    }
    public virtual void Move()
    {
        navMeshAgent.SetDestination(targetDestination.position);
    }


    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == TagOfTargetDestination.Value)
    //    {
    //        navMeshAgent.velocity = Vector3.zero;
    //        navMeshAgent.isStopped = true;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == TagOfTargetDestination.Value)
    //        navMeshAgent.isStopped = false;
    //}

    public void SetEnemyMoveSpeed(float enemyMoveSpeed)
    {
        if (navMeshAgent != null)
            navMeshAgent.speed = enemyMoveSpeed;
    }

    public float GetEnemyMoveSpeed()
    {
        return navMeshAgent.speed;
    }

    public void SetSlowDebuffTrue()
    {
        SetEnemyMoveSpeed(MyMoveSpeed.RuntimeValue / SlowAmount.RuntimeValue);
        _slowDebuff = true;
        _slowDurationTimer = 0;
    }

    public void SlowDebuff()
    {
        if (_slowDebuff == true)
        {
            _slowDurationTimer += Time.deltaTime;
            if (_slowDurationTimer > SlowTowerDuration.RuntimeValue)
            {
                SetEnemyMoveSpeed(MyMoveSpeed.RuntimeValue);
                _slowDurationTimer = 0;
                _slowDebuff = false;
            }
        }
    }

    public void LookTowards()
    {
        if (targetDestination != null)
        {
            Vector3 lookPos = targetDestination.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * LookTowardsSpeed.RuntimeValue);
        }
    }
}
