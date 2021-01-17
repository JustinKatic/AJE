using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTower : MonoBehaviour
{
    private float _timer;
    [SerializeField] LayerMaskVariable EnemyLayerMask;
    [SerializeField] FloatVariable SlowTowerDebuffAmount;
    [SerializeField] FloatVariable SlowTowerActivateEveryX;
    [SerializeField] FloatVariable SlowTowerRadius;
    [SerializeField] FloatVariable SlowTowerDamage;



    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= SlowTowerActivateEveryX.Value)
        {
            MyCollisions();
            _timer = 0;
        }
    }

    void MyCollisions()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, SlowTowerRadius.Value, EnemyLayerMask.Value);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].GetComponent<EnemyHealthManager>().HurtEnemy(SlowTowerDamage.Value);
            if (hitColliders[i].tag == "EnemyBarbarian")
                hitColliders[i].GetComponent<EnemyBarbarianMovement>().SetSlowDebuffTrue(SlowTowerDebuffAmount.Value);
            else if ((hitColliders[i].tag == "EnemyArcher"))
                hitColliders[i].GetComponent<EnemyArcherMove>().SetSlowDebuffTrue(SlowTowerDebuffAmount.Value);
            i++;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, SlowTowerRadius.Value);
    }
}
