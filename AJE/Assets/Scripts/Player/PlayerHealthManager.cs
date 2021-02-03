using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public FloatVariable maxHealth;
    public FloatVariable currentHealth;

    [SerializeField] GameObject floatingDmg;
    [SerializeField] TextMeshPro _healthTxt;
    [SerializeField] GameEvent PlayerDeath;
    [SerializeField] GameEvent UpdatePlayerHealth;




    void Awake()
    {
        currentHealth.RuntimeValue = maxHealth.RuntimeValue;
        _healthTxt.text = currentHealth.RuntimeValue.ToString();
    }

    void Update()
    {
        if (currentHealth.RuntimeValue <= 0)
        {
            PlayerDeath.Raise();
        }
        if (currentHealth.RuntimeValue > maxHealth.RuntimeValue)
        {
            currentHealth.RuntimeValue = maxHealth.RuntimeValue;
            UpdatePlayerHealth.Raise();
        }



    }

    public void FloatingText(FloatVariable damage)
    {
        GameObject points = Instantiate(floatingDmg, transform.position, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-" + damage.RuntimeValue.ToString();
    }

    public void FloatingTextPlus(FloatVariable heal)
    {
        GameObject points = Instantiate(floatingDmg, transform.position, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = "+" + heal.RuntimeValue.ToString();
    }
}
