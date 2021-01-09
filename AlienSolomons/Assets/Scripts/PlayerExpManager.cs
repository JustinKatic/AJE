using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExpManager : MonoBehaviour
{
    private float maxExp;
    private float currentExp;

    public ExpBar expBar;
    [SerializeField] float _expModifier;

    private UpgradeManager _upgradeManager;


    void Start()
    {
        _upgradeManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UpgradeManager>();

        maxExp = GameStats.instance.level1ExpNeeded;
        expBar.SetMaxExp(maxExp);
        GameStats.instance._currentExpNeededForLevel = maxExp;
        currentExp = GameStats.instance._playerExp;
        expBar.SetExp(currentExp);
    }

    void Update()
    {
        if (currentExp >= maxExp)
        {
            _upgradeManager.DisplayUpgradeScreen();
            GameStats.instance._playerLevel++;
            currentExp = 0;
            maxExp = maxExp + (maxExp * _expModifier);
            GameStats.instance._currentExpNeededForLevel = maxExp;
            expBar.SetMaxExp(maxExp);
            expBar.SetExp(currentExp);
        }        
    }

    public void AddExp(float Exp)
    {
        currentExp += Exp;
        expBar.SetExp(currentExp);
    }
}
