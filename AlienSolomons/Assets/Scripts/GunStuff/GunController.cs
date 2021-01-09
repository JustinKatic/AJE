using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the rate of fire and bullet speed of a gun.
/// </summary>
public class GunController : MonoBehaviour
{
    public bool _isFiring;

    private float _shotCounter;
    [SerializeField] Transform _firePoint;
    private PlayerMove _moveScript;

    private void Start()
    {
        _moveScript = gameObject.GetComponent<PlayerMove>();
    }
    void Update()
    {
        if (_moveScript._shooting)
        {
            _shotCounter -= Time.deltaTime;
            if (_shotCounter <= 0)
            {
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("PlayerBullet");
                _shotCounter = GameStats.instance._playerFireRate;
                bullet.transform.position = _firePoint.position;
                bullet.transform.rotation = _firePoint.transform.rotation;
                bullet.SetActive(true);
            }
        }

    }
}
