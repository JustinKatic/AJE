using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ExpBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;

    [SerializeField] FloatVariable MyCurrentExp;
    [SerializeField] FloatVariable MyMaxExp;


    private void Start()
    {
        UpdateExpBar();
    }

    public void UpdateExpBar()
    {
        slider.maxValue = MyMaxExp.Value;
        slider.value = MyCurrentExp.Value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}