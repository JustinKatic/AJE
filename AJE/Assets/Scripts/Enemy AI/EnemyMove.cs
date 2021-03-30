using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMove : MonoBehaviour
{
    //Refrences
    public NavMeshAgent navMeshAgent;
    protected Transform targetDestination;
    GameObject player;


    [SerializeField] protected float MyMoveSpeed;
    [SerializeField] protected float LookTowardsSpeed;
    protected float _slowTowerDuration;
    protected float _slowAmount;

    [SerializeField] GameObject slowEffect;
    [HideInInspector] protected bool _slowDebuff;
    private float _slowDurationTimer;

    [Header("Lureing variables")]
    [SerializeField] FloatVariable EnemyLureToTowerRange;
    [SerializeField] FloatVariable followPlayerForXAfterLure;
    [SerializeField] float distanceOffSet;

    [SerializeField] LayerMask TowerLayerMask;
    private float followPlayertimer;




    protected virtual void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //set target destination to player as default first state.
        targetDestination = player.transform;
        //ensure slowdebuff is false 
        _slowDebuff = false;
        //set nav agent speed to moveSpeed var
        SetEnemyMoveSpeed(MyMoveSpeed);
        //check to see if tower is in range every 0.5 seconds.
        InvokeRepeating("CheckForCloseTowers", 0, 0.5f);
    }

    private void OnDisable()
    {
        //stop checking for towers after obj has been set unActive
        CancelInvoke();
    }

    void Start()
    {
        GetNavComponent();
    }

    private void Update()
    {
        //if slow debuff is active do slow debuff logic
        if (_slowDebuff == true)
            SlowDebuff();

        //call move function
        Move();

        //increment follow player timer each second used to force enemy to follow player if timer is less then followPlayerForXAfterLure value
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

    //move nav to target destination
    public virtual void Move()
    {
        navMeshAgent.SetDestination(targetDestination.position);
    }

    //Set nav move speed to param given
    public void SetEnemyMoveSpeed(float enemyMoveSpeed)
    {
        if (navMeshAgent != null)
            navMeshAgent.speed = enemyMoveSpeed;
    }

    //get that navs current moveSpeed
    public float GetEnemyMoveSpeed()
    {
        return navMeshAgent.speed;
    }

    //set slow debuff to true
    public void SetSlowDebuffTrue(float slowAmount, float slowDuration)
    {
        _slowAmount = slowAmount;
        _slowTowerDuration = slowDuration;
        SetEnemyMoveSpeed(MyMoveSpeed / _slowAmount);
        _slowDebuff = true;
        _slowDurationTimer = 0;
    }

    //Slow debuff effect. called in update if slowdebuff is true
    public void SlowDebuff()
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

    //look towards target destination smoothly
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

    //DEBUG TOOLS to check range of enemys lure range
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, EnemyLureToTowerRange.Value);
    }
}
