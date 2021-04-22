using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTowerOverTime : MonoBehaviour
{
    TowerHealth towerHealth;
    [SerializeField] float towerHealthLossSpeed;

    private void OnEnable()
    {
        towerHealth = gameObject.GetComponent<TowerHealth>();
        InvokeRepeating("HurtTowerEveryX", 0, towerHealthLossSpeed);
    }

    private void HurtTowerEveryX()
    {
        towerHealth.HurtEnemy(1, false);
    }
}
