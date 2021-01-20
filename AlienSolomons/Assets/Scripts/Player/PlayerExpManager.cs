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
    [SerializeField] IntVariable _playerLvl;

    [SerializeField] GameEvent PlayerLeveldUp;

    [SerializeField] bool IHaveExpBar;
    [SerializeField] ExpBar expBar;



    void Start()
    {
        _playerLvl.Value = 0;
        currentExp.Value = 0f;
        if (IHaveExpBar)
        {
            expBar.SetMaxExp(playerLevelDetails[_playerLvl.Value]._playerExpNeededToLvl.Value);
            expBar.SetExp(currentExp.Value);
        }
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
    }

    public void LevelPlayerUp()
    {
        _playerLvl.Value++;
        if (IHaveExpBar)
            expBar.SetMaxExp(playerLevelDetails[_playerLvl.Value]._playerExpNeededToLvl.Value);
        currentExp.Value = 0;
    }

    public void UpdateExpBar()
    {
        if (IHaveExpBar)
            expBar.SetExp(currentExp.Value);
    }
}
