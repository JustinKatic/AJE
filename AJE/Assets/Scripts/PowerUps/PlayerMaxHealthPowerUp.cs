using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaxHealthPowerUp : PowerUpButton
{
    [SerializeField] FloatVariable PlayerMaxHealth;
    [SerializeField] FloatVariable IncreasePlayerMaxHealthBy;
    [SerializeField] GameEvent playerHealthUpdatedEvent;

    protected override void ApplyPowerUp()
    {
        PlayerMaxHealth.Value += IncreasePlayerMaxHealthBy.Value;
        playerHealthUpdatedEvent.Raise();
    }
}
