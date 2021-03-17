using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <DataVariablesToSave>
/// variables that we can use to load and save from a file
[System.Serializable]
public class MenuData
{
    [HideInInspector] public bool dmgTowerSelection;
    [HideInInspector] public bool plagueTowerSelection;
    [HideInInspector] public bool slowTowerSelection;
    [HideInInspector] public bool vampireTowerSelection;

    [HideInInspector] public bool damageTowerslot1;
    [HideInInspector] public bool slowTowerslot1;
    [HideInInspector] public bool vampireTowerslot1;
    [HideInInspector] public bool plagueTowerslot1;

    [HideInInspector] public bool damageTowerslot2;
    [HideInInspector] public bool slowTowerslot2;
    [HideInInspector] public bool vampireTowerslot2;
    [HideInInspector] public bool plagueTowerslot2;

    [HideInInspector] public bool damageTowerslot3;
    [HideInInspector] public bool slowTowerslot3;
    [HideInInspector] public bool vampireTowerslot3;
    [HideInInspector] public bool plagueTowerslot3;

    [HideInInspector] public bool towerslot1Equipped;
    [HideInInspector] public bool towerslot2Equipped;
    [HideInInspector] public bool towerslot3Equipped;

    [HideInInspector] public bool damageTowerActiveState;
    [HideInInspector] public bool slowTowerActiveState;
    [HideInInspector] public bool plagueTowerActiveState;
    [HideInInspector] public bool nectoricTowerActiveState;


    public MenuData(SaveLoadMenu saveLoadMenu)
    {
        //tower selection
        dmgTowerSelection = saveLoadMenu.damageTowerSelection.activeSelf;
        plagueTowerSelection = saveLoadMenu.plagueTowerSelection.activeSelf;
        slowTowerSelection = saveLoadMenu.slowTowerSelection.activeSelf;
        vampireTowerSelection = saveLoadMenu.vampireTowerSelection.activeSelf;

        //towerSlot1
        damageTowerslot1 = saveLoadMenu.damageTowerslot1.activeSelf;
        slowTowerslot1 = saveLoadMenu.slowTowerslot1.activeSelf;
        vampireTowerslot1 = saveLoadMenu.vampireTowerslot1.activeSelf;
        plagueTowerslot1 = saveLoadMenu.plagueTowerslot1.activeSelf;
        //towerSlot2
        damageTowerslot2 = saveLoadMenu.damageTowerslot2.activeSelf;
        slowTowerslot2 = saveLoadMenu.slowTowerslot2.activeSelf;
        vampireTowerslot2 = saveLoadMenu.vampireTowerslot2.activeSelf;
        plagueTowerslot2 = saveLoadMenu.plagueTowerslot2.activeSelf;
        //towerSlot3
        damageTowerslot3 = saveLoadMenu.damageTowerslot3.activeSelf;
        slowTowerslot3 = saveLoadMenu.slowTowerslot3.activeSelf;
        vampireTowerslot3 = saveLoadMenu.vampireTowerslot3.activeSelf;
        plagueTowerslot3 = saveLoadMenu.plagueTowerslot3.activeSelf;

        //towerslot Equiped
        towerslot1Equipped = saveLoadMenu.towerslot1.GetComponent<TowerSlots>().slotEquiped;
        towerslot2Equipped = saveLoadMenu.towerslot2.GetComponent<TowerSlots>().slotEquiped;
        towerslot3Equipped = saveLoadMenu.towerslot3.GetComponent<TowerSlots>().slotEquiped;

        //tower active state
        damageTowerActiveState = saveLoadMenu.damageTowerActiveState.Value;
        slowTowerActiveState = saveLoadMenu.slowTowerActiveState.Value;
        plagueTowerActiveState = saveLoadMenu.plagueTowerActiveState.Value;
        nectoricTowerActiveState = saveLoadMenu.nectoricTowerActiveState.Value;
    }
}
