using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageTower : TowersDefault
{
    private bool playMelleTowerSFX;
    private float timer;
    public float SFXFrequency = 1.5f;

    public GameObject powerUpFx;


    protected override void Update()
    {
        base.Update();

        if(playMelleTowerSFX)
        timer += Time.deltaTime;
        if (timer >= SFXFrequency)
        {
            AudioManager.instance.Play("TowerMeleeAttack");
            playMelleTowerSFX = false;
            timer = 0;
        }

        if (powerdUp)
            powerUpFx.SetActive(true);
        else
            powerUpFx.SetActive(false);

    }

    protected override void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, TowerRadius, EnemyLayerMask);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].GetComponent<EnemyHealthManager>().HurtEnemy(TowerDamage);
            FloatingTxt(TowerDamage, hitColliders[i].transform, "-", Color.white);
            i++;
        }
        if (hitColliders.Length >= 1)
        {
            playMelleTowerSFX = true;
        }
        else
            playMelleTowerSFX = false;

    }
}
