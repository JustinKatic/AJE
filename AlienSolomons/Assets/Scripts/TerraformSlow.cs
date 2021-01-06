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
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<NavMeshAgent>().speed -= _slowedSpeed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
            other.gameObject.GetComponent<NavMeshAgent>().speed += _slowedSpeed;
    }
}
