using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTowerActive : MonoBehaviour
{
    [SerializeField] BoolVariable myTowerActiveState;

    private void OnEnable()
    {
        myTowerActiveState.Value = true;
    }

}
