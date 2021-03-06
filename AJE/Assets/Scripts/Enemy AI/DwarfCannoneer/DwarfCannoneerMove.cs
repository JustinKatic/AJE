using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfCannoneerMove : EnemyMove
{
    [SerializeField] float MyAttackRange;
    DwarfCannoneerShoot dwarfCannoneerShoot;
    [HideInInspector] public bool rePositioned;
    private GameObject randomPos;
    [SerializeField] LayerMask Waypoints;

    private float _timer;
    [SerializeField] protected float TimeSpentWandering;


    bool posFound = false;

    private void Awake()
    {
        dwarfCannoneerShoot = gameObject.GetComponent<DwarfCannoneerShoot>();
    }
    public override void Move()
    {
        //move towards player
        float dist = Vector3.Distance(transform.position, targetDestination.position);
        if (rePositioned == true && dist > MyAttackRange)
        {
            dwarfCannoneerShoot.canShoot = false;
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(targetDestination.position);
        }
        //stop and shoot at player
        else if (rePositioned == true && dist < MyAttackRange)
        {
            dwarfCannoneerShoot.canShoot = true;
            navMeshAgent.isStopped = true;
            LookTowards();
        }
        else if (rePositioned == false)
        {
            if (posFound == false)
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, 4, Waypoints);
                randomPos = hitColliders[Random.Range(0, hitColliders.Length)].gameObject;
                posFound = true;
            }
            navMeshAgent.isStopped = false;
            dwarfCannoneerShoot.canShoot = false;
            navMeshAgent.SetDestination(randomPos.transform.position);

            _timer += Time.deltaTime;

            float distToRand = Vector3.Distance(transform.position, randomPos.transform.position);
            if (distToRand <= 0.6f || _timer >= TimeSpentWandering)
            {
                rePositioned = true;
                posFound = false;
                _timer = 0;
            }
        }
    }

}
