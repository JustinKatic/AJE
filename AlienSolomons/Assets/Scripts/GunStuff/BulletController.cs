using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls bullet speed, direction, lifetime and damage.
/// </summary>
public class BulletController : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _bulletLife;
    [SerializeField] float _damage;


    private void OnEnable()
    {
        Invoke("SetUnActive", _bulletLife);
    }

    void Update()
    {
        //Move bullet forward
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SetUnActive();
            collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(_damage);
        }

        if (collision.gameObject.tag == "Wall")
        {
            SetUnActive();
            gameObject.SetActive(false);
        }
    }   

    void SetUnActive()
    {
        gameObject.SetActive(false);
        CancelInvoke();
    }    
    
  
}
