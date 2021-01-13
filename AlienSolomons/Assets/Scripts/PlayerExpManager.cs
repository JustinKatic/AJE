using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExpManager : MonoBehaviour
{
    private float maxExp;
    private float currentExp;

    public ExpBar expBar;
    [SerializeField] float _expModifier;

    [SerializeField] GameObject _terraformCam;
    [SerializeField] GameObject _playerUpgradePanel;


    void Start()
    {
        maxExp = PlayerStats.instance.level1ExpNeeded;
        expBar.SetMaxExp(maxExp);
        PlayerStats.instance._currentExpNeededForLevel = maxExp;
        currentExp = PlayerStats.instance._playerExp;
        expBar.SetExp(currentExp);
    }

    void Update()
    {
        if (currentExp >= maxExp)
        {
            DisplayUpgradeScreen();
            PlayerStats.instance._playerLevel++;
            currentExp = 0;
            maxExp = maxExp + (maxExp * _expModifier);
            PlayerStats.instance._currentExpNeededForLevel = maxExp;
            expBar.SetMaxExp(maxExp);
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
