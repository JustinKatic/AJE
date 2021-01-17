using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExpManager : MonoBehaviour
{
    private float currentExp;
    [SerializeField] FloatVariable[] _playerExpNeededToLvl;
    [SerializeField] IntVariable _playerLvl;
    private float _currentExpNeededForLevel;


    public ExpBar expBar;
    [SerializeField] float _expModifier;

    [SerializeField] GameObject _terraformCam;
    [SerializeField] GameObject _playerUpgradePanel;


    void Start()
    {
        expBar.SetMaxExp(_playerExpNeededToLvl[_playerLvl.Value].Value);
        currentExp = 0f;
        expBar.SetExp(currentExp);
    }

    void Update()
    {
        if (currentExp >= _playerExpNeededToLvl[_playerLvl.Value].Value)
        {
            DisplayUpgradeScreen();
            _playerLvl.Value++;
            currentExp = 0;

            _playerExpNeededToLvl[_playerLvl.Value].Value =
                _playerExpNeededToLvl[_playerLvl.Value].Value +
                (_playerExpNeededToLvl[_playerLvl.Value].Value * _expModifier);

            expBar.SetMaxExp(_playerExpNeededToLvl[_playerLvl.Value].Value);
            expBar.SetExp(currentExp);
        }
    }

    public void AddExp(float Exp)
    {
        currentExp += Exp;
        expBar.SetExp(currentExp);
    }

    private void DisplayUpgradeScreen()
    {
        GameStateManager.PauseGame();
        _terraformCam.SetActive(true);
        _playerUpgradePanel.SetActive(true);
    }
}
