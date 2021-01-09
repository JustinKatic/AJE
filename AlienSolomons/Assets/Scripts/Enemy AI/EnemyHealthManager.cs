using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealthManager : MonoBehaviour
{
    [SerializeField] float _maxHealth;
    private float _currentHealth;
    public HealthBar healthBar;
    [SerializeField] float _enemyExpWorth;
    PlayerExpManager _playerExp;
    
    private void Start()
    {
        _playerExp = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerExpManager>();
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
        GameObject _currency = ObjectPooler.SharedInstance.GetPooledObject("Currency");
        _currency.transform.position = gameObject.transform.position;
        _currency.transform.rotation = gameObject.transform.rotation;
        _currency.SetActive(true);
        gameObject.SetActive(false);
        _playerExp.AddExp(_enemyExpWorth);
        GameStats.instance._playerExp += _enemyExpWorth;
        WaveSpawner._enemyCount -= 1;
    }
}
