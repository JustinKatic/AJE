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
    [SerializeField] GameEvent PlayerHealthDecreased;
    [SerializeField] GameEvent PlayerHealthIncreased;



    void Awake()
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
        {
            currentHealth.Value = maxHealth.Value;
            PlayerHealthIncreased.Raise();
        }
    }

    public void FloatingText(FloatVariable damage)
    {
        GameObject points = Instantiate(floatingDmg, transform.position, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-" + damage.Value.ToString();
    }

    public void DamagePlayer(FloatVariable damage)
    {
        currentHealth.Value -= damage.Value;
        PlayerHealthDecreased.Raise();
    }

    public void HealPlayer(FloatVariable heal)
    {
        currentHealth.Value += heal.Value;
        PlayerHealthIncreased.Raise();
    }
}
