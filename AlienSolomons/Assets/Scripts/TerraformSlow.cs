using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TerraformSlow : MonoBehaviour
{
    [SerializeField] float _slowedSpeed;

    [SerializeField] Material _slowMat;

    private Material _defaultMat;


    private void Awake()
    {
        _defaultMat = gameObject.GetComponent<MeshRenderer>().material;
    }

    private void OnEnable()
    {
        gameObject.GetComponent<MeshRenderer>().material = _slowMat;
    }
    private void OnDisable()
    {
        gameObject.GetComponent<MeshRenderer>().material = _defaultMat;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!enabled)
            return;

        if (other.gameObject.tag == "Enemy1" || other.gameObject.tag == "Enemy2" || other.gameObject.tag == "Enemy3" || other.gameObject.tag == "EnemyRanged")
        {
            EnemyMovement enemyMovement = other.gameObject.GetComponent<EnemyMovement>();
            if (enemyMovement.GetEnemyMoveSpeed() <= enemyMovement._defaultMoveSpeed - _slowedSpeed)
                return;
            else
                enemyMovement.SetEnemyMoveSpeed(enemyMovement._defaultMoveSpeed - _slowedSpeed);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!enabled)
            return;

        if (other.gameObject.tag == "Enemy1" || other.gameObject.tag == "Enemy2" ||
            other.gameObject.tag == "Enemy3" || other.gameObject.tag == "EnemyRanged")
        {

            EnemyMovement enemyMovement = other.gameObject.GetComponent<EnemyMovement>();
            enemyMovement.SetEnemyMoveSpeed(enemyMovement._defaultMoveSpeed);
        }
    }

}
