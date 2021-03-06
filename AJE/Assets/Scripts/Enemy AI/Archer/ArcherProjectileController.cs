using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherProjectileController : EnemyProjectileController
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagOfObjectCanHit.Value)
        {
            PlayerCurrentHp.RuntimeValue -= _damage;
            FloatingText(_damage, other.transform.position);
            UpdatePlayerHealthEvent.Raise();
        }

        if (other.gameObject.tag == "Wall")
        {
            SetUnActive();
        }
    }
}
