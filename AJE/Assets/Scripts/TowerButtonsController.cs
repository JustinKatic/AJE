using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButtonsController : MonoBehaviour
{
    [SerializeField] GameObject damageTowerButton;
    [SerializeField] GameObject slowTowerButton;
    [SerializeField] GameObject plagueTowerButton;
    [SerializeField] GameObject vamparicTowerButton;


    [SerializeField] BoolVariable isDmgButtonActive;
    [SerializeField] BoolVariable isSlowButtonActive;
    [SerializeField] BoolVariable isPlagueButtonActive;
    [SerializeField] BoolVariable isVamparicButtonActive;


    private void Start()
    {
        //DAMAGE TOWER BUTTON  set active/notActive
        if (isDmgButtonActive.Value)
            damageTowerButton.SetActive(true);
        else
            damageTowerButton.SetActive(false);

        //SLOW TOWER BUTTON  set active/notActive
        if (isSlowButtonActive.Value)
            slowTowerButton.SetActive(true);
        else
            slowTowerButton.SetActive(false);

        //PLAGUE TOWER BUTTON  set active/notActive
        if (isPlagueButtonActive.Value)
            plagueTowerButton.SetActive(true);
        else
            plagueTowerButton.SetActive(false);

        //VAMPARIC TOWER BUTTON  set active/notActive
        if (isVamparicButtonActive.Value)
            vamparicTowerButton.SetActive(true);
        else
            vamparicTowerButton.SetActive(false);


    }
}
