using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] Material _towerTexture;

    public void PlaceTower()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.collider.tag == "Ground")
            {               
                hit.collider.gameObject.GetComponent<MeshRenderer>().material = _towerTexture;
            }
        }
    }
}
