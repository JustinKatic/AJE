using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealthManager : MonoBehaviour
{
    public FloatVariable maxHealth;
    public FloatVariable currentHealth;

    public HealthBar healthBar;
    public GameObject defeatScreen;

    [SerializeField] GameObject floatingDmg;
    [SerializeField] TextMeshPro _healthTxt;

    [SerializeField] ListOfTransforms ListOfEnemies;


    void Start()
    {       
        currentHealth.Value = maxHealth.Value;
        _healthTxt.text = currentHealth.Value.ToString();
        healthBar.SetMaxHealth(maxHealth.Value);
    }

    void Update()
    {
        if (currentHealth.Value <= 0)
        {
            gameObject.SetActive(false);
            ListOfEnemies.List.Clear();
            defeatScreen.SetActive(true);
        }

        if (currentHealth.Value > maxHealth.Value)
            currentHealth.Value = maxHealth.Value;
    }
    public void HurtPlayer(float damage)
    {
        currentHealth.Value -= damage;
        GameObject points = Instantiate(floatingDmg, transform.position, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-" + damage.ToString();
        healthBar.SetHealth(currentHealth.Value);
        _healthTxt.text = currentHealth.Value.ToString();
    }

    public void HealPlayer(float heal)
    {
        currentHealth.Value += heal;
        healthBar.SetHealth(currentHealth.Value);
        _healthTxt.text = currentHealth.Value.ToString();
    }
}
