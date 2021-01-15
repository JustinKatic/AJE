using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{

    [SerializeField] float _damageEveryX = 1.0f;
    float _timer;
    [SerializeField] float _damage;

    PlayerHealthManager _playerHealthManager;

    private void Start()
    {
        _playerHealthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _timer += Time.deltaTime;
            if (_timer > _damageEveryX)
            {
                _playerHealthManager.HurtPlayer(_damage);
                _timer = 0.0f;
            }
        }
    }

}
