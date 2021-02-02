using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSpeedPowerUp : PowerUpButton
{
    [SerializeField] FloatVariable PlayerMoveSpeed;
    [SerializeField] FloatVariable IncreasePlayerMoveSpeedBy;

    protected override void ApplyPowerUp()
    {
        PlayerMoveSpeed.RuntimeValue += IncreasePlayerMoveSpeedBy.RuntimeValue;
    }
}
