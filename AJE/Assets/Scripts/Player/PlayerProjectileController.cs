using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerProjectileController : MonoBehaviour
{
    [SerializeField] FloatVariable _bulletLife;
    [SerializeField] FloatVariable _bulletDamage;
    [SerializeField] FloatVariable _bulletSpeed;


    private void Awake()
    {       
        
    }

    private void OnEnable()
    {
        Invoke("SetUnActive", _bulletLife.RuntimeValue);
    }

    void Update()
    {
        //Move bullet forward
        transform.Translate(Vector3.forward * _bulletSpeed.RuntimeValue * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            SetUnActive();
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(_bulletDamage.RuntimeValue);
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
