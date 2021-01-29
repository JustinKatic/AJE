using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfCannoneerShoot : EnemyShoot
{
    public bool canShoot;
    public override void Shoot()
    {
        if (canShoot)
        {
            _shotCounter -= Time.deltaTime;
            if (_shotCounter <= 0)
            {
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("DwarfCannoneerProjectile");
                _shotCounter = TimeBetweenShots.Value;
                bullet.transform.position = _firePoint.position;
                bullet.transform.rotation = _firePoint.transform.rotation;
                bullet.SetActive(true);
                gameObject.GetComponent<DwarfCannoneerMove>().rePositioned = false;
            }
        }
    }
}

