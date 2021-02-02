using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExpManager : MonoBehaviour
{
    [System.Serializable]
    public class PlayerLevelDetails
    {
        public string name;
        public FloatVariable _playerExpNeededToLvl;
    }

    public PlayerLevelDetails[] playerLevelDetails;

    [SerializeField] FloatVariable currentExp;
    [SerializeField] FloatVariable MaxExp;

    [SerializeField] IntVariable _playerLvl;
    [SerializeField] GameEvent PlayerLeveldUp;
    [SerializeField] GameEvent ExpIncreased;

    void Awake()
    {
        currentExp.RuntimeValue = 0;
        _playerLvl.Value = 0;
        MaxExp.RuntimeValue = playerLevelDetails[_playerLvl.Value]._playerExpNeededToLvl.RuntimeValue;
    }

    private void Update()
    {
        if (currentExp.RuntimeValue >= playerLevelDetails[_playerLvl.Value]._playerExpNeededToLvl.RuntimeValue)
        {
            PlayerLeveldUp.Raise();
            LevelPlayerUp();
            ExpIncreased.Raise();
        }
    }

    public void LevelPlayerUp()
    {
        _playerLvl.Value++;
        currentExp.RuntimeValue = 0;  
        MaxExp.RuntimeValue = playerLevelDetails[_playerLvl.Value]._playerExpNeededToLvl.RuntimeValue;
    }
}
