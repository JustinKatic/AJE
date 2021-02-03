using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCritChancePowerUp : PowerUpButton
{
    [SerializeField] FloatVariable PlayerCritChance;
    [SerializeField] FloatVariable IncreasePlayerCritChanceBy;


    protected override void ApplyPowerUp()
    {
        PlayerCritChance.RuntimeValue += IncreasePlayerCritChanceBy.RuntimeValue;
    }
}
