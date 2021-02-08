using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherShoot : EnemyShoot
{

    public bool CanShoot;
    public bool shotTaken;
    [SerializeField] float lrDistance;
    LineRenderer lr;


    private void Awake()
    {
        shotTaken = true;
        lr = gameObject.GetComponent<LineRenderer>();
    }
    public override void Shoot()
    {
        if (CanShoot)
        {
            lr.positionCount = 2;
            lr.SetPosition(0, gameObject.transform.position);
            lr.SetPosition(1, gameObject.transform.position + gameObject.transform.forward * lrDistance);

            _shotCounter -= Time.deltaTime;
            if (_shotCounter <= 0)
            {
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("ArcherProjectile");
                _shotCounter = TimeBetweenShots.RuntimeValue;
                bullet.transform.position = _firePoint.position;
                bullet.transform.rotation = _firePoint.transform.rotation;
                bullet.SetActive(true);
                shotTaken = true;
                lr.positionCount = 0;
            }
        }
    }
}

