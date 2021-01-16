using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class EnemyHealthManager : MonoBehaviour
{
    private float _currentHealth;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameObject floatingDmg;
    private PlayerExpManager _playerExp;


    private void Start()
    {
        _playerExp = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerExpManager>();
    }

    private void OnEnable()
    {
        if (gameObject.tag == "EnemyBarbarian")
        {
            _currentHealth = EnemyManager.instance._barbarianMaxHealth;
            healthBar.SetMaxHealth(EnemyManager.instance._barbarianMaxHealth);
        }
        else if (gameObject.tag == "EnemyArcher")
        {
            _currentHealth = EnemyManager.instance._archerMaxHealth;
            healthBar.SetMaxHealth(EnemyManager.instance._archerMaxHealth);
        }

    }

    private void Update()
    {
        if (_currentHealth <= 0)
            Die();
    }

    public void HurtEnemy(float damage)
    {
        _currentHealth -= damage;
        GameObject points = Instantiate(floatingDmg, transform.position, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-" + damage.ToString();
        healthBar.SetHealth(_currentHealth);
    }

    void Die()
    {
        GameObject _currency = ObjectPooler.SharedInstance.GetPooledObject("Currency");
        _currency.transform.position = gameObject.transform.position;
        _currency.transform.rotation = gameObject.transform.rotation;
        _currency.SetActive(true);
        gameObject.SetActive(false);
        _playerExp.AddExp(EnemyManager.instance._barbarianExpWorth);
        PlayerStats.instance._playerExp += EnemyManager.instance._barbarianExpWorth;
        EnemyManager.instance._enemies.Remove(gameObject.transform);
        WaveSpawner._enemyCount -= 1;
    }
}
