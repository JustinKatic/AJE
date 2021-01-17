using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _bulletLife;
    [SerializeField] FloatVariable _damage;
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
            _playerHealth.HurtPlayer(_damage.Value);
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
