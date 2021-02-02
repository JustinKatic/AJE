using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTower : TowersDefault
{
    protected override void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, TowerRadius.RuntimeValue, EnemyLayerMask.Value);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].GetComponent<EnemyHealthManager>().HurtEnemy(TowerDamage.RuntimeValue);
            hitColliders[i].GetComponent<EnemyMove>().SetSlowDebuffTrue();
            i++;

        }
    }
}
