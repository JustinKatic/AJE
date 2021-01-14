using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{

    RaycastHit hitInfo;
    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down,out hitInfo))
        {
            if(hitInfo.collider.tag == "Ground")
            {
                Debug.Log("HitGround");
            }
        }
    }


}
