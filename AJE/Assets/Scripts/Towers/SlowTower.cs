using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SlowTower : TowersDefault
{
    protected override void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, TowerRadius.RuntimeValue, EnemyLayerMask.Value);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].GetComponent<EnemyHealthManager>().HurtEnemy(TowerDamage.RuntimeValue);
            FloatingTxt(TowerDamage.RuntimeValue, hitColliders[i].transform);
            hitColliders[i].GetComponent<EnemyMove>().SetSlowDebuffTrue();
            i++;
        }
    }
    public void FloatingTxt(float damage, Transform transformToSpawnTxtAt)
    {
        GameObject points = Instantiate(floatingDmg, transformToSpawnTxtAt.position, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-" + damage.ToString();
    }
}
