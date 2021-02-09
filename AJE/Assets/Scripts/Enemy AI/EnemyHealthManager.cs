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
    [SerializeField] GameEvent ExperienceIncreasedEvent;
    [SerializeField] bool IHaveAHealthBar;
    [SerializeField] FloatVariable PlayerCurrentExp;




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
        _currentHealth = MyMaxHealth.RuntimeValue;
        if (IHaveAHealthBar)
            healthBar.SetMaxHealth(MyMaxHealth.RuntimeValue);
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
        if (IHaveAHealthBar)
            healthBar.SetHealth(_currentHealth);
    }

    void Death()
    {
        _listOfEnemies.RuntimeList.Remove(gameObject.transform);
        InstantiateCurrency();
        InstantiateExpDrop();
        gameObject.SetActive(false);
    }

    public void InstantiateCurrency()
    {
        GameObject currency = ObjectPooler.SharedInstance.GetPooledObject("Currency");
        currency.transform.position = gameObject.transform.position;
        currency.transform.rotation = gameObject.transform.rotation;
        currency.SetActive(true);
    }

    virtual public void InstantiateExpDrop()
    {

    }

    public void PlagueDebuff()
    {
        if (plagueDebuff == true)
        {
            plagueTickTimer += Time.deltaTime;
            plagueDurationTimer += Time.deltaTime;

            if (plagueTickTimer > plagueTickRate.RuntimeValue)
            {
                HurtEnemy(plagueTickDamage.RuntimeValue);
                FloatingTxt(plagueTickDamage.RuntimeValue, transform);
                plagueTickTimer = 0;
            }

            if (plagueDurationTimer > plagueDebuffDuration.RuntimeValue)
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
    public void FloatingTxt(float damage, Transform transformToSpawnTxtAt)
    {
        GameObject points = Instantiate(floatingDmg, transformToSpawnTxtAt.position, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-" + damage.ToString();
    }
}
