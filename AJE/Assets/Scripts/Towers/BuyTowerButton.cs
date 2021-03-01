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

    [SerializeField] GameEvent UpdateCurrency;
    [SerializeField] LayerMask notBuildable;



    private Button BuyButton;

    void Start()
    {
        ObjPurchasingTower = GameObject.FindGameObjectWithTag(TagOfObjectPurchasingTower.Value);
        BuyButton = gameObject.GetComponent<Button>();
        BuyButton.interactable = false;
        ButtonText.text = TowerName + "\n\n$" + TowerCost.RuntimeValue;
    }

    void Update()
    {
        if (PlayerInGameCurrency.RuntimeValue >= TowerCost.RuntimeValue)
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
        if (Physics.Raycast(ObjPurchasingTower.transform.position, Vector3.down, out hit, 100f, ~notBuildable))
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
                        hit.collider.gameObject.transform.transform.position.y + 1.05f,
                        hit.collider.gameObject.transform.position.z),
                        hit.collider.gameObject.transform.rotation);
                    buildable._hasAreaBeenBuiltOn = true;
                    PlayerInGameCurrency.RuntimeValue -= TowerCost.RuntimeValue;
                    UpdateCurrency.Raise();
                }
            }
        }
    }
}
