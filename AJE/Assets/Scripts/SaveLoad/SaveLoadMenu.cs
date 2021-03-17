using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadMenu : MonoBehaviour
{

    public MenuData data;

    [Header("Tower Selection")]
    public GameObject damageTowerSelection;
    public GameObject slowTowerSelection;
    public GameObject plagueTowerSelection;
    public GameObject vampireTowerSelection;

    [Header("TowerSlot1")]
    public GameObject damageTowerslot1;
    public GameObject slowTowerslot1;
    public GameObject vampireTowerslot1;
    public GameObject plagueTowerslot1;

    [Header("TowerSlot2")]
    public GameObject damageTowerslot2;
    public GameObject slowTowerslot2;
    public GameObject vampireTowerslot2;
    public GameObject plagueTowerslot2;

    [Header("TowerSlot3")]
    public GameObject damageTowerslot3;
    public GameObject slowTowerslot3;
    public GameObject vampireTowerslot3;
    public GameObject plagueTowerslot3;

    public GameObject towerslot1;
    public GameObject towerslot2;
    public GameObject towerslot3;

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

            //Tower Selection
            damageTowerSelection.SetActive(data.dmgTowerSelection);
            slowTowerSelection.SetActive(data.slowTowerSelection);
            plagueTowerSelection.SetActive(data.plagueTowerSelection);
            vampireTowerSelection.SetActive(data.vampireTowerSelection);

            //Towers slot 1
            damageTowerslot1.SetActive(data.damageTowerslot1);
            slowTowerslot1.SetActive(data.slowTowerslot1);
            plagueTowerslot1.SetActive(data.plagueTowerslot1);
            vampireTowerslot1.SetActive(data.vampireTowerslot1);

            //Towers slot 2
            damageTowerslot2.SetActive(data.damageTowerslot2);
            slowTowerslot2.SetActive(data.slowTowerslot2);
            plagueTowerslot2.SetActive(data.plagueTowerslot2);
            vampireTowerslot2.SetActive(data.vampireTowerslot2);

            //Towers slot 3
            damageTowerslot3.SetActive(data.damageTowerslot3);
            slowTowerslot3.SetActive(data.slowTowerslot3);
            plagueTowerslot3.SetActive(data.plagueTowerslot3);
            vampireTowerslot3.SetActive(data.vampireTowerslot3);

            //towerSlots Equiped
            towerslot1.GetComponent<TowerSlots>().slotEquiped = data.towerslot1Equipped;
            towerslot2.GetComponent<TowerSlots>().slotEquiped = data.towerslot2Equipped;
            towerslot3.GetComponent<TowerSlots>().slotEquiped = data.towerslot3Equipped;

            //Tower active state
            damageTowerActiveState.Value = data.damageTowerActiveState;
            slowTowerActiveState.Value = data.slowTowerActiveState;
            plagueTowerActiveState.Value = data.plagueTowerActiveState;
            nectoricTowerActiveState.Value = data.nectoricTowerActiveState;
        }
    }
}
