using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueTower : TowersDefault
{

    public float tickDamage;
    public float tickRate;
    public float duration;


    protected override void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, TowerRadius, EnemyLayerMask.Value);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].GetComponent<EnemyHealthManager>().SetPlagueDebuffTrue(tickDamage, tickRate, duration);
            i++;
        }
    }
}
