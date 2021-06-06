using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTower : TowersDefault
{
    public Transform objectToLookAtAimAtEnemy;
    [HideInInspector] public bool targetFound = false;

    public GameObject powerUpFx;


    protected override void Update()
    {
        base.Update();

        if (powerdUp)
            powerUpFx.SetActive(true);
        else
            powerUpFx.SetActive(false);
    }

    protected override void MyCollisions()
    {
        float closestTarget = Mathf.Infinity;
        GameObject closestEnemyObj = null;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, TowerRadius, EnemyLayerMask);
        if (hitColliders.Length > 0)
        {
            for (int i = 0; i < hitColliders.Length; i++)
            {
                float dist = Vector3.Distance(transform.position, hitColliders[i].transform.position);
                if (dist < closestTarget)
                {
                    closestTarget = dist;
                    closestEnemyObj = hitColliders[i].gameObject;
                }
            }
            if (closestEnemyObj != null)
            {
                targetFound = true;
                objectToLookAtAimAtEnemy.LookAt(closestEnemyObj.transform);
            }
        }
        else
        {
            targetFound = false;
        }
    }
    protected override void MyTriggerEffect()
    {
        return;
    }
}
