using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianMove : EnemyMove
{
    public override void Move()
    {
        //LookTowards();
        navMeshAgent.SetDestination(targetDestination.position);
    }
}
