using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PickUpCurrency : MonoBehaviour
{
    [SerializeField] StringVariable TagOfObjectsAbleToPickMeUp;

    [SerializeField] FloatVariable PlayerInGameCurrency;
    [SerializeField] FloatVariable PlayerTakeBackToMenuCurrency;
    [SerializeField] FloatVariable CurrencyPickUpValue;
    [SerializeField] GameEvent UpdateCurrencyTextEvent;




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagOfObjectsAbleToPickMeUp.Value)
        {
            PlayerInGameCurrency.RuntimeValue += CurrencyPickUpValue.RuntimeValue;
            PlayerTakeBackToMenuCurrency.RuntimeValue += CurrencyPickUpValue.RuntimeValue;
            UpdateCurrencyTextEvent.Raise();
            gameObject.SetActive(false);
        }
    }
}
