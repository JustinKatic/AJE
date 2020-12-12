using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    [SerializeField] float _maxHealth;
    private float _currentHealth;


    private void OnEnable()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (_currentHealth <= 0)
            SetUnActive();
    }

    public void HurtEnemy(float damage)
    {
        _currentHealth -= damage;
    }

        void SetUnActive()
    {
        gameObject.SetActive(false);
    }

}
