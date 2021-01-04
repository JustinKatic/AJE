using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarBilboard : MonoBehaviour
{
    Transform cam;

    void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }


    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
