using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTower : TowersDefault
{
    public Transform objectToLookAtAimAtEnemy;
    [HideInInspector] public bool targetFound = false;
    protected override void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, TowerRadius, EnemyLayerMask);

        if (hitColliders.Length > 0)
        {
            objectToLookAtAimAtEnemy.LookAt(hitColliders[0].transform);
            targetFound = true;
        }
        else targetFound = false;
    }
    protected override void MyTriggerEffect()
    {
        return;
    }
}
