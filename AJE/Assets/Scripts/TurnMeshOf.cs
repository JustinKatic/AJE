using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMeshOf : MonoBehaviour
{
    void Awake()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
