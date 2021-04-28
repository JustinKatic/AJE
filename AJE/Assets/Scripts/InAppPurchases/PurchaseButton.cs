using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseButton : MonoBehaviour
{
    public enum PurchaseType { buyExtraLives, buyMoreSouls, buyTower1};
    public PurchaseType purchaseType;

    public void ClickPurchaseButton()
    {
        switch (purchaseType)
        {
            case PurchaseType.buyExtraLives:
                IAPManager.instance.BuyExtraLives();
                break;
            case PurchaseType.buyMoreSouls:
                IAPManager.instance.BuyMoreSouls();
                break;
            case PurchaseType.buyTower1:
                IAPManager.instance.BuyTower1();
                gameObject.SetActive(false);
                break;
        }
    }
}
