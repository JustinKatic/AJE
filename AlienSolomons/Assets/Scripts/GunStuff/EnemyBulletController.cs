﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _bulletLife;
    [SerializeField] float _damage;
    PlayerHealthManager _playerHealth;

    private void Awake()
    {       
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthManager>();
    }

    private void OnEnable()
    {
        Invoke("SetUnActive", _bulletLife);
    }

    void Update()
    {
        //Move bullet forward
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SetUnActive();
            _playerHealth.HurtPlayer(_damage);
        }

        if (other.gameObject.tag == "Wall")
        {
            SetUnActive();
            gameObject.SetActive(false);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        SetUnActive();
    //        _playerHealth.HurtPlayer(_damage);
    //    }

    //    if (collision.gameObject.tag == "Wall")
    //    {
    //        SetUnActive();
    //        gameObject.SetActive(false);
    //    }
    //}   

    void SetUnActive()
    {
        gameObject.SetActive(false);
        CancelInvoke();
    }    
    
  
}
