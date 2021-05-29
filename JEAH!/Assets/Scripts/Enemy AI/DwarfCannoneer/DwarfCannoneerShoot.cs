using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfCannoneerShoot : EnemyShoot
{
    public bool CanShoot;


    public bool shotBullet;

    [SerializeField] ScriptableSoundObj cannoneerAttackSFX;


    private void OnEnable()
    {
        _shotCounter = TimeBetweenShots;
        CanShoot = false;
    }

    public override void Shoot()
    {
        if (CanShoot)
        {
            _shotCounter -= Time.deltaTime;
            if (_shotCounter <= 0)
            {
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("DwarfCannoneerProjectile");
                _shotCounter = TimeBetweenShots;
                bullet.transform.position = _firePoint.position;
                bullet.transform.rotation = _firePoint.transform.rotation;
                bullet.SetActive(true);

                shotBullet = true;
                _shotCounter = TimeBetweenShots;
                if (cannoneerAttackSFX)
                    cannoneerAttackSFX.Play();
                else
                    Debug.Log("no death sound added" + gameObject.name);
            }
        }
    }
}

