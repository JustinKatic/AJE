using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageTower : TowersDefault
{
    protected override void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, TowerRadius, EnemyLayerMask.Value);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].GetComponent<EnemyHealthManager>().HurtEnemy(TowerDamage);
            FloatingTxt(TowerDamage,hitColliders[i].transform);
            i++;
        }
    }

    public void FloatingTxt(float damage, Transform transformToSpawnTxtAt)
    {
        GameObject points = Instantiate(floatingDmg, transformToSpawnTxtAt.position, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-" + damage.ToString();
    }
}
