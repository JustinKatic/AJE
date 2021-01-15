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
            hitColliders[i].GetComponent<EnemyMovement>().SetSlowDebuffTrue(TowerManager.instance._slowDebuffAmount);
            i++;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, TowerManager.instance._slowRadius);
    }
}
