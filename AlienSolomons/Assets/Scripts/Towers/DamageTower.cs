using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTower : MonoBehaviour
{
    public LayerMask m_LayerMask;

    [SerializeField] float _activateEveryX = 1.0f;
    float _timer;
    [SerializeField] float _damage;
    [SerializeField] float _radius;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _activateEveryX)
        {
            MyCollisions();
            _timer = 0;
        }
    }


    void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius, m_LayerMask);
        int i = 0;
        //Check when there is a new collider coming into contact with the box
        while (i < hitColliders.Length)
        {
            hitColliders[i].GetComponent<EnemyHealthManager>().HurtEnemy(_damage);
            i++;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

}
