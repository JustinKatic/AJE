﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : MonoBehaviour
{
    [SerializeField] float _timeBetweenShots;
    private float _shotCounter;
    [SerializeField] Transform _firePoint;
    private EnemyRangedMove _moveScript;

    private void Start()
    {
        _moveScript = gameObject.GetComponent<EnemyRangedMove>();
    }
    void Update()
    {
        if (_moveScript._shooting)
        {
            _shotCounter -= Time.deltaTime;
            if (_shotCounter <= 0)
            {
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("PlayerBullet");
                _shotCounter = _timeBetweenShots;
                bullet.transform.position = _firePoint.position;
                bullet.transform.rotation = _firePoint.transform.rotation;
                bullet.SetActive(true);
            }
        }
    }
}


