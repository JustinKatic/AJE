using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NecroticTower : TowersDefault
{
    [SerializeField] FloatVariable PlayerCurrentHealth;
    [SerializeField] GameEvent IncreasePlayerHealthEvent;
    [SerializeField] FloatVariable NecroticTowerHealAmount;


    protected override void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, TowerRadius, EnemyLayerMask);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].GetComponent<EnemyHealthManager>().HurtEnemy(TowerDamage);
            FloatingTxt(TowerDamage, hitColliders[i].transform);
            PlayerCurrentHealth.RuntimeValue += TowerDamage / 2;
            IncreasePlayerHealthEvent.Raise();
            i++;
        }
    }
}
