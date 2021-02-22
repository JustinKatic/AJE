using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfCannoneerProjectileController : EnemyProjectileController
{
    Vector3 targetPos;
    [SerializeField] FloatVariable ExplosionRadius;
    [SerializeField] LayerMaskVariable ObjAffectsByExplosion;
    [SerializeField] GameObject Explosion;
    CameraShake camShake;

    private void Start()
    {
        camShake = GameObject.FindObjectOfType<CameraShake>();
    }

    private void OnEnable()
    {
        targetPos = GameObject.FindGameObjectWithTag(TagOfObjectCanHit.Value).transform.position;
    }

    protected override void MoveBullet()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, _speed.RuntimeValue * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPos) < 0.2f)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, ExplosionRadius.RuntimeValue, ObjAffectsByExplosion.Value);
            int i = 0;
            while (i < hitColliders.Length)
            {
                UpdatePlayerHealthEvent.Raise();
                PlayerCurrentHp.RuntimeValue -= _damage.RuntimeValue;
                FloatingText(_damage.RuntimeValue, hitColliders[0].transform.position);
                i++;
            }
            SetUnActive();
        }
    }
    protected override void SetUnActive()
    {
        camShake.CamShake();
        Instantiate(Explosion, transform.position, Quaternion.Euler(-90, transform.rotation.y, transform.rotation.z));       
        base.SetUnActive();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius.RuntimeValue);
    }
}
