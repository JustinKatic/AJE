using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadMenu : MonoBehaviour
{

    public MenuData data;

    public BoolVariable damageTowerActiveState;
    public BoolVariable slowTowerActiveState;
    public BoolVariable plagueTowerActiveState;
    public BoolVariable nectoricTowerActiveState;


    private void Awake()
    {
        Load();
    }
    private void OnDisable()
    {
        Save();
    }


    public void Save()
    {
        data = new MenuData(this);
        SaveLoad.Save(data, "PlayerData");
    }

    public void Load()
    {
        if (SaveLoad.SaveExists("PlayerData"))
        {
            data = SaveLoad.Load<MenuData>("PlayerData");

            //Tower active state
            damageTowerActiveState.Value = data.damageTowerActiveState;
            slowTowerActiveState.Value = data.slowTowerActiveState;
            plagueTowerActiveState.Value = data.plagueTowerActiveState;
            nectoricTowerActiveState.Value = data.nectoricTowerActiveState;
        }
    }
}
