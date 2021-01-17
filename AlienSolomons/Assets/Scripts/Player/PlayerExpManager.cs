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

    public ExpBar expBar;

    void Start()
    {
        _playerLvl.Value = 0;
        currentExp.Value = 0f;
        expBar.SetMaxExp(playerLevelDetails[_playerLvl.Value]._playerExpNeededToLvl.Value);
        expBar.SetExp(currentExp.Value);
    }

    void Update()
    {
        if (currentExp.Value >= playerLevelDetails[_playerLvl.Value]._playerExpNeededToLvl.Value)
        {
            Debug.Log("PlayerLeveled");
            _playerLvl.Value++;
            expBar.SetMaxExp(playerLevelDetails[_playerLvl.Value]._playerExpNeededToLvl.Value);
            currentExp.Value = 0;
            expBar.SetExp(currentExp.Value);
        }
    }

    public void AddExp(float Exp)
    {
        currentExp.Value += Exp;
        expBar.SetExp(currentExp.Value);
    }
}
