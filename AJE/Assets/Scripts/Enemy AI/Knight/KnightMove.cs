using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMove : EnemyMove
{
    [SerializeField] float ChargeSpeed;
    [SerializeField] float MyChargeRange;

    Vector3 chargePos;

    private float timer;
    [SerializeField] float chargeUpTime;

    bool posFound = false;
    bool charging;

    [SerializeField] TrailRenderer trail;

    public override void Move()
    {
        //move towards player
        float dist = Vector3.Distance(transform.position, targetDestination.position);
        if (charging == false && dist > MyChargeRange)
        {
            trail.enabled = false;
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(targetDestination.position);
        }

        else if (charging == false && dist < MyChargeRange)
        {
            charging = true;
            navMeshAgent.isStopped = true;
            LookTowards();
        }
        else if (charging == true)
        {
            trail.enabled = true;
            timer += Time.deltaTime;
            if (posFound == false)
            {
                chargePos = targetDestination.position;
                posFound = true;
            }
            if (timer >= chargeUpTime)
            {
                float distToChargePos = Vector3.Distance(transform.position, chargePos);
                navMeshAgent.isStopped = false;
                navMeshAgent.SetDestination(chargePos);

                if (!_slowDebuff)
                    SetEnemyMoveSpeed(ChargeSpeed);
                else
                    SetEnemyMoveSpeed(ChargeSpeed / _slowAmount);

                if (distToChargePos <= 2f)
                {
                    if (!_slowDebuff)
                        SetEnemyMoveSpeed(MyMoveSpeed);
                    else
                        SetEnemyMoveSpeed(MyMoveSpeed / _slowAmount);

                    posFound = false;
                    charging = false;
                    timer = 0;
                }
            }
        }
    }
}

