using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerHealth : MonoBehaviour
{
    public float _currentHealth;

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameObject floatingDmg;
    [SerializeField] float myMaxHealth;

    [SerializeField] bool IHaveAHealthBar;
    [SerializeField] ScriptableSoundObj DeathSound;

    [SerializeField] GameObject deathParticle;

    [SerializeField] FloatVariable myTowerCost;
    [SerializeField] FloatVariable inGameCurrency;

    [SerializeField] GameEvent UpdateCurrency;





    private void OnEnable()
    {
        _currentHealth = myMaxHealth;
        if (IHaveAHealthBar)
            healthBar.SetMaxHealth(myMaxHealth);
    }
    private void Update()
    {
        if (_currentHealth <= 0)
            Death();
    }

    public void HurtEnemy(float damage, bool displayDmg)
    {
        _currentHealth -= damage;
        if (displayDmg)
            FloatingTxt(damage, transform, "-", Color.white);
        if (IHaveAHealthBar)
            healthBar.SetHealth(_currentHealth);
    }
    public void Death()
    {
        if (DeathSound)
            DeathSound.Play();
        else
            Debug.Log("no death sound added" + gameObject.name);

        InstantiateDeathParticle(deathParticle);
        gameObject.SetActive(false);
        inGameCurrency.RuntimeValue += myTowerCost.Value;
        UpdateCurrency.Raise();

    }
    public void InstantiateDeathParticle(GameObject deathParticle)
    {
        if (deathParticle)
            Instantiate(deathParticle, transform.position, transform.rotation);
        else
            Debug.Log("no deathParticle Obj added" + gameObject.name);
    }
    public void FloatingTxt(float damage, Transform transformToSpawnTxtAt, string type, Color32 color)
    {
        GameObject points = ObjectPooler.SharedInstance.GetPooledObject("FloatingTxt");
        points.transform.position = transformToSpawnTxtAt.position;
        points.transform.rotation = Quaternion.identity;
        TextMeshPro txt = points.transform.GetChild(0).GetComponent<TextMeshPro>();
        txt.text = type + damage.ToString();
        txt.color = color;
        points.SetActive(true);
    }

}

