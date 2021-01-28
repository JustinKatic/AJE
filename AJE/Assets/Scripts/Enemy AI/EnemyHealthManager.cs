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

    [SerializeField] FloatVariable MyMaxHealth;

    [SerializeField] ListOfTransforms _listOfEnemies;

    [SerializeField] GameEvent MyDeathEvent;

    [SerializeField] bool IHaveAHealthBar;


    [HideInInspector] public bool plagueDebuff;
    private float plagueDurationTimer;
    [SerializeField] FloatVariable plagueDebuffDuration;
    [SerializeField] FloatVariable plagueTickDamage;

    [SerializeField] FloatVariable plagueTickRate;
    private float plagueTickTimer;




    private void Start()
    {

    }

    private void OnEnable()
    {
        _currentHealth = MyMaxHealth.Value;
        if (IHaveAHealthBar)
            healthBar.SetMaxHealth(MyMaxHealth.Value);
    }
    private void OnDisable()
    {
        plagueDebuff = false;
    }

    private void Update()
    {
        PlagueDebuff();
        if (_currentHealth <= 0)
            Death();
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

    void Death()
    {
        _listOfEnemies.List.Remove(gameObject.transform);
        MyDeathEvent.Raise();
        gameObject.SetActive(false);
    }

    public void PlagueDebuff()
    {
        if (plagueDebuff == true)
        {
            plagueTickTimer += Time.deltaTime;
            plagueDurationTimer += Time.deltaTime;

            if (plagueTickTimer > plagueTickRate.Value)
            {
                HurtEnemy(plagueTickDamage.Value);
                plagueTickTimer = 0;
            }

            if (plagueDurationTimer > plagueDebuffDuration.Value)
            {
                plagueDurationTimer = 0;
                plagueDebuff = false;
            }
        }
    }

    public void SetPlagueDebuffTrue()
    {
        plagueDebuff = true;
        plagueDurationTimer = 0;
        plagueTickTimer = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            if (plagueDebuff == false)
            {
                return;
            }
            EnemyHealthManager enemyHealthManager = other.gameObject.GetComponent<EnemyHealthManager>();
            if (enemyHealthManager.plagueDebuff == true)
            {
                return;
            }
            else if (enemyHealthManager.plagueDebuff == false)
            {
                enemyHealthManager.SetPlagueDebuffTrue();
            }
        }
    }
}
