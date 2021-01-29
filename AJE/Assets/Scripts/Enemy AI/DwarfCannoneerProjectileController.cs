using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfCannoneerProjectileController : EnemyProjectileController
{
    Vector3 targetPos;
    [SerializeField] FloatVariable ExplosionRadius;
    [SerializeField] LayerMaskVariable ObjAffectsByExplosion;
    private void OnEnable()
    {
        targetPos = GameObject.FindGameObjectWithTag(TagOfObjectCanHit.Value).transform.position;
    }

    protected override void MoveBullet()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, _speed.Value * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPos) < 0.2f)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, ExplosionRadius.Value, ObjAffectsByExplosion.Value);
            int i = 0;
            while (i < hitColliders.Length)
            {
                projectileHitEvent.Raise();
                i++;
            }
            SetUnActive();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius.Value);
    }
}
