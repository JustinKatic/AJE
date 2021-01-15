using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseTower : MonoBehaviour
{
    [SerializeField] Material _towerTexture;
    [SerializeField] GameObject _purchaseableTower;

    public void BuyTrap()
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

    public void BuyTrapRaised()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.collider.tag == "Ground")
            {
                Instantiate(_purchaseableTower,
                    new Vector3(hit.collider.gameObject.transform.position.x,
                    hit.collider.gameObject.transform.transform.position.y + 0.65f,
                    hit.collider.gameObject.transform.position.z),
                    hit.collider.gameObject.transform.rotation);
            }
        }
    }
}
