﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyArcherProjectile : MonoBehaviour
{
    [SerializeField] FloatVariable _speed;
    [SerializeField] FloatVariable _bulletLife;
    [SerializeField] FloatVariable _damage;
    [SerializeField] GameEvent PlayerShotByArcher;


    private void Awake()
    {       
        
    }

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
        if (other.gameObject.tag == "Player")
        {
            SetUnActive();
            PlayerShotByArcher.Raise();
        }

        if (other.gameObject.tag == "Wall")
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