using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyProjectileController : MonoBehaviour
{
    [SerializeField] protected FloatVariable _speed;
    [SerializeField] protected FloatVariable _bulletLife;
    [SerializeField] protected FloatVariable _damage;

    [SerializeField] protected StringVariable TagOfObjectCanHit;
    [SerializeField] protected GameEvent projectileHitEvent;


    private void OnEnable()
    {
        Invoke("SetUnActive", _bulletLife.Value);
    }

    void Update()
    {
        //Move bullet forward
        MoveBullet();
    }

    virtual protected void MoveBullet()
    {
        transform.Translate(Vector3.forward * _speed.Value * Time.deltaTime);

    }

    protected void SetUnActive()
    {
        gameObject.SetActive(false);
        CancelInvoke();
    }


}
