using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpExp : MonoBehaviour
{
    [SerializeField] StringVariable TagOfObjectsAbleToPickMeUp;

    [SerializeField] FloatVariable PlayerInGameExp;
    [SerializeField] FloatVariable ExpWorth;
    [SerializeField] GameEvent UpdateExpBar;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagOfObjectsAbleToPickMeUp.Value)
        {
            PlayerInGameExp.RuntimeValue += ExpWorth.RuntimeValue;
            UpdateExpBar.Raise();
            gameObject.SetActive(false);
        }
    }
}
