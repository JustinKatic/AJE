using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : EnemyMove
{
    [SerializeField] float ChargeSpeed;
    [SerializeField] float MyChargeRange;

    Vector3 chargePos;

    private float chargeUptimer;
    [SerializeField] float chargeUpTime;

    private float fleeTimer;
    public float fleeForX;

    bool posFound = false;

    bool canCharge;
    bool charge;
    bool fleeing;
    bool hoverToPlayer;

    [SerializeField] GameObject trail;

    public float fleeMultipler;
    public float ChargeMultipler;


    protected override void OnEnable()
    {
        base.OnEnable();
        fleeTimer = fleeForX;
        hoverToPlayer = true;
    }
    public override void Move()
    {
        //move away from player if dist is less then charge distance
        float dist = Vector3.Distance(transform.position, targetDestination.position);

        if (hoverToPlayer)
        {
            HoverTowardsPlayerState();
            if (dist < MyChargeRange)
            {
                hoverToPlayer = false;
                canCharge = true;
            }
        }

        //If dist is greater then charge distance and not already charging stop agent and set charging to true
        if (canCharge)
        {
            GetChargeTarget();
        }

        //if chargeing is true look for pos to charge to. then wait till timer is higher then charge up time
        if (charge)
        {
            ChargeState();
        }
        if (fleeing)
        {
            FleeState();
        }
    }

    private void HoverTowardsPlayerState()
    {
        // navMeshAgent.SetDestination(targetDestination.position);
        LookTowardsTarget(targetDestination.position);
        if (!_slowDebuff)
            MoveForward(MyMoveSpeed);
        else
            MoveForward(MyMoveSpeed / _slowAmount);
    }
    private void FleeState()
    {
        fleeTimer -= Time.deltaTime;
        trail.SetActive(false);
        //navMeshAgent.isStopped = false;
        Vector3 fleePos = transform.position + ((transform.position - targetDestination.transform.position) * fleeMultipler);
        fleePos.y = 1;
        LookTowardsTarget(fleePos);
        MoveForward(MyMoveSpeed);
        if (fleeTimer <= 0)
        {
            fleeing = false;
            hoverToPlayer = true;
            fleeTimer = fleeForX;
        }
    }

    private void GetChargeTarget()
    {

        if (!posFound)
        {
            MoveForward(0);
            trail.SetActive(true);
            chargePos = targetDestination.transform.position + ((targetDestination.transform.position - transform.position) * ChargeMultipler);
            chargePos.y += 4;
            posFound = true;
        }

        LookTowardsTarget(chargePos);

        chargeUptimer += Time.deltaTime;
        if (chargeUptimer >= chargeUpTime)
        {
            charge = true;
            canCharge = false;
            posFound = false;
        }
    }

    private void ChargeState()
    {
        float distToChargePos = Vector3.Distance(transform.position, chargePos);
        LookTowardsTarget(chargePos);
        if (!_slowDebuff)
            MoveForward(ChargeSpeed);
        else
            MoveForward(ChargeSpeed / _slowAmount);


        //if object reached charge position reset speed back to normal and restart ai loop from start.
        if (distToChargePos <= 3f)
        {
            chargeUptimer = 0;
            charge = false;
            fleeing = true;
        }
    }

    void MoveForward(float moveSpeed)
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    public void LookTowardsTarget(Vector3 targetPos)
    {
        Vector3 lookPos = targetPos - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * LookTowardsSpeed);
    }

}