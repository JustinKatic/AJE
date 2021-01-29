using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] protected FloatVariable TimeBetweenShots;
    protected float _shotCounter;
    [SerializeField] protected Transform _firePoint;
    [SerializeField] FloatVariable AttackRange;
    protected Transform Target;
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
            Shoot();
        }
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



