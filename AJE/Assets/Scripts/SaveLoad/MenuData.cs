using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <DataVariablesToSave>
/// variables that we can use to load and save from a file
[System.Serializable]
public class MenuData
{
    [HideInInspector] public bool damageTowerActiveState;
    [HideInInspector] public bool slowTowerActiveState;
    [HideInInspector] public bool plagueTowerActiveState;
    [HideInInspector] public bool nectoricTowerActiveState;


    public MenuData(SaveLoadMenu saveLoadMenu)
    {      
        //tower active state
        damageTowerActiveState = saveLoadMenu.damageTowerActiveState.Value;
        slowTowerActiveState = saveLoadMenu.slowTowerActiveState.Value;
        plagueTowerActiveState = saveLoadMenu.plagueTowerActiveState.Value;
        nectoricTowerActiveState = saveLoadMenu.nectoricTowerActiveState.Value;
    }
}
