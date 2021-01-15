using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTower : MonoBehaviour
{
    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= TowerManager.instance._damageActivateEveryX)
        {
            MyCollisions();
            _timer = 0;
        }
    }


    void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, TowerManager.instance._damageRadius, TowerManager.instance.m_LayerMask);
        int i = 0;
        //Check when there is a new collider coming into contact with the box
        while (i < hitColliders.Length)
        {
            hitColliders[i].GetComponent<EnemyHealthManager>().HurtEnemy(TowerManager.instance._damageDamage);
            i++;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, TowerManager.instance._damageRadius);
    }

}
