using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewTower1DisableAfterPurchase : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] BoolVariable isNewTower1Purchased;
    // Start is called before the first frame update
    void OnEnable()
    {
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
