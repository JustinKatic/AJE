using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfCannoneerMove : EnemyMove
{
    [SerializeField] FloatVariable MyAttackRange;
    
    public override void Move()
    {
        float dist = Vector3.Distance(transform.position, targetDestination.position);
        if (dist > MyAttackRange.Value)
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(targetDestination.position);
        }
        else
        {
            navMeshAgent.isStopped = true;
            LookTowards();
        }
    }
}
