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

    [SerializeField] FloatVariable PlayerInGameExp;

    [SerializeField] FloatVariable MyExpWorth;

    [SerializeField] FloatVariable MyMaxHealth;

    [SerializeField] ListOfTransforms _listOfEnemies;

    [SerializeField] GameEvent MyDeathEvent;

    [SerializeField] bool IHaveAHealthBar;


    private void Start()
    {

    }

    private void OnEnable()
    {
        _currentHealth = MyMaxHealth.Value;
        if (IHaveAHealthBar)
            healthBar.SetMaxHealth(MyMaxHealth.Value);
    }

    private void Update()
    {
        if (_currentHealth <= 0)
            Die();
    }

    public void HurtEnemy(float damage)
    {
        _currentHealth -= damage;
        FloatingTxt(damage);
        if (IHaveAHealthBar)
            healthBar.SetHealth(_currentHealth);
    }

    public void FloatingTxt(float damage)
    {
        GameObject points = Instantiate(floatingDmg, transform.position, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-" + damage.ToString();
    }

    void Die()
    {
        _listOfEnemies.List.Remove(gameObject.transform);
        MyDeathEvent.Raise();
        gameObject.SetActive(false);
    }
}
