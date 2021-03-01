using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : EnemyMove
{
    [SerializeField] FloatVariable ChargeSpeed;
    [SerializeField] FloatVariable MyChargeRange;

    Vector3 chargePos;

    private float timer;
    [SerializeField] FloatVariable chargeUpTime;

    bool posFound = false;
    bool charging;

    public override void Move()
    {
        //move towards player
        float dist = Vector3.Distance(transform.position, targetDestination.position);
        if (charging == false && dist > MyChargeRange.RuntimeValue)
        {
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
                navMeshAgent.speed = ChargeSpeed.RuntimeValue;
                if (distToChargePos <= 3f)
                {
                    navMeshAgent.speed = MyMoveSpeed.RuntimeValue;
                    posFound = false;
                    charging = false;
                    timer = 0;
                }
            }
        }
    }
}
