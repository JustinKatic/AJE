using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyTowerButton : MonoBehaviour
{

    [SerializeField] FloatVariable PlayerInGameCurrency;
    [SerializeField] TextMeshProUGUI ButtonText;
    [SerializeField] string TowerName;

    [SerializeField] StringVariable TagOfObjectPurchasingTower;
    private GameObject ObjPurchasingTower;

    [SerializeField] GameEvent UpdateCurrency;
    [SerializeField] LayerMask notBuildable;

    [SerializeField] FloatVariable myTowerCost;

    private Button BuyButton;

    void Start()
    {
        ObjPurchasingTower = GameObject.FindGameObjectWithTag(TagOfObjectPurchasingTower.Value);
        BuyButton = gameObject.GetComponent<Button>();
        BuyButton.interactable = false;
        ButtonText.text = myTowerCost.Value + " ";
    }

    void Update()
    {
        if (PlayerInGameCurrency.RuntimeValue >= myTowerCost.Value)
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
                {
                    AudioManager.instance.Play("TowerCannotBuild");

                    return;
                }
                else
                {
                    GameObject towerSpawned = Instantiate(TowerSelect,
                         new Vector3(hit.collider.gameObject.transform.position.x,
                         hit.collider.gameObject.transform.transform.position.y + 1.05f,
                         hit.collider.gameObject.transform.position.z),
                         hit.collider.gameObject.transform.rotation);

                    AudioManager.instance.Play("TowerSpawn");

                    TowersDefault tower = towerSpawned.GetComponent<TowersDefault>();
                    ActiveEnviromentSquare enviromentSquare = hit.collider.gameObject.GetComponent<ActiveEnviromentSquare>();

                    if (enviromentSquare.activateDamageEnviroment == true)
                    {
                        tower.TowerDamage = tower.TowerDamage + enviromentSquare.damageEnviromentMultiplier * tower.TowerDamage / 100;
                    }
                    if (enviromentSquare.activateSpeedEnviroment)
                    {
                        tower.ActivateEveryX = tower.ActivateEveryX - enviromentSquare.speedEnviromentMultiplier * tower.ActivateEveryX / 100;
                    }
                    if (enviromentSquare.activateRangeEnviroment)
                        tower.TowerRadius = tower.TowerRadius + enviromentSquare.rangeEnviromentMultiplier * tower.TowerRadius / 100;

                    buildable._hasAreaBeenBuiltOn = true;
                    PlayerInGameCurrency.RuntimeValue -= myTowerCost.Value;
                    UpdateCurrency.Raise();
                }
            }
        }
    }
}
