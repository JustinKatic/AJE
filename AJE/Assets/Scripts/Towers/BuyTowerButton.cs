using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyTowerButton : MonoBehaviour
{
    [SerializeField] FloatVariable TowerCost;
    [SerializeField] FloatVariable PlayerInGameCurrency;
    [SerializeField] Text ButtonText;
    [SerializeField] string TowerName;

    [SerializeField] StringVariable TagOfObjectPurchasingTower;
    private GameObject ObjPurchasingTower;

    [SerializeField] GameEvent InGameCurrencyDecreased;



    private Button BuyButton;

    void Start()
    {
        ObjPurchasingTower = GameObject.FindGameObjectWithTag(TagOfObjectPurchasingTower.Value);
        BuyButton = gameObject.GetComponent<Button>();
        BuyButton.interactable = false;
        ButtonText.text = TowerName + "($" + TowerCost.Value + ")";
    }

    void Update()
    {
        if (PlayerInGameCurrency.Value >= TowerCost.Value)
        {
            BuyButton.interactable = true;
        }
        else
        {
            BuyButton.interactable = false;
        }
    }

    public void BuyTower(GameObject TowerSelect)
    {
        RaycastHit hit;
        if (Physics.Raycast(ObjPurchasingTower.transform.position, Vector3.down, out hit))
        {
            if (hit.collider.tag == "Ground")
            {
                SetAreaUnbuildable buildable = hit.collider.GetComponent<SetAreaUnbuildable>();
                if (buildable._hasAreaBeenBuiltOn)
                    return;
                else
                {
                    Instantiate(TowerSelect,
                        new Vector3(hit.collider.gameObject.transform.position.x,
                        hit.collider.gameObject.transform.transform.position.y + 0.65f,
                        hit.collider.gameObject.transform.position.z),
                        hit.collider.gameObject.transform.rotation);
                    buildable._hasAreaBeenBuiltOn = true;
                    PlayerInGameCurrency.Value -= TowerCost.Value;
                    InGameCurrencyDecreased.Raise();
                }
            }
        }
    }
}
