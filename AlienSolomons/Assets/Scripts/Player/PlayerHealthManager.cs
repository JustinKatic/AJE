using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealthManager : MonoBehaviour
{
    public FloatVariable maxHealth;
    public float currentHealth;

    public HealthBar healthBar;
    [SerializeField] GameObject floatingDmg;
    [SerializeField] TextMeshPro _healthTxt;
    [SerializeField] GameEvent PlayerDeath;

    void Start()
    {
        currentHealth = maxHealth.Value;
        _healthTxt.text = currentHealth.ToString();
        healthBar.SetMaxHealth(maxHealth.Value);
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            if (gameObject.tag == "Player")
                PlayerDeath.Raise();
        }

        if (currentHealth > maxHealth.Value)
            currentHealth = maxHealth.Value;
    }

    public void HurtPlayer(FloatVariable damage)
    {
        currentHealth -= damage.Value;
    }

    public void FloatingText(FloatVariable damage)
    {
        GameObject points = Instantiate(floatingDmg, transform.position, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-" + damage.Value.ToString();
    }


    public void UpdateHealthBarAndText()
    {
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
