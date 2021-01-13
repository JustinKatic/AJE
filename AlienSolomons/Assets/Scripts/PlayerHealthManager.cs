using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles player health.
/// </summary>
public class PlayerHealthManager : MonoBehaviour
{
    private float maxHealth;
    private float currentHealth;

    public HealthBar healthBar;
    public GameObject defeatScreen;


    void Start()
    {
        maxHealth = PlayerStats.instance._playerMaxHealth;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            defeatScreen.SetActive(true);
        }

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }
    public void HurtPlayer(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void HealPlayer(float heal)
    {
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);
    }
}
