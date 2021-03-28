using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RangeTowerProjectile : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _bulletLife;
    [SerializeField] float _damage;

    [SerializeField] GameObject floatingDmg;

    private void OnEnable()
    {
        Invoke("SetUnActive", _bulletLife);
    }

    void Update()
    {
        //Move bullet forward
        MoveBullet();
    }

    void MoveBullet()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    void SetUnActive()
    {
        gameObject.SetActive(false);
        CancelInvoke();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            EnemyHealthManager enemyHealth = other.GetComponent<EnemyHealthManager>();
            enemyHealth.HurtEnemy(_damage);
            enemyHealth.FloatingTxt(_damage, other.transform, "-", Color.white);
            SetUnActive();
        }
        else if (other.gameObject.tag == "Wall")
        {
            SetUnActive();
        }
    }
}
