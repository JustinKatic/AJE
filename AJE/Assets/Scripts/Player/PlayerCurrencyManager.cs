using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrencyManager : MonoBehaviour
{
    [SerializeField] FloatVariable playerInGameCurrency;
    [SerializeField] FloatVariable PlayerTakeBackToMenuCurrency;

    private void Awake()
    {
        playerInGameCurrency.Value = 0;
        PlayerTakeBackToMenuCurrency.Value = 0;
    }
}
