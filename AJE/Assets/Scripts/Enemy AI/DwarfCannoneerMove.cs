using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfCannoneerMove : EnemyMove
{
    [SerializeField] FloatVariable MyAttackRange;
    DwarfCannoneerShoot dwarfCannoneerShoot;
    public bool rePositioned;
    [SerializeField] GameObject randomPos;
    public LayerMask Waypoints;

    bool posFound = false;

    private void Awake()
    {
        dwarfCannoneerShoot = gameObject.GetComponent<DwarfCannoneerShoot>();
    }
    public override void Move()
    {
        //move towards player
        float dist = Vector3.Distance(transform.position, targetDestination.position);
        if (rePositioned == true && dist > MyAttackRange.Value)
        {
            dwarfCannoneerShoot.canShoot = false;
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(targetDestination.position);
        }
        //stop and shoot at player
        else if (rePositioned == true && dist < MyAttackRange.Value)
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
                randomPos = hitColliders[Random.Range(0,hitColliders.Length)].gameObject;
                posFound = true;
            }
            navMeshAgent.isStopped = false;
            dwarfCannoneerShoot.canShoot = false;
            navMeshAgent.SetDestination(randomPos.transform.position);
            float distToRand = Vector3.Distance(transform.position, randomPos.transform.position);
            if (distToRand <= 0.6f)
            {
                rePositioned = true;
                posFound = false;
            }
        }
    }

}
