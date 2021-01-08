using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainsawAttack : MonoBehaviour
{

    [SerializeField] float _damageEveryX = 1.0f;
    float _timer;
    [SerializeField] float _damage;

    private void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (!enabled)
        {
            return;
        }
        if (other.gameObject.tag == "Enemy1" || other.gameObject.tag == "Enemy2" || other.gameObject.tag == "Enemy3" || other.gameObject.tag == "EnemyRanged")
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