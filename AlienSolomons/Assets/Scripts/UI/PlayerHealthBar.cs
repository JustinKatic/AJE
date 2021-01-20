using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;
    [SerializeField] FloatVariable MyCurrentHealth;
    [SerializeField] FloatVariable MyMaxHealth;
    [SerializeField] TextMeshPro _healthTxt;

    public void UpdateHealthBar()
    {
        slider.maxValue = MyMaxHealth.Value;
        slider.value = MyCurrentHealth.Value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        _healthTxt.text = MyCurrentHealth.Value.ToString();
    }
}
