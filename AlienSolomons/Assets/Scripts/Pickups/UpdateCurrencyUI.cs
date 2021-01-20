using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UpdateCurrencyUI : MonoBehaviour
{
    [SerializeField] FloatVariable CurrencyToUpdate;
    [SerializeField] Text CurrencyToUpdateText;
    [SerializeField] string CurrencyType;

    private void Start()
    {
        CurrencyToUpdate.Value = 0;
    }

    private void Update()
    {
        CurrencyToUpdateText.text = CurrencyType + CurrencyToUpdate.Value.ToString();
    }

}
