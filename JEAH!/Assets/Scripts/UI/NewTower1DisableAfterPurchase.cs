using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewTower1DisableAfterPurchase : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] BoolVariable isNewTower1Purchased;

    void Update()
    {
        //Disables the button to purchase a new tower (it's a one time purchase).
        if (isNewTower1Purchased.Value == true)
        {
            button.SetActive(false);
        }
        else if (isNewTower1Purchased.Value == false)
        {
            button.SetActive(true);
        }
    }
}
