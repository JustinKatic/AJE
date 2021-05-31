using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherShoot : EnemyShoot
{

    public bool CanShoot;
    [SerializeField] float lrDistance;
    LineRenderer lr;

    public bool shootReady;



    private void Awake()
    {
        lr = gameObject.GetComponent<LineRenderer>();
    }
    private void OnDisable()
    {
        lr.positionCount = 0;
    }
    private void OnEnable()
    {
        shootReady = true;
        _shotCounter = TimeBetweenShots;
    }

    public override void Shoot()
    {
        if (CanShoot)
        {
            lr.enabled = true;
            lr.positionCount = 2;
            lr.SetPosition(0, gameObject.transform.position);
            lr.SetPosition(1, gameObject.transform.position + gameObject.transform.forward * lrDistance);

            _shotCounter -= Time.deltaTime;
            if (_shotCounter <= 0)
            {
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("ArcherProjectile");
                _shotCounter = TimeBetweenShots;
                bullet.transform.position = _firePoint.position;
                bullet.transform.rotation = _firePoint.transform.rotation;
                bullet.SetActive(true);
                lr.positionCount = 0;
                CanShoot = false;
                shootReady = false;
                AudioManager.instance.Play("ArcherAttack");
                //if (shootSound)
                //    shootSound.Play();
            }
        }
    }
}

