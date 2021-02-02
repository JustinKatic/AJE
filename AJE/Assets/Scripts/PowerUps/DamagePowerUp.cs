using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerUp : PowerUpButton
{
    [SerializeField] FloatVariable PlayerDamage;
    [SerializeField] FloatVariable IncreasePlayerDamageBy;


    protected override void ApplyPowerUp()
    {
        PlayerDamage.RuntimeValue += IncreasePlayerDamageBy.RuntimeValue;
    }
}
