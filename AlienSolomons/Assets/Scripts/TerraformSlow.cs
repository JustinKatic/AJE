using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TerraformSlow : MonoBehaviour
{
    [SerializeField] float speedReduction;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<NavMeshAgent>().speed *= speedReduction;
        }
    }
}
