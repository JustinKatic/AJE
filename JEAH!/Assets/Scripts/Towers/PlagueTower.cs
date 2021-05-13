using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueTower : TowersDefault
{

    public float tickRate;
    public float duration;


    protected override void MyTriggerEffect()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, TowerRadius, EnemyLayerMask);
        int i = 0;
        while (i < hitColliders.Length)
        {
            EnemyHealthManager enemy = hitColliders[i].GetComponent<EnemyHealthManager>();
            FloatingTxt(TowerDamage, hitColliders[i].transform, "-", Color.white);
            enemy.SetPlagueDebuffTrue(TowerDamage, tickRate, duration);
            i++;
        }
    }


    protected override void MyCollisions()
    {
        return;
    }
}
