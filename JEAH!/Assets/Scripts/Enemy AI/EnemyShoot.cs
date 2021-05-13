using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] protected float TimeBetweenShots;
    protected float _shotCounter;
    [SerializeField] protected Transform _firePoint;
    [SerializeField] float AttackRange;
    protected Transform Target;
    [SerializeField] StringVariable TagOfTarget;


    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag(TagOfTarget.Value).transform;
    }
    private void OnEnable()
    {
        _shotCounter = TimeBetweenShots;
    }

    private void Update()
    {
        Shoot();
    }


    public virtual void Shoot()
    {
        _shotCounter -= Time.deltaTime;
        if (_shotCounter <= 0)
        {
            Debug.Log("noShootLogicInDefaultClass");
        }
    }
}



