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
        currentExp.Value = 0;
        _playerLvl.Value = 0;
        MaxExp.Value = playerLevelDetails[_playerLvl.Value]._playerExpNeededToLvl.Value;
    }

    private void Update()
    {
        if (currentExp.Value >= playerLevelDetails[_playerLvl.Value]._playerExpNeededToLvl.Value)
        {
            PlayerLeveldUp.Raise();
            LevelPlayerUp();
            ExpIncreased.Raise();
        }
    }

    public void LevelPlayerUp()
    {
        _playerLvl.Value++;
        currentExp.Value = 0;  
        MaxExp.Value = playerLevelDetails[_playerLvl.Value]._playerExpNeededToLvl.Value;
    }
}
