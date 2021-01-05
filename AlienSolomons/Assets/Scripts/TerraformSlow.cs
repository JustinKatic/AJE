using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TerraformSlow : MonoBehaviour
{
    [SerializeField] float _slowedSpeed;

    private float _defaultSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _defaultSpeed = other.GetComponent<NavMeshAgent>().speed;
            other.gameObject.GetComponent<NavMeshAgent>().speed = _slowedSpeed;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
            other.gameObject.GetComponent<NavMeshAgent>().speed = _defaultSpeed;
    }
}
