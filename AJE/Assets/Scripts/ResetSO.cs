using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSO : MonoBehaviour
{
    [SerializeField] FloatVariable playerInGameCurrency;
    [SerializeField] IntVariable nextWave;

    [SerializeField] GameEvent UpdateCurrency;

    private void OnEnable()
    {
        nextWave.RuntimeValue = nextWave.Value;
        playerInGameCurrency.RuntimeValue = playerInGameCurrency.Value;
        UpdateCurrency.Raise();
    }
}
