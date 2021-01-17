using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTower : MonoBehaviour
{
    private float _timer;

    [SerializeField] FloatVariable DamageTowerActivateEveryX;
    [SerializeField] FloatVariable DamageTowerDamage;
    [SerializeField] FloatVariable DamageTowerRadius;
    [SerializeField] LayerMaskVariable EnemyLayerMask;



    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= DamageTowerActivateEveryX.Value)
        {
            MyCollisions();
            _timer = 0;
        }
    }


    void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, DamageTowerRadius.Value, EnemyLayerMask.Value);
        int i = 0;
        //Check when there is a new collider coming into contact with the box
        while (i < hitColliders.Length)
        {
            hitColliders[i].GetComponent<EnemyHealthManager>().HurtEnemy(DamageTowerDamage.Value);
            i++;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, DamageTowerRadius.Value);
    }

}
