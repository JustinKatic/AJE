using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMove : EnemyMove
{
    [SerializeField] FloatVariable ChargeSpeed;
    [SerializeField] FloatVariable MyChargeRange;

    Vector3 chargePos;

    private float timer;
    [SerializeField] FloatVariable chargeUpTime;

    bool posFound = false;
    bool charging;

    [SerializeField] TrailRenderer trail;

    public override void Move()
    {
        //move towards player
        float dist = Vector3.Distance(transform.position, targetDestination.position);
        if (charging == false && dist > MyChargeRange.RuntimeValue)
        {
            trail.enabled = false;
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(targetDestination.position);
        }

        else if (charging == false && dist < MyChargeRange.RuntimeValue)
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
            if (timer >= chargeUpTime.RuntimeValue)
            {
                float distToChargePos = Vector3.Distance(transform.position, chargePos);
                navMeshAgent.isStopped = false;
                navMeshAgent.SetDestination(chargePos);

                if (!_slowDebuff)
                    SetEnemyMoveSpeed(ChargeSpeed.RuntimeValue);
                else
                    SetEnemyMoveSpeed(ChargeSpeed.RuntimeValue / SlowAmount.RuntimeValue);

                if (distToChargePos <= 1f)
                {
                    if (!_slowDebuff)
                        SetEnemyMoveSpeed(MyMoveSpeed.RuntimeValue);
                    else
                        SetEnemyMoveSpeed(MyMoveSpeed.RuntimeValue / SlowAmount.RuntimeValue);

                    posFound = false;
                    charging = false;
                    timer = 0;
                }
            }
        }
    }
}

