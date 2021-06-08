using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfCannoneerMove : EnemyMove
{
    [SerializeField] float MyAttackRange;
    [SerializeField] float myFollowRange;

    [SerializeField] float randomXZWanderRangeMinMax;

    private DwarfCannoneerShoot dwarfCannoneerShoot;

    bool shootState;
    bool followTargetState = true;
    bool wanderState;


    [SerializeField] float wanderTime;
    private float wanderCounter;

    bool posFound = false;
    Vector3 wanderPos;


    protected override void Awake()
    {
        base.Awake();
        dwarfCannoneerShoot = gameObject.GetComponent<DwarfCannoneerShoot>();
    }


    protected override void OnEnable()
    {
        base.OnEnable();
        followTargetState = true;
        wanderCounter = 0;
    }
    public override void Move()
    {
        float dist = Vector3.Distance(transform.position, targetDestination.position);

        if (wanderState)
        {
            wanderCounter += Time.deltaTime;
            navMeshAgent.isStopped = false;

            if (posFound == false)
            {
                float x = Random.Range(transform.position.x - randomXZWanderRangeMinMax, transform.position.x + randomXZWanderRangeMinMax);
                float z = Random.Range(transform.position.z - randomXZWanderRangeMinMax, transform.position.z + randomXZWanderRangeMinMax);
                wanderPos = new Vector3(x, transform.position.y, z);
                posFound = true;
            }
            navMeshAgent.SetDestination(wanderPos);

            if (wanderCounter >= wanderTime)
            {
                posFound = false;
                wanderCounter = 0;
                wanderState = false;
                followTargetState = true;
            }
        }

        if (followTargetState)
        {

            navMeshAgent.isStopped = false;

            if (dist > myFollowRange)
            {
                navMeshAgent.SetDestination(targetDestination.position);
                navMeshAgent.isStopped = false;
            }
            if (dist < MyAttackRange)
            {
                followTargetState = false;
                shootState = true;
            }
        }

        if (shootState)
        {

            navMeshAgent.ResetPath();
            navMeshAgent.velocity = Vector3.zero;
            navMeshAgent.isStopped = true;
            anim.SetBool("aim", true);

            dwarfCannoneerShoot.CanShoot = true;
            LookTowards();

            if (dwarfCannoneerShoot.shotBullet == true)
            {
                dwarfCannoneerShoot.CanShoot = false;
                anim.SetBool("aim", false);
                Invoke("SetAnimAimBoolFalse", 1);
                shootState = false;
                wanderState = true;
                dwarfCannoneerShoot.shotBullet = false;
            }
        }
    }

    void SetAnimAimBoolFalse()
    {
        anim.SetBool("shoot", false);
    }
}

