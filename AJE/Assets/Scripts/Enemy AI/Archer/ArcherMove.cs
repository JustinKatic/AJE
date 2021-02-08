using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherMove : EnemyMove
{
    [SerializeField] FloatVariable MyAttackRange;
    private ArcherShoot archerShoot;


    private void Awake()
    {
        archerShoot = gameObject.GetComponent<ArcherShoot>();
    }

    public override void Move()
    {
        float dist = Vector3.Distance(transform.position, targetDestination.position);

        if (dist > MyAttackRange.RuntimeValue && archerShoot.shotTaken == true)
        {
            archerShoot.CanShoot = false;
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(targetDestination.position);
        }
        else
        {

            archerShoot.shotTaken = false;
            archerShoot.CanShoot = true;
            navMeshAgent.isStopped = true;
            LookTowards();
        }
    }
}
