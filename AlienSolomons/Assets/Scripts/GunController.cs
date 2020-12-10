using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the rate of fire and bullet speed of a gun.
/// </summary>
public class GunController : MonoBehaviour
{
    public bool isFiring;

    public float timeBetweenShots;
    private float shotCounter;
    public Transform firePoint;
    private MovementJoystick _moveScript;

    private void Start()
    {
        _moveScript = gameObject.GetComponent<MovementJoystick>();
    }
    void Update()
    {
        if (_moveScript._shooting)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("PlayerBullet");
                shotCounter = timeBetweenShots;
                bullet.transform.position = firePoint.position;
                bullet.transform.rotation = firePoint.transform.rotation;
                bullet.SetActive(true);
            }
        }

    }
}
