using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseTower : MonoBehaviour
{
    [SerializeField] Material _towerTexture;
    [SerializeField] GameObject _purchaseableTower;

    private Transform _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    public void BuyTower()
    {
        RaycastHit hit;
        if (Physics.Raycast(_player.position, Vector3.down, out hit))
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
