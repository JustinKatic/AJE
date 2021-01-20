using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] FloatVariable TimeBetweenShots;
    private float _shotCounter;
    [SerializeField] Transform _firePoint;
    [SerializeField] FloatVariable AttackRange;
    private Transform Target;
    [SerializeField] StringVariable TagOfTarget;

    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag(TagOfTarget.Value).transform;
    }
    private void OnEnable()
    {
        _shotCounter = TimeBetweenShots.Value;
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, Target.transform.position);
        if (dist < AttackRange.Value)
        {
            ArcherShoot();
        }
    }


    public void ArcherShoot()
    {
        _shotCounter -= Time.deltaTime;
        if (_shotCounter <= 0)
        {
            GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("ArcherProjectile");
            _shotCounter = TimeBetweenShots.Value;
            bullet.transform.position = _firePoint.position;
            bullet.transform.rotation = _firePoint.transform.rotation;
            bullet.SetActive(true);
        }
    }
}



