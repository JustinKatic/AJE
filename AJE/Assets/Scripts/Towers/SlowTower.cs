using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTower : TowersDefault
{

    public float slowTowerAmount;
    public float slowTowerDuration;

    protected override void MyTriggerEffect()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, TowerRadius, EnemyLayerMask);
        int i = 0;
        while (i < hitColliders.Length)
        {
            FloatingTxt(TowerDamage, hitColliders[i].transform, "-", Color.white);
            hitColliders[i].GetComponent<EnemyMove>().SetSlowDebuffTrue(slowTowerAmount, slowTowerDuration);
            i++;
        }
    }

    protected override void MyCollisions()
    {
        return;
    }
}
