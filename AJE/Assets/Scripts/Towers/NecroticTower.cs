using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecroticTower : TowersDefault
{
    [SerializeField] FloatVariable PlayerCurrentHealth;
    [SerializeField] GameEvent UpdatePlayerHealth;
    [SerializeField] FloatVariable NecroticTowerHealAmount;


    protected override void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, TowerRadius.Value, EnemyLayerMask.Value);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].GetComponent<EnemyHealthManager>().HurtEnemy(TowerDamage.Value);
            PlayerCurrentHealth.Value += NecroticTowerHealAmount.Value;
            UpdatePlayerHealth.Raise();
            i++;
        }
    }
}
