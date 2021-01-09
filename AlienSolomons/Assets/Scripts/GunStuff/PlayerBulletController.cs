using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBulletController : MonoBehaviour
{
    [SerializeField] float _bulletLife;

    private void Awake()
    {       

    }

    private void OnEnable()
    {
        Invoke("SetUnActive", _bulletLife);
    }

    void Update()
    {
        //Move bullet forward
        transform.Translate(Vector3.forward * GameStats.instance._playerBulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            SetUnActive();
            collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(GameStats.instance._playerBulletDmg);
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
