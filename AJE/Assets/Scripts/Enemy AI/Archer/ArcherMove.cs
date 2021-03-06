using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherMove : EnemyMove
{
    [SerializeField] float MyAttackRange;
    private ArcherShoot archerShoot;

    bool shootState;
    bool followTargetState;

    [SerializeField] float shootCooldown;
    private float shootCooldownTimer;

    private void Awake()
    {
        archerShoot = gameObject.GetComponent<ArcherShoot>();
    }

    private void OnEnable()
    {
        followTargetState = true;
        shootCooldownTimer = shootCooldown;
    }
    public override void Move()
    {
        float dist = Vector3.Distance(transform.position, targetDestination.position);


        if (followTargetState)
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(targetDestination.position);

            if (dist < MyAttackRange)
            {
                if (archerShoot.shootReady)
                {
                    followTargetState = false;
                    shootState = true;
                }
            }

            shootCooldownTimer -= Time.deltaTime;
            if (shootCooldownTimer <= 0)
            {
                shootCooldownTimer = shootCooldown;
                archerShoot.shootReady = true;
            }

        }

        if (shootState)
        {
            navMeshAgent.velocity = Vector3.zero;
            navMeshAgent.isStopped = true;

            if (archerShoot.shootReady == true)
            {
                archerShoot.CanShoot = true;
            }
            if (archerShoot.shootReady == false)
            {
                shootState = false;
                followTargetState = true;
            }

        }

    }
}
