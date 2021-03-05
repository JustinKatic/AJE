using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMove : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    protected Transform targetDestination;

    [SerializeField] protected float MyMoveSpeed;
    [SerializeField] float SlowTowerDuration;
    [SerializeField] StringVariable TagOfTargetDestination;
    [SerializeField] protected float LookTowardsSpeed;
    [SerializeField] protected float SlowAmount;
    [SerializeField] GameObject slowEffect;



    [HideInInspector] protected bool _slowDebuff;
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
        SetEnemyMoveSpeed(MyMoveSpeed);
    }
    public virtual void Move()
    {
        navMeshAgent.SetDestination(targetDestination.position);
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

    public void SetSlowDebuffTrue()
    {
        SetEnemyMoveSpeed(MyMoveSpeed / SlowAmount);
        _slowDebuff = true;
        _slowDurationTimer = 0;
    }

    public void SlowDebuff()
    {
        if (_slowDebuff == true)
        {
            slowEffect.SetActive(true);
            _slowDurationTimer += Time.deltaTime;
            if (_slowDurationTimer > SlowTowerDuration)
            {
                SetEnemyMoveSpeed(MyMoveSpeed);
                _slowDurationTimer = 0;
                _slowDebuff = false;
                slowEffect.SetActive(false);
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
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * LookTowardsSpeed);
        }
    }
}
