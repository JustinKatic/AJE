using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherProjectileController : EnemyProjectileController
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagOfObjectCanHit.Value)
        {
            projectileHitEvent.Raise();
        }

        if (other.gameObject.tag == "Wall")
        {
            SetUnActive();
        }
    }
}
