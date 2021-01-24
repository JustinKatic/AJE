using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowersDefault : MonoBehaviour
{
    private float _timer;
    [SerializeField] protected LayerMaskVariable EnemyLayerMask;
    [SerializeField] protected FloatVariable ActivateEveryX;
    [SerializeField] protected FloatVariable TowerRadius;
    [SerializeField] protected FloatVariable TowerDamage;


    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= ActivateEveryX.Value)
        {
            MyCollisions();
            _timer = 0;
        }
    }

    protected virtual void MyCollisions()
    {
        Debug.Log("Select a specifc tower script");
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, TowerRadius.Value);
    }
}
