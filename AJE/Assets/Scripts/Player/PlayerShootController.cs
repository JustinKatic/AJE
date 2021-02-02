using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShootController : MonoBehaviour
{
    private float _shotCounter;
    [SerializeField] Transform _firePoint;
    [SerializeField] BoolVariable _shooting;
    [SerializeField] FloatVariable _playerFireRate;



    void Update()
    {
        if (!_shooting.Value)
            _shotCounter = _playerFireRate.RuntimeValue;

        if (_shooting.Value)
        {
            _shotCounter -= Time.deltaTime;
            if (_shotCounter <= 0)
            {
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("PlayerBullet");
                _shotCounter = _playerFireRate.RuntimeValue;
                bullet.transform.position = _firePoint.position;
                bullet.transform.rotation = _firePoint.transform.rotation;
                bullet.SetActive(true);
            }
        }
    }
}
