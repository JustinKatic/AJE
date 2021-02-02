using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherShoot : EnemyShoot
{
    public override void Shoot()
    {
        _shotCounter -= Time.deltaTime;
        if (_shotCounter <= 0)
        {
            GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("ArcherProjectile");
            _shotCounter = TimeBetweenShots.RuntimeValue;
            bullet.transform.position = _firePoint.position;
            bullet.transform.rotation = _firePoint.transform.rotation;
            bullet.SetActive(true);
        }
    }
}

