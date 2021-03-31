using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyPerWave : MonoBehaviour
{
    private void Start()
    {
        
    }

    [System.Serializable]
    public class Wave
    {
        public string name;
        public int value;
    }

    [SerializeField] IntVariable nextWaveNum;
    [SerializeField] Wave[] wave;


    [SerializeField] FloatVariable PlayerInGameCurrency;
    [SerializeField] GameEvent UpdateCurrencyTextEvent;

    public void AddCurrency()
    {
        PlayerInGameCurrency.RuntimeValue += wave[nextWaveNum.RuntimeValue - 1].value;
        UpdateCurrencyTextEvent.Raise();
    }
}
