using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PickUp : MonoBehaviour
{
    [SerializeField] StringVariable TagOfObjectsAbleToPickMeUp;

    [SerializeField] GameEvent MyEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagOfObjectsAbleToPickMeUp.Value)
        {
            MyEvent.Raise();
            gameObject.SetActive(false);
        }
    }
}
