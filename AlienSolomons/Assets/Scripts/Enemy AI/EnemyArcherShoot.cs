using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcherShoot : MonoBehaviour
{
    private float _shotCounter;
    [SerializeField] Transform _firePoint;
    private EnemyArcherMove _moveScript;

    private void Start()
    {
        _moveScript = gameObject.GetComponent<EnemyArcherMove>();
    }
    void Update()
    {
        if (_moveScript._shooting)
        {
            _shotCounter -= Time.deltaTime;
            if (_shotCounter <= 0)
            {
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("EnemyBullet");
                _shotCounter = EnemyManager.instance._archerTimeBetweenShotsSpeed;
                bullet.transform.position = _firePoint.position;
                bullet.transform.rotation = _firePoint.transform.rotation;
                bullet.SetActive(true);
            }
        }
    }
}



