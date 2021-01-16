using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTower : MonoBehaviour
{
    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= TowerManager.instance._slowActivateEveryX)
        {
            MyCollisions();
            _timer = 0;
        }
    }

    void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, TowerManager.instance._slowRadius, TowerManager.instance.m_LayerMask);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].GetComponent<EnemyHealthManager>().HurtEnemy(TowerManager.instance._slowDamage);
            if (hitColliders[i].tag == "EnemyBarbarian")
                hitColliders[i].GetComponent<EnemyBarbarianMovement>().SetSlowDebuffTrue(TowerManager.instance._slowDebuffAmount);
            else if ((hitColliders[i].tag == "EnemyArcher"))
                hitColliders[i].GetComponent<EnemyArcherMove>().SetSlowDebuffTrue(TowerManager.instance._slowDebuffAmount);
            i++;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, TowerManager.instance._slowRadius);
    }
}
