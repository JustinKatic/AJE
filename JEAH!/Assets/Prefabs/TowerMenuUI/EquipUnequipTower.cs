using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipUnequipTower : MonoBehaviour
{
    [SerializeField] GameObject myTowerInSelection;
    [SerializeField] GameObject myResourceMenu;

    [SerializeField] GameObject equipButton;
    [SerializeField] GameObject unEquipButton;


    [SerializeField] BoolVariable myTowerActiveState;



    [SerializeField] GameObject myTowerInSlot1;
    [SerializeField] GameObject myTowerInSlot2;
    [SerializeField] GameObject myTowerInSlot3;

    [SerializeField] TowerSlots towerSlots1;
    [SerializeField] TowerSlots towerSlots2;
    [SerializeField] TowerSlots towerSlots3;

    public bool slot1Selected;
    public bool slot2Selected;
    public bool slot3Selected;

    public void Slot1SelectedTrue()
    {
        slot1Selected = true;
        slot2Selected = false;
        slot3Selected = false;

    }
    public void Slot2SelectedTrue()
    {
        slot1Selected = false;
        slot2Selected = true;
        slot3Selected = false;
    }
    public void Slot3SelectedTrue()
    {
        slot1Selected = false;
        slot2Selected = false;
        slot3Selected = true;
    }


    public void EquipTower()
    {
        if (!towerSlots1.slotEquiped)
        {
            myTowerInSelection.SetActive(false);
            myTowerInSlot1.SetActive(true);
            towerSlots1.slotEquiped = true;
            myTowerActiveState.Value = true;
            myResourceMenu.SetActive(false);
            equipButton.SetActive(false);
        }
        else if (!towerSlots2.slotEquiped)
        {
            myTowerInSelection.SetActive(false);
            myTowerInSlot2.SetActive(true);
            towerSlots2.slotEquiped = true;
            myTowerActiveState.Value = true;
            myResourceMenu.SetActive(false);
            equipButton.SetActive(false);
        }
        else if (!towerSlots3.slotEquiped)
        {
            myTowerInSelection.SetActive(false);
            myTowerInSlot3.SetActive(true);
            towerSlots3.slotEquiped = true;
            myTowerActiveState.Value = true;
            myResourceMenu.SetActive(false);
            equipButton.SetActive(false);
        }
    }


    public void UnEquip()
    {
        if (slot1Selected)
        {
            myTowerActiveState.Value = false;
            myTowerInSelection.SetActive(true);
            towerSlots1.slotEquiped = false;
            myTowerInSlot1.SetActive(false);
            myResourceMenu.SetActive(false);
            unEquipButton.SetActive(false);
        }
        else if (slot2Selected)
        {
            myTowerActiveState.Value = false;
            myTowerInSelection.SetActive(true);
            towerSlots2.slotEquiped = false;
            myTowerInSlot2.SetActive(false);
            myResourceMenu.SetActive(false);
            unEquipButton.SetActive(false);
        }
        else if (slot3Selected)
        {
            myTowerActiveState.Value = false;
            myTowerInSelection.SetActive(true);
            towerSlots3.slotEquiped = false;
            myTowerInSlot3.SetActive(false);
            myResourceMenu.SetActive(false);
            unEquipButton.SetActive(false);
        }
    }
}

