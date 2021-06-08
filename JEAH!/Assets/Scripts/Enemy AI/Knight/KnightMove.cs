using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMove : EnemyMove
{
    [Header("Charge Variables")]
    [SerializeField] float ChargeSpeed;
    [SerializeField] float MyChargeRange;
    [SerializeField] float chargeUpTime;
    private float ChargeUpTimer;
    [SerializeField] float chargeCooldown;

    private bool posFound = false;
    private bool charging;
    private bool canCharge;
    private Vector3 chargePos;
    private float chargeCooldownTimer;

    [Header("Charge VFX")]
    [SerializeField] TrailRenderer trail;


    public override void Move()
    {
        //CHARGE COOLDOWN
        //If canCharge == false count down charge cooldown timer. once cooldownTimer <0 set canChargeTrue
        if (!canCharge)
        {
            chargeCooldownTimer -= Time.deltaTime;
            if (chargeCooldownTimer < 0)
            {
                canCharge = true;
            }
        }

        // get distance between SelfAndTarget
        float distBetweenSelfAndTarget = Vector3.Distance(transform.position, targetDestination.position);

        //if not in chargeing state and not in charge range follow target destination
        if (charging == false && distBetweenSelfAndTarget > MyChargeRange)
        {
            trail.enabled = false;
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(targetDestination.position);
        }

        //If not in chargeing state AND in charge range AND canCharge
        //stop the agent where it is Set chargeing to true
        else if (charging == false && distBetweenSelfAndTarget < MyChargeRange && canCharge)
        {
            charging = true;
            navMeshAgent.isStopped = true;
            navMeshAgent.velocity = Vector3.zero;          
        }

        //If chargeingState is true
        else if (charging == true)
        {
            //enable charge vfx and start chargeUptimer and LookTowards Destination
            trail.enabled = true;
            ChargeUpTimer += Time.deltaTime;
            LookTowardChargePos();
            anim.SetBool("aim", true);

            //If not charge pos is found get the targets pos at its current pos and then stop looking for pos.
            if (posFound == false)
            {
                chargePos = targetDestination.position;
                posFound = true;
            }

            //If chargeUptimer is greater then chargeTime.
            if (ChargeUpTimer >= chargeUpTime)
            {
                //get the distance between Self and Charge Pos.
                float distbetweenSelfandChargePos = Vector3.Distance(transform.position, chargePos);

                //Move agent towards charge Pos.
                navMeshAgent.isStopped = false;
                navMeshAgent.SetDestination(chargePos);
                anim.SetBool("charge", true);
                anim.SetBool("aim", false);



                //change speed based of if slowdebuff is true or not.
                if (!_slowDebuff)
                    SetEnemyMoveSpeed(ChargeSpeed);
                else
                    SetEnemyMoveSpeed(ChargeSpeed / _slowAmount);

                //If agent gets within 2 units of charge pos.
                if (distbetweenSelfandChargePos <= 2f)
                {
                    //set movespeed back to normal speed based on if slowdeff true or not
                    if (!_slowDebuff)
                        SetEnemyMoveSpeed(MyMoveSpeed);
                    else
                        SetEnemyMoveSpeed(MyMoveSpeed / _slowAmount);

                    anim.SetBool("charge", false);

                    //reset variables ready for next time charge state is made true
                    posFound = false;
                    charging = false;
                    ChargeUpTimer = 0;
                    canCharge = false;
                    chargeCooldownTimer = chargeCooldown;
                }
            }
        }
    }
    //LookTowardsCharge Pos Smoothly
    public void LookTowardChargePos()
    {
        if (chargePos != null)
        {
            Vector3 lookPos = chargePos - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * LookTowardsSpeed);
        }
    }
}

