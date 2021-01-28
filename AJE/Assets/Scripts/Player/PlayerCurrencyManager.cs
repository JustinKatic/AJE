using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrencyManager : MonoBehaviour
{
    [SerializeField] FloatVariable playerInGameCurrency;
    [SerializeField] FloatVariable PlayerTakeBackToMenuCurrency;
    [SerializeField] FloatVariable PlayerMenuCurrency;

    [SerializeField] GameEvent InGameCurrencyIncreased;
    [SerializeField] GameEvent TakeBackToMenuCurrencyIncreased;

    [SerializeField] GameEvent TakeBackToMenuCurrencyDecreased;
    [SerializeField] GameEvent InGameCurrencyDecreased;





    private void Awake()
    {
        playerInGameCurrency.Value = 0;
        PlayerTakeBackToMenuCurrency.Value = 0;
    }

    public void IncreaseInGameCurrency(FloatVariable valueToIncreaseBy)
    {
        playerInGameCurrency.Value += valueToIncreaseBy.Value;
        InGameCurrencyIncreased.Raise();
    }
    public void IncreasePlayerTakeBackToMenuCurrency(FloatVariable valueToIncreaseBy)
    {
        PlayerTakeBackToMenuCurrency.Value += valueToIncreaseBy.Value;
        TakeBackToMenuCurrencyIncreased.Raise();
    }
    public void DecreaseInGameCurrency(FloatVariable valueToDecreaseBy)
    {
        playerInGameCurrency.Value -= valueToDecreaseBy.Value;
        InGameCurrencyDecreased.Raise();
    }

    public void DecreasePlayerTakeBackToMenuCurrency(FloatVariable valueToDecreaseBy)
    {
        PlayerTakeBackToMenuCurrency.Value -= valueToDecreaseBy.Value;
        TakeBackToMenuCurrencyDecreased.Raise();
    }
}
