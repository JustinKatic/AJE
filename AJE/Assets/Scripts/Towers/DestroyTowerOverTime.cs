using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTowerOverTime : MonoBehaviour
{
    TowerHealth towerHealth;
    [SerializeField] float _damage;
    [SerializeField] float _damageEveryXSeconds;

    private void OnEnable()
    {
        towerHealth = gameObject.GetComponent<TowerHealth>();
        InvokeRepeating("HurtTowerEveryX", 0, _damageEveryXSeconds);
    }

    private void HurtTowerEveryX()
    {
        towerHealth.HurtEnemy(_damage,false);
    }
}
