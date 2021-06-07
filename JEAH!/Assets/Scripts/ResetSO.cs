using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSO : MonoBehaviour
{
    [SerializeField] IntVariable purchasedCurrency;
    [SerializeField] FloatVariable playerInGameCurrency;
    [SerializeField] FloatVariable ActiveEnemies;


    [SerializeField] IntVariable nextWave;

    [SerializeField] GameEvent UpdateCurrency;

    [SerializeField] BoolVariable isPlayerInvincible;

    private void OnEnable()
    {
        Time.timeScale = 1;

        ActiveEnemies.RuntimeValue = ActiveEnemies.Value;
        nextWave.RuntimeValue = nextWave.Value;
        playerInGameCurrency.RuntimeValue = playerInGameCurrency.Value + purchasedCurrency.Value;
        isPlayerInvincible.Value = false;
        UpdateCurrency.Raise();
    }
}
