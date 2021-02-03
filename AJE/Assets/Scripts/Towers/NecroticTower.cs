﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NecroticTower : TowersDefault
{
    [SerializeField] FloatVariable PlayerCurrentHealth;
    [SerializeField] GameEvent UpdatePlayerHealth;
    [SerializeField] FloatVariable NecroticTowerHealAmount;


    protected override void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, TowerRadius.RuntimeValue, EnemyLayerMask.Value);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].GetComponent<EnemyHealthManager>().HurtEnemy(TowerDamage.RuntimeValue);
            FloatingTxt(TowerDamage.RuntimeValue, hitColliders[i].transform);
            PlayerCurrentHealth.RuntimeValue += TowerDamage.RuntimeValue / 2;
            UpdatePlayerHealth.Raise();
            i++;
        }
    }

    public void FloatingTxt(float value, Transform transformToSpawnTxtAt)
    {
        GameObject points = Instantiate(floatingDmg, transformToSpawnTxtAt.position, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-" + value.ToString();
    }
}