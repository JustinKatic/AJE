using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainsawAttack : MonoBehaviour
{

    [SerializeField] float _damageEveryX = 1.0f;
    float _timer;
    [SerializeField] float _damage;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _timer += Time.deltaTime;
            if (_timer > _damageEveryX)
            {
                other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(_damage);
                _timer = 0.0f;
            }
        }
    }
}