using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerVariableToDefault : MonoBehaviour
{
    [SerializeField] FloatVariable RefplayerProjectileDmg;
    [SerializeField] FloatVariable RefPlayerMaxHealth;

    private float playerProjectileDmg;
    private float PlayerMaxHealth;



    private void Awake()
    {
        playerProjectileDmg = RefplayerProjectileDmg.Value;
        PlayerMaxHealth = RefPlayerMaxHealth.Value;
    }
    private void OnDestroy()
    {
        RefplayerProjectileDmg.Value = playerProjectileDmg;
        RefPlayerMaxHealth.Value = PlayerMaxHealth;
    }
}
