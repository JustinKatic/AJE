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
    [SerializeField] GameEvent ExperienceIncreasedEvent;
    [SerializeField] bool IHaveAHealthBar;
    [SerializeField] FloatVariable PlayerCurrentExp;

    [SerializeField] GameObject ExpObj;
    [SerializeField] GameObject CurrencyObj;


    [HideInInspector] public bool plagueDebuff;
    private float plagueDurationTimer;
    [SerializeField] FloatVariable plagueDebuffDuration;
    [SerializeField] FloatVariable plagueTickDamage;

    [SerializeField] FloatVariable plagueTickRate;
    private float plagueTickTimer;

    [SerializeField] ScriptableSoundObj DeathSound;

    [SerializeField] GameObject deathParticle;
    [SerializeField] GameObject model;
    private Renderer mat;
    private Material newMat;



    private void Start()
    {
        mat = model.GetComponent<Renderer>();

        newMat = new Material(mat.material);
        mat.material = newMat;
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

        mat.material.EnableKeyword("_EMISSION");

    }

    public void Death()
    {
        _listOfEnemies.RuntimeList.Remove(gameObject.transform.parent.transform);
        InstantiateCurrency(CurrencyObj);
        InstantiateExpDrop(ExpObj);


        if (DeathSound)
            DeathSound.Play();
        else
            Debug.Log("no death sound added" + gameObject.name);

        InstantiateDeathParticle(deathParticle);

        gameObject.SetActive(false);
    }

    public void InstantiateCurrency(GameObject CurrencyObj)
    {
        if (CurrencyObj)
            Instantiate(CurrencyObj, transform.position, transform.rotation);
        else
            Debug.Log("no currency Obj added" + gameObject.name);

    }

    public void InstantiateExpDrop(GameObject expObj)
    {
        if (expObj)
            Instantiate(expObj, transform.position, transform.rotation);
        else
            Debug.Log("no Exp Obj added" + gameObject.name);
    }

    public void InstantiateDeathParticle(GameObject deathParticle)
    {
        if (deathParticle)
            Instantiate(deathParticle, transform.position, transform.rotation);
        else
            Debug.Log("no deathParticle Obj added" + gameObject.name);
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
