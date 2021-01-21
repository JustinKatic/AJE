using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyingMove : MonoBehaviour
{
    private Transform targetDestination;

    [SerializeField] FloatVariable MyMoveSpeed;
    [SerializeField] FloatVariable MyChargeSpeed;

    [SerializeField] FloatVariable SlowTowerDuration;
    [SerializeField] FloatVariable MyAttackRange;
    [SerializeField] StringVariable TagOfTargetDestination;

    private bool canMove;


    private void Start()
    {
        targetDestination = GameObject.FindGameObjectWithTag(TagOfTargetDestination.Value).transform;
    }
    private void OnEnable()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        canMove = true;
    }
    private void Update()
    {
        float dist = Vector3.Distance(transform.position, targetDestination.position);
        if (dist > MyAttackRange.Value)
        {
            transform.LookAt(targetDestination);
            if(canMove)
            transform.position += transform.forward * Time.deltaTime * MyMoveSpeed.Value;           
        }
        else
        {
            if (canMove)
                transform.position += transform.forward * Time.deltaTime * MyChargeSpeed.Value;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == TagOfTargetDestination.Value)
        {
            canMove = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == TagOfTargetDestination.Value)
            canMove = true;
    }
}
