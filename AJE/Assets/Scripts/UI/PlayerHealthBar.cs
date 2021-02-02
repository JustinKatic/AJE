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
    private void Start()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        slider.maxValue = MyMaxHealth.RuntimeValue;
        slider.value = MyCurrentHealth.RuntimeValue;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        _healthTxt.text = MyCurrentHealth.RuntimeValue.ToString();
    }
}
