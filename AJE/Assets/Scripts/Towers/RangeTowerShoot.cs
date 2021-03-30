using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTowerShoot : MonoBehaviour
{
    RangeTower rangeTower;
    [SerializeField] float TimeBetweenShots;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject shootPoint;


    private float _shotCounter;

    private void OnEnable()
    {
        rangeTower = GetComponentInParent<RangeTower>();
        _shotCounter = TimeBetweenShots;
    }

    private void Update()
    {
        if(rangeTower.targetFound == true)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        _shotCounter -= Time.deltaTime;
        if (_shotCounter <= 0)
        {
          //  Instantiate(projectile, shootPoint.transform.position, shootPoint.transform.rotation);
            GameObject projectile = ObjectPooler.SharedInstance.GetPooledObject("RangeTowerProjectile");
            projectile.transform.position = shootPoint.transform.position;
            projectile.transform.rotation = shootPoint.transform.rotation;
            projectile.SetActive(true);
            _shotCounter = TimeBetweenShots;
        }
    }
}
