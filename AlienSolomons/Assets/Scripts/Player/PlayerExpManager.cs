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
    [SerializeField] GameEvent ExpAddedToPlayer;



    void Awake()
    {
        currentExp.Value = 0;
        MaxExp.Value = playerLevelDetails[_playerLvl.Value]._playerExpNeededToLvl.Value;
    }

    void Update()
    {
        if (currentExp.Value >= playerLevelDetails[_playerLvl.Value]._playerExpNeededToLvl.Value)
        {
            PlayerLeveldUp.Raise();
        }
    }

    public void AddPlayerExp(FloatVariable ExpToBeAdded)
    {
        currentExp.Value += ExpToBeAdded.Value;
        ExpAddedToPlayer.Raise();
    }

    public void LevelPlayerUp()
    {
        _playerLvl.Value++;
        currentExp.Value = 0;
        MaxExp.Value = playerLevelDetails[_playerLvl.Value]._playerExpNeededToLvl.Value;
    }
}
