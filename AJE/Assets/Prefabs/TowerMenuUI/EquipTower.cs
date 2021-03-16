using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipTower : MonoBehaviour
{
    [SerializeField] GameObject myTowerInSelection;
    [SerializeField] GameObject myResourceMenu;


    [SerializeField] GameObject myTowerInSlot1;
    [SerializeField] GameObject myTowerInSlot2;
    [SerializeField] GameObject myTowerInSlot3;

    [SerializeField] TowerSlots towerSlots1;
    [SerializeField] TowerSlots towerSlots2;
    [SerializeField] TowerSlots towerSlots3;

 

    public void EquipDamageTower()
    {
        if (!towerSlots1.slotEquiped)
        {
            myTowerInSelection.SetActive(false);
            myTowerInSlot1.SetActive(true);
            towerSlots1.slotEquiped = true;
            myResourceMenu.SetActive(false);
        }
        else if (!towerSlots2.slotEquiped)
        {
            myTowerInSelection.SetActive(false);
            myTowerInSlot2.SetActive(true);
            towerSlots2.slotEquiped = true;
            myResourceMenu.SetActive(false);
        }
        else if (!towerSlots3.slotEquiped)
        {
            myTowerInSelection.SetActive(false);
            myTowerInSlot3.SetActive(true);
            towerSlots3.slotEquiped = true;
            myResourceMenu.SetActive(false);

        }

    }
}
