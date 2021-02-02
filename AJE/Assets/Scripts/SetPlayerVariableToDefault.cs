using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPlayerVariableToDefault : MonoBehaviour
{
    [SerializeField] FloatVariable RefplayerProjectileDmg;
    [SerializeField] FloatVariable RefPlayerMaxHealth;
    [SerializeField] FloatVariable RefPlayerMoveSpeed;

    [SerializeField] ListOfButtons RefPowerUpButtons;
    private List<Button> PowerUpButtons;



    private float playerProjectileDmg;
    private float PlayerMaxHealth;
    private float PlayerMoveSpeed;


    //private void Awake()
    //{
    //    playerProjectileDmg = RefplayerProjectileDmg.Value;
    //    PlayerMaxHealth = RefPlayerMaxHealth.Value;
    //    PlayerMoveSpeed = RefPlayerMoveSpeed.Value;
    //}
    //private void OnDestroy()
    //{
    //    RefplayerProjectileDmg.Value = playerProjectileDmg;
    //    RefPlayerMaxHealth.Value = PlayerMaxHealth;
    //    RefPlayerMoveSpeed.Value = PlayerMoveSpeed;
    //}
}
