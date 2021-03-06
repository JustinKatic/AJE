using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTower : TowersDefault
{

    public float slowTowerAmount;
    public float slowTowerDuration;


    protected override void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, TowerRadius, EnemyLayerMask);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].GetComponent<EnemyHealthManager>().HurtEnemy(TowerDamage);
            FloatingTxt(TowerDamage, hitColliders[i].transform, "-", Color.white);
            hitColliders[i].GetComponent<EnemyMove>().SetSlowDebuffTrue(slowTowerAmount, slowTowerDuration);
            i++;
        }
    }
}
