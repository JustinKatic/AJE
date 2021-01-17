using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetValuesDefaultOnLoad : MonoBehaviour
{
    [SerializeField] FloatVariable PlayerInGameCurrency;
    [SerializeField] ListOfTransforms ListOfEnemies;

    private void Awake()
    {
        ListOfEnemies.List.Clear();
        PlayerInGameCurrency.Value = 0;
    }
}
