using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{

    public void PlaceTower()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, Vector3.down, out hitInfo))
        {
            if (hitInfo.collider.tag == "Ground")
            {
                hitInfo.collider.gameObject.SetActive(false);
            }
        }
    }
}
