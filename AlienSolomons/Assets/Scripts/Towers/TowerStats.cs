using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats : MonoBehaviour
{
    private float _timer;
    [SerializeField] LayerMaskVariable EnemyLayerMask;
    [SerializeField] FloatVariable ActivateEveryX;
    [SerializeField] FloatVariable TowerRadius;
    [SerializeField] FloatVariable TowerDamage;

    [SerializeField] bool CanDamage;
    [SerializeField] bool CanSlow;


    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= ActivateEveryX.Value)
        {
            MyCollisions();
            _timer = 0;
        }
    }

    void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, TowerRadius.Value, EnemyLayerMask.Value);
        int i = 0;
        while (i < hitColliders.Length)
        {       
            if(CanDamage)
            hitColliders[i].GetComponent<EnemyHealthManager>().HurtEnemy(TowerDamage.Value);
            if(CanSlow)
            hitColliders[i].GetComponent<EnemyMove>().SetSlowDebuffTrue();
            i++;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, TowerRadius.Value);
    }
}
