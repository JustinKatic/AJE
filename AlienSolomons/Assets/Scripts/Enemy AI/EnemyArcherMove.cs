using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyArcherMove : MonoBehaviour
{
    Transform destination;
    public NavMeshAgent navMeshAgent;
    GameObject player;

    [SerializeField] FloatVariable _archerRange;
    [SerializeField] FloatVariable _archerMoveSpeed;
    [SerializeField] FloatVariable _archerTimeBetweenShots;
    [SerializeField] FloatVariable SlowTowerDuration;



    private bool _slowDebuff;
    private float _slowDurationTimer;

    private float _shotCounter;
    [SerializeField] Transform _firePoint;

    void Start()
    {
        destination = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError(gameObject.name + "does not have a nav mesh agent.");
        }
    }


    private void OnDisable()
    {
        _slowDebuff = false;
        SetEnemyMoveSpeed(_archerMoveSpeed.Value);
    }

    private void Update()
    {
        SlowDebuff(_archerMoveSpeed.Value);

        float dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist > _archerRange.Value)
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(destination.position);
        }
        else
        {
            navMeshAgent.isStopped = true;
            ArcherShoot();
            transform.LookAt(player.transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            navMeshAgent.velocity = Vector3.zero;
            navMeshAgent.isStopped = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            navMeshAgent.isStopped = false;
    }

    public void SetEnemyMoveSpeed(float enemyMoveSpeed)
    {
        if (navMeshAgent != null)
            navMeshAgent.speed = enemyMoveSpeed;
    }

    public float GetEnemyMoveSpeed()
    {
        return navMeshAgent.speed;
    }

    public void SetSlowDebuffTrue(float reduceSpeedByX)
    {
        SetEnemyMoveSpeed(_archerMoveSpeed.Value - reduceSpeedByX);
        _slowDebuff = true;
        _slowDurationTimer = 0;
    }

    public void SlowDebuff(float EnemyDefaultSpeed)
    {
        if (_slowDebuff == true)
        {
            _slowDurationTimer += Time.deltaTime;
            if (_slowDurationTimer > SlowTowerDuration.Value)
            {
                SetEnemyMoveSpeed(EnemyDefaultSpeed);
                _slowDurationTimer = 0;
                _slowDebuff = false;
            }
        }
    }

    public void ArcherShoot()
    {
        _shotCounter -= Time.deltaTime;
        if (_shotCounter <= 0)
        {
            GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("EnemyBullet");
            _shotCounter = _archerTimeBetweenShots.Value;
            bullet.transform.position = _firePoint.position;
            bullet.transform.rotation = _firePoint.transform.rotation;
            bullet.SetActive(true);
        }
    }
}
