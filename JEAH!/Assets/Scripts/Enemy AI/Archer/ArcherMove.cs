using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherMove : EnemyMove
{
    [SerializeField] float MyAttackRange;

    private ArcherShoot archerShoot;

    bool shootState;
    bool followTargetState;

    float rotatingTimer;
    public float timeRotatingBeforeShot;

    [SerializeField] float shootCooldown;
    [SerializeField] float shootCooldownSlowDebuff;

    private float shootCooldownTimer;

    public LayerMask playerLayer;
    public LayerMask towerLayer;

    protected override void Awake()
    {
        base.Awake();
        archerShoot = gameObject.GetComponent<ArcherShoot>();
    }


    protected override void OnEnable()
    {
        base.OnEnable();
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
            LookTowards();

            if (!archerShoot.shootReady && HasLOS() && dist <= MyAttackRange)
            {
                navMeshAgent.velocity = Vector3.zero;
                navMeshAgent.isStopped = true;
            }

            else if (archerShoot.shootReady && HasLOS() && dist <= MyAttackRange)
            {
                followTargetState = false;
                shootState = true;
            }


            shootCooldownTimer -= Time.deltaTime;
            if (shootCooldownTimer <= 0)
            {
                if (_slowDebuff)
                    shootCooldownTimer = shootCooldownSlowDebuff;
                else
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
                anim.SetBool("aim", true);
                rotatingTimer += Time.deltaTime;
                if (rotatingTimer <= timeRotatingBeforeShot)
                {
                    LookTowards();
                }
                archerShoot.CanShoot = true;

            }
            if (archerShoot.shootReady == false)
            {
                rotatingTimer = 0f;
                shootState = false;
                followTargetState = true;
            }
        }
    }

    private bool HasLOS()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity) && hit.transform.gameObject.tag == "DamageableTower")
            return true;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity) && hit.transform.gameObject.tag == "Player")
            return true;

        return false;
    }
}
