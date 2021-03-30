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

    [SerializeField] float distanceOffSet;

    private float followPlayertimer;
    [SerializeField] FloatVariable followPlayerForXAfterLure;



    protected virtual void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        targetDestination = player.transform;
        _slowDebuff = false;
        SetEnemyMoveSpeed(MyMoveSpeed);
        InvokeRepeating("CheckForCloseTowers", 0, 0.5f);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }

    void Start()
    {
        GetNavComponent();
    }
    private void Update()
    {
        SlowDebuff();

        Move();

        followPlayertimer += Time.deltaTime;
    }

    void CheckForCloseTowers()
    {
        //if Current target is player and followLureTimer is less then followPlayer timer Dont Check for close towers and continue following player.
        if (targetDestination == player.transform && followPlayertimer < followPlayerForXAfterLure.Value)
        {
            return;
        }

        //Get the distance between the enemy and player.
        float distBetweenSelfandPlayer = Vector3.Distance(transform.position, player.transform.position);

        //Get list of all the towers that are within range of the enemy.
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, EnemyLureToTowerRange.Value, TowerLayerMask);

        //If any tower is in range AND distBetweenSelfandPlayer is greater then the distanceOffSet value.
        if (hitColliders.Length >= 1 && distBetweenSelfandPlayer > distanceOffSet)
        {
            //set target destination to the first tower in collider list.
            targetDestination = hitColliders[0].transform;
        }

        //Player is inside the offset range
        else
        {
            //set destination to player
            targetDestination = player.transform;
            //reset the followPlayerTimer to 0 to force enemy to follow player for the followPlayerForXAfterLure variable.
            followPlayertimer = 0;
        }
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
