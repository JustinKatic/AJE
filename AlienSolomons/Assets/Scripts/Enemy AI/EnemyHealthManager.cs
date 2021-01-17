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
    [SerializeField] FloatVariable currentExp;
    [SerializeField] FloatVariable _barbairanExpWorth;
    [SerializeField] FloatVariable _archerExpWorth;

    [SerializeField] FloatVariable _barbarianMaxHealth;


    [SerializeField] FloatVariable _archerMaxHealth;

    [SerializeField] ListOfTransforms _listOfEnemies;






    private void Start()
    {
        _playerExp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerExpManager>();
    }

    private void OnEnable()
    {
        if (gameObject.tag == "EnemyBarbarian")
        {
            _currentHealth = _barbarianMaxHealth.Value;
            healthBar.SetMaxHealth(_barbarianMaxHealth.Value);
        }
        else if (gameObject.tag == "EnemyArcher")
        {
            _currentHealth = _archerMaxHealth.Value;
            healthBar.SetMaxHealth(_archerMaxHealth.Value);
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

        _listOfEnemies.List.Remove(gameObject.transform);

        if (gameObject.tag == "EnemyBarbarian")
        {
            _playerExp.AddExp(_barbairanExpWorth.Value);
        }
        else if (gameObject.tag == "EnemyArcher")
        {
            _playerExp.AddExp(_archerExpWorth.Value);
        }
    }
}
