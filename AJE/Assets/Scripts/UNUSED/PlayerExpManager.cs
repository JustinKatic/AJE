using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExpManager : MonoBehaviour
{

    [SerializeField] FloatVariable[] _playerExpNeededToLvl;



    [SerializeField] FloatVariable currentExp;
    [SerializeField] FloatVariable MaxExp;

    [SerializeField] IntVariable _playerLvl;
    [SerializeField] GameEvent PlayerLeveldUp;
    [SerializeField] GameEvent ExpIncreased;

    void Awake()
    {
        currentExp.RuntimeValue = 0;
        _playerLvl.Value = 0;
        MaxExp.RuntimeValue = _playerExpNeededToLvl[_playerLvl.Value].RuntimeValue;
    }

    private void Update()
    {
        if (currentExp.RuntimeValue >= _playerExpNeededToLvl[_playerLvl.Value].RuntimeValue)
        {
            PlayerLeveldUp.Raise();
            LevelPlayerUp();
            ExpIncreased.Raise();
        }
    }

    public void LevelPlayerUp()
    {
        currentExp.RuntimeValue = currentExp.RuntimeValue -= MaxExp.RuntimeValue;
        _playerLvl.Value++;
        MaxExp.RuntimeValue = _playerExpNeededToLvl[_playerLvl.Value].RuntimeValue;
    }
}
