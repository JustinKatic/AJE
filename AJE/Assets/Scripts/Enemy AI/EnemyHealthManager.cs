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
    [SerializeField] float MyMaxHealth;
    [SerializeField] ListOfTransforms _listOfEnemies;
    [SerializeField] GameEvent ExperienceIncreasedEvent;
    [SerializeField] bool IHaveAHealthBar;
    // [SerializeField] float PlayerCurrentExp;

    // [SerializeField] GameObject ExpObj;
    [SerializeField] GameObject CurrencyObj;


    [HideInInspector] public bool plagueDebuff;
    private float plagueDurationTimer;

    float plagueDebuffDuration;
    float plagueTickDamage;
    float plagueTickRate;
    private float plagueTickTimer;

    [SerializeField] ScriptableSoundObj DeathSound;

    [SerializeField] GameObject deathParticle;
    [SerializeField] GameObject model;
    private new Renderer renderer;
    private Material newMat;

    [SerializeField] GameObject plagueParticle;



    private void Start()
    {
        renderer = model.GetComponent<Renderer>();
        newMat = new Material(renderer.material);
        renderer.material = newMat;
    }

    private void OnEnable()
    {
        _currentHealth = MyMaxHealth;
        if (IHaveAHealthBar)
            healthBar.SetMaxHealth(MyMaxHealth);
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
        StartCoroutine(OnHurtEffect());
        _currentHealth -= damage;
        if (IHaveAHealthBar)
            healthBar.SetHealth(_currentHealth);
    }

    public void Death()
    {
        _listOfEnemies.RuntimeList.Remove(gameObject.transform.parent.transform);
        InstantiateCurrency(CurrencyObj);
        // InstantiateExpDrop(ExpObj);


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

    //public void InstantiateExpDrop(GameObject expObj)
    //{
    //    if (expObj)
    //        Instantiate(expObj, transform.position, transform.rotation);
    //    else
    //        Debug.Log("no Exp Obj added" + gameObject.name);
    //}

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
            plagueParticle.SetActive(true);
            plagueTickTimer += Time.deltaTime;
            plagueDurationTimer += Time.deltaTime;

            if (plagueTickTimer > plagueTickRate)
            {
                HurtEnemy(plagueTickDamage);
                FloatingTxt(plagueTickDamage, transform);
                plagueTickTimer = 0;
            }

            if (plagueDurationTimer > plagueDebuffDuration)
            {
                plagueDurationTimer = 0;
                plagueDebuff = false;
                plagueParticle.SetActive(false);
            }
        }
    }

    public void SetPlagueDebuffTrue(float tickDmg, float tickrate, float duration)
    {
        plagueDebuff = true;
        plagueDurationTimer = 0;
        plagueTickTimer = 0;
        plagueTickDamage = tickDmg;
        plagueTickRate = tickrate;
        plagueDebuffDuration = duration;
    }

    private void OnTriggerStay(Collider other)
    {
        if (plagueDebuff && other.gameObject.layer == 10)
            other.gameObject.GetComponent<EnemyHealthManager>().SetPlagueDebuffTrue(plagueTickDamage, plagueTickRate, plagueDebuffDuration);

    }
    public void FloatingTxt(float damage, Transform transformToSpawnTxtAt)
    {
        GameObject points = Instantiate(floatingDmg, transformToSpawnTxtAt.position, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-" + damage.ToString();
    }
    IEnumerator OnHurtEffect()
    {
        renderer.material.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(0.1f);
        renderer.material.DisableKeyword("_EMISSION");
    }
}
