using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetcurrency : MonoBehaviour
{
    [SerializeField] FloatVariable playerInGameCurrency;
    [SerializeField] GameEvent UpdateCurrency;

    private void OnEnable()
    {
        playerInGameCurrency.RuntimeValue = playerInGameCurrency.Value;
        UpdateCurrency.Raise();
    }
}
