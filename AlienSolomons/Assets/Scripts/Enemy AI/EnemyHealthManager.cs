using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealthManager : MonoBehaviour
{
    [SerializeField] float _maxHealth;
    private float _currentHealth;
    public HealthBar healthBar;

    private void Start()
    {
    }

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
        healthBar.SetMaxHealth(_maxHealth);
    }

    private void Update()
    {
        if (_currentHealth <= 0)
            Die();
    }


    public void HurtEnemy(float damage)
    {
        _currentHealth -= damage;
        healthBar.SetHealth(_currentHealth);
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
