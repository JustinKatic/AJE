using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradeManager : MonoBehaviour
{
    [SerializeField] float fireRateUpgradeAmount;
    [SerializeField] float DamageUpgradeAmount;
    [SerializeField] float BulletSpeedUpgradeAmount;


    public void UpgradePlayerFireRate()
    {
        GameStats.instance._playerFireRate -= fireRateUpgradeAmount;
    }

    public void UpgradePlayerDamage()
    {
        GameStats.instance._playerBulletDmg += DamageUpgradeAmount;
    }

    public void UpgradePlayerBulletSpeed()
    {
        GameStats.instance._playerBulletSpeed += BulletSpeedUpgradeAmount;
    }
}
