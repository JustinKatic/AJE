using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherProjectileController : EnemyProjectileController
{
    [SerializeField] BoolVariable isPlayerInvincible;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (isPlayerInvincible.Value == false)
            {
                PlayerCurrentHp.RuntimeValue -= _damage;
                FloatingTxt(_damage, other.transform, "-", Color.red);
                UpdatePlayerHealthEvent.Raise();
                SetUnActive();
            }

        }
        else if(other.gameObject.tag == "DamageableTower")
        {
            other.GetComponent<TowerHealth>().HurtEnemy(_damage,true);
            SetUnActive();
        }

        if (other.gameObject.tag == "Wall")
        {
            SetUnActive();
        }
    }
}
