using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueTower : TowersDefault
{
    protected override void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, TowerRadius.Value, EnemyLayerMask.Value);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].GetComponent<EnemyHealthManager>().SetPlagueDebuffTrue();         
            i++;
        }
    }
}
