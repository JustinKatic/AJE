using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CurrencyPickUp : MonoBehaviour
{
    [SerializeField] StringVariable TagOfObjectsAbleToPickMeUp;

    [SerializeField] FloatVariable PickUpValue;
    [SerializeField] FloatVariable PlayerInGameCurrency;
    [SerializeField] FloatVariable PlayerTakeBackToMenuCurrency;
    [SerializeField] GameEvent MyEvent;
    [SerializeField] GameObject floatingNumberTxt;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == TagOfObjectsAbleToPickMeUp.Value)
        {
            PlayerInGameCurrency.Value += PickUpValue.Value;
            PlayerTakeBackToMenuCurrency.Value += PickUpValue.Value;
            FloatingText(PickUpValue);
            MyEvent.Raise();
            gameObject.SetActive(false);
        }
    }

    public void FloatingText(FloatVariable PickUpValue)
    {
        GameObject points = Instantiate(floatingNumberTxt, transform.position, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = "$" + PickUpValue.Value.ToString();
    }
}
