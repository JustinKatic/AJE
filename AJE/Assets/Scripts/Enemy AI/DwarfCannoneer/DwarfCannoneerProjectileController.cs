using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfCannoneerProjectileController : EnemyProjectileController
{
    Vector3 targetPos;
    [SerializeField] float ExplosionRadius;
    [SerializeField] LayerMask Player;
    [SerializeField] LayerMask AttackableTower;

    [SerializeField] GameObject Explosion;
    CameraShake camShake;

    [SerializeField] float FindTowerRadiusCheck;

    GameObject player;

    private void Start()
    {
        camShake = GameObject.FindObjectOfType<CameraShake>();
    }

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, FindTowerRadiusCheck, AttackableTower);

        if (hitColliders.Length >= 1)
            targetPos = hitColliders[0].transform.position;
        else
            targetPos = player.transform.position;
    }

    protected override void MoveBullet()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPos) < 0.2f)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, ExplosionRadius, Player | AttackableTower);
            int i = 0;
            while (i < hitColliders.Length)
            {               
                if (hitColliders[i].gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    PlayerCurrentHp.RuntimeValue -= _damage;
                    UpdatePlayerHealthEvent.Raise();
                    FloatingTxt(_damage, hitColliders[0].transform);
                }
                else if (hitColliders[i].gameObject.layer == LayerMask.NameToLayer("AttackableTower"))
                {
                    hitColliders[i].GetComponent<TowerHealth>().HurtEnemy(_damage);
                }
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

    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    //}
}
