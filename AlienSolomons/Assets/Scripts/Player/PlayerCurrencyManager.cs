using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrencyManager : MonoBehaviour
{
    [SerializeField] FloatVariable playerInGameCurrency;
    [SerializeField] FloatVariable PlayerTakeBackToMenuCurrency;
    [SerializeField] FloatVariable PlayerMenuCurrency;

    [SerializeField] GameEvent UpdateInGameCurrencyTxt;
    [SerializeField] GameEvent UpdateTakeBackToMenuCurrencyTxt;




    private void Awake()
    {
        playerInGameCurrency.Value = 0;
        PlayerTakeBackToMenuCurrency.Value = 0;
    }

    public void IncreaseInGameCurrency(FloatVariable valueToIncreaseBy)
    {
        playerInGameCurrency.Value += valueToIncreaseBy.Value;
        UpdateInGameCurrencyTxt.Raise();
    }
    public void IncreasePlayerTakeBackToMenuCurrency(FloatVariable valueToIncreaseBy)
    {
        PlayerTakeBackToMenuCurrency.Value += valueToIncreaseBy.Value;
        UpdateTakeBackToMenuCurrencyTxt.Raise();
    }
    public void DecreaseInGameCurrency(FloatVariable valueToDecreaseBy)
    {
        playerInGameCurrency.Value -= valueToDecreaseBy.Value;
        UpdateTakeBackToMenuCurrencyTxt.Raise();
    }

    public void DecreasePlayerTakeBackToMenuCurrency(FloatVariable valueToDecreaseBy)
    {
        PlayerTakeBackToMenuCurrency.Value -= valueToDecreaseBy.Value;
        UpdateTakeBackToMenuCurrencyTxt.Raise();
    }
}
