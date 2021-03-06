using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NecroticTower : TowersDefault
{
    [SerializeField] FloatVariable PlayerCurrentHealth;
    [SerializeField] FloatVariable PlayerMaxHealth;

    [SerializeField] GameEvent IncreasePlayerHealthEvent;
    [SerializeField] FloatVariable NecroticTowerHealAmount;

    GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    protected override void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, TowerRadius, EnemyLayerMask);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].GetComponent<EnemyHealthManager>().HurtEnemy(TowerDamage);
            FloatingTxt(TowerDamage, hitColliders[i].transform, "-", Color.white);
            if (PlayerCurrentHealth.RuntimeValue < PlayerMaxHealth.RuntimeValue)
            {
                PlayerCurrentHealth.RuntimeValue += TowerDamage / 2;
                FloatingTxt(TowerDamage / 2, player.transform, "+", Color.green);
                IncreasePlayerHealthEvent.Raise();
            }
            i++;
        }
    }
}
