using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfCannoneerProjectileController : EnemyProjectileController
{
    public Vector3 shootPos;
    [SerializeField] float ExplosionRadius;
    [SerializeField] LayerMask Player;
    [SerializeField] LayerMask AttackableTower;

    [SerializeField] GameObject Explosion;
    CameraShake camShake;

    [SerializeField] float FindTowerRadiusCheck;

    [SerializeField] BoolVariable isPlayerInvincible;

    GameObject player;



    private void Start()
    {
        camShake = GameObject.FindObjectOfType<CameraShake>();
    }

    private void OnEnable()
    {
        
    }

    protected override void MoveBullet()
    {
        transform.position = Vector3.MoveTowards(transform.position, shootPos, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, shootPos) < 0.2f)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, ExplosionRadius, Player | AttackableTower);
            int i = 0;
            while (i < hitColliders.Length)
            {               
                if (hitColliders[i].gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    if (isPlayerInvincible.Value == false)
                    {
                        PlayerCurrentHp.RuntimeValue -= _damage;
                        UpdatePlayerHealthEvent.Raise();
                        FloatingTxt(_damage, hitColliders[0].transform, "-", Color.red);
                    }
                }
                else if (hitColliders[i].gameObject.layer == LayerMask.NameToLayer("Tower"))
                {
                    hitColliders[i].GetComponent<TowerHealth>().HurtEnemy(_damage,true);
                }
                i++;
            }
            SetUnActive();
        }
    }
    protected override void SetUnActive()
    {
        SFXAudioManager.instance.Play("CannoneerProjectile");

        camShake.CamShake();
        Instantiate(Explosion, transform.position, Quaternion.Euler(-90, transform.rotation.y, transform.rotation.z));
        base.SetUnActive();
    }
}
