using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMove : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    protected Transform targetDestination;

    [SerializeField] protected float MyMoveSpeed;
    [SerializeField] protected float LookTowardsSpeed;
    protected float _slowTowerDuration;
    protected float _slowAmount;
    [SerializeField] GameObject slowEffect;


    [HideInInspector] protected bool _slowDebuff;
    private float _slowDurationTimer;

    GameObject player;
    // [SerializeField] ListOfTransforms ListOfActiveTowers;

    [SerializeField] FloatVariable EnemyLureToTowerRange;
    [SerializeField] LayerMask TowerLayerMask;

    [SerializeField] float distanceOffset;


    protected virtual void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        targetDestination = player.transform;
        _slowDebuff = false;
        SetEnemyMoveSpeed(MyMoveSpeed);
        InvokeRepeating("CheckForCloseTowers", 0, 0.5f);
    }

    void Start()
    {
        GetNavComponent();
    }
    private void Update()
    {
        SlowDebuff();

        Move();
    }

    void CheckForCloseTowers()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, EnemyLureToTowerRange.Value, TowerLayerMask);

        if (hitColliders.Length >= 1 && dist > distanceOffset)
        {
            targetDestination = hitColliders[0].transform;
        }
        else
            targetDestination = player.transform;
    }


    public void GetNavComponent()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
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

    public void SetSlowDebuffTrue(float slowAmount, float slowDuration)
    {
        _slowAmount = slowAmount;
        _slowTowerDuration = slowDuration;
        SetEnemyMoveSpeed(MyMoveSpeed / _slowAmount);
        _slowDebuff = true;
        _slowDurationTimer = 0;
    }

    public void SlowDebuff()
    {
        if (_slowDebuff == true)
        {
            slowEffect.SetActive(true);
            _slowDurationTimer += Time.deltaTime;
            if (_slowDurationTimer > _slowTowerDuration)
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

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, EnemyLureToTowerRange.Value);
    }
}
