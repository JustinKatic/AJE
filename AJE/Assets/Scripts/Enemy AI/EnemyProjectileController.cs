using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyProjectileController : MonoBehaviour
{
    [SerializeField] FloatVariable _speed;
    [SerializeField] FloatVariable _bulletLife;
    [SerializeField] FloatVariable _damage;

    [SerializeField] StringVariable TagOfObjectCanHit;
    [SerializeField] GameEvent projectileHitEvent;


    private void OnEnable()
    {
        Invoke("SetUnActive", _bulletLife.Value);
    }

    void Update()
    {
        //Move bullet forward
        transform.Translate(Vector3.forward * _speed.Value * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagOfObjectCanHit.Value)
        {
            projectileHitEvent.Raise();
        }

        if (other.gameObject.tag == "Wall")
        {
            SetUnActive();
        }
    }


    void SetUnActive()
    {
        gameObject.SetActive(false);
        CancelInvoke();
    }


}
