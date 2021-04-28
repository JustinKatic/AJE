using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButtonsController : MonoBehaviour
{
    [SerializeField] GameObject damageTowerButton;
    [SerializeField] GameObject slowTowerButton;
    [SerializeField] GameObject plagueTowerButton;
    [SerializeField] GameObject vamparicTowerButton;
    [SerializeField] GameObject rangeTowerButton;

    [SerializeField] bool isDmgTowerAvaible;
    [SerializeField] bool isSlowTowerAvaible;
    [SerializeField] bool isPlagueTowerAvaible;
    [SerializeField] bool isVamparicTowerAvaible;
    [SerializeField] bool isRangeTowerAvaible;
    [SerializeField] BoolVariable isNewTower1Purchased;

    private void OnEnable()
    {
        //Set tower to active if NewTower1 has been purchased
        if (isNewTower1Purchased.Value == true)
        {
            isPlagueTowerAvaible = true;
            plagueTowerButton.SetActive(true);
        }
        else
            plagueTowerButton.SetActive(false);
        
        //DAMAGE TOWER BUTTON  set active/notActive
        if (isDmgTowerAvaible)
            damageTowerButton.SetActive(true);
        else
            damageTowerButton.SetActive(false);

        //SLOW TOWER BUTTON  set active/notActive
        if (isSlowTowerAvaible)
            slowTowerButton.SetActive(true);
        else
            slowTowerButton.SetActive(false);

        //PLAGUE TOWER BUTTON  set active/notActive
        if (isPlagueTowerAvaible)
            plagueTowerButton.SetActive(true);
        else
            plagueTowerButton.SetActive(false);

        //VAMPARIC TOWER BUTTON  set active/notActive
        if (isVamparicTowerAvaible)
            vamparicTowerButton.SetActive(true);
        else
            vamparicTowerButton.SetActive(false);

        //Range TOWER BUTTON  set active/notActive
        if (isRangeTowerAvaible)
            rangeTowerButton.SetActive(true);
        else
            rangeTowerButton.SetActive(false);
    }
}
