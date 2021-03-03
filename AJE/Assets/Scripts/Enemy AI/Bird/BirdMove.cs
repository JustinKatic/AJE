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

    [SerializeField] GameObject trail;

    public GameObject fleeTest;
    public GameObject chargeTest;

    public float fleeMultipler;
    public float ChargeMultipler;


    public override void Move()
    {
        //move away from player if dist is less then charge distance
        float dist = Vector3.Distance(transform.position, targetDestination.position);
        if (charging == false && dist < MyChargeRange.RuntimeValue)
        {
            
            trail.SetActive(false);
            navMeshAgent.isStopped = false;

            Vector3 fleePos = transform.position + ((transform.position - targetDestination.transform.position) * fleeMultipler);
            fleePos.y = 1;
            Instantiate(fleeTest, fleePos, Quaternion.identity);

            navMeshAgent.SetDestination(fleePos);
            
        }

        //If dist is greater then charge distance and not already charging stop agent and set charging to true
        else if (charging == false && dist > MyChargeRange.RuntimeValue)
        {
            charging = true;
            navMeshAgent.velocity = Vector3.zero;
            navMeshAgent.isStopped = true;
            LookTowards();
        }

        //if chargeing is true look for pos to charge to. then wait till timer is higher then charge up time
        else if (charging == true)
        {
            trail.SetActive(true);
            timer += Time.deltaTime;
            if (posFound == false)
            {
                chargePos = targetDestination.transform.position + ((targetDestination.transform.position - transform.position) * ChargeMultipler);
                chargePos.y += 4;
                Instantiate(chargeTest, chargePos, Quaternion.identity);
                posFound = true;
            }

            // if timer is greater then charge up time set destination to target and allow bird to move again at faster speed.        
            if (timer >= chargeUpTime.RuntimeValue)
            {
                float distToChargePos = Vector3.Distance(transform.position, chargePos);
                navMeshAgent.isStopped = false;
                navMeshAgent.SetDestination(chargePos);
                SetEnemyMoveSpeed(ChargeSpeed.RuntimeValue);
                //if object reached charge position reset speed back to normal and restart ai loop from start.
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