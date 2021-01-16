using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealthManager : MonoBehaviour
{
    private float maxHealth;
    private float currentHealth;

    public HealthBar healthBar;
    public GameObject defeatScreen;

    [SerializeField] GameObject floatingDmg;
    [SerializeField] TextMeshPro _healthTxt;


    void Start()
    {
        maxHealth = PlayerStats.instance._playerMaxHealth;
        currentHealth = maxHealth;
        _healthTxt.text = currentHealth.ToString();
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            EnemyManager.instance._enemies.Clear();
            defeatScreen.SetActive(true);
        }

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }
    public void HurtPlayer(float damage)
    {
        currentHealth -= damage;
        GameObject points = Instantiate(floatingDmg, transform.position, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-" + damage.ToString();
        healthBar.SetHealth(currentHealth);
        _healthTxt.text = currentHealth.ToString();
    }

    public void HealPlayer(float heal)
    {
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);
        _healthTxt.text = currentHealth.ToString();
    }
}
