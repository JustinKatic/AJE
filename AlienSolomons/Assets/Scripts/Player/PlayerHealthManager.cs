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

    void Start()
    {
        currentHealth.Value = maxHealth.Value;
        _healthTxt.text = currentHealth.Value.ToString();
    }

    void Update()
    {
        if (currentHealth.Value <= 0)
        {
            PlayerDeath.Raise();
        }
        if (currentHealth.Value > maxHealth.Value)
            currentHealth.Value = maxHealth.Value;
    }

    public void FloatingText(FloatVariable damage)
    {
        GameObject points = Instantiate(floatingDmg, transform.position, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-" + damage.Value.ToString();
    }

    public void HealPlayer(float heal)
    {
        currentHealth.Value += heal;
        _healthTxt.text = currentHealth.ToString();
    }
}
