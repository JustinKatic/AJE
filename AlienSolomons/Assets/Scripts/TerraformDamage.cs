using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerraformDamage : MonoBehaviour
{
    [SerializeField] float _damageEveryX = 1.0f;
    float _timer;
    [SerializeField] float _damage;

    [SerializeField] Material _DOTMat;
    private Material _defaultMat;


    private void Awake()
    {
        _defaultMat = gameObject.GetComponent<MeshRenderer>().material;
    }

    private void OnEnable()
    {
        gameObject.GetComponent<MeshRenderer>().material = _DOTMat;
    }
    private void OnDisable()
    {
        gameObject.GetComponent<MeshRenderer>().material = _defaultMat;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy1" || other.gameObject.tag == "Enemy2" ||
            other.gameObject.tag == "Enemy3" || other.gameObject.tag == "EnemyRanged")
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
