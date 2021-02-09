using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightHealthManager : EnemyHealthManager
{
    [SerializeField] GameObject ExpObj;
    public override void InstantiateExpDrop()
    {
        Instantiate(ExpObj, transform.position, transform.rotation);
    }
}
