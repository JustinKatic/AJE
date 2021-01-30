using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : EnemyMove
{
    public override void Move()
    {
        navMeshAgent.SetDestination(targetDestination.position);
    }
}
