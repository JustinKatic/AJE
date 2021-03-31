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
    [SerializeField] FloatVariable EnemyDetectionRange;

    private LayerMask TowerLayerMask;
    private LayerMask PlayerMask;



    protected virtual void Awake()
    {
        PlayerMask = LayerMask.GetMask("Player");
        TowerLayerMask = LayerMask.GetMask("Tower");
    }

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
        InvokeRepeating("CheckForObjectsInRadius", 0, 0.5f);
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


    }

    void CheckForObjectsInRadius()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, EnemyDetectionRange.Value, TowerLayerMask | PlayerMask);
        if (hitColliders.Length <= 0)
        {
            targetDestination = player.transform;
            return;
        }
        foreach (Collider col in hitColliders)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                targetDestination = player.transform;
                return;
            }
        }
        targetDestination = hitColliders[0].transform;
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
        Gizmos.DrawWireSphere(transform.position, EnemyDetectionRange.Value);
    }
}
