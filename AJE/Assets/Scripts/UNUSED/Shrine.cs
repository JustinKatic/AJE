using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrine : MonoBehaviour
{
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject playerHoldPowerupPoint;

    [HideInInspector] public bool canObjSpawn;
    bool objSpawned;

    private void OnEnable()
    {
        canObjSpawn = true;
    }
    public void SpawnObj(GameObject objToSpawn)
    {
        if (canObjSpawn)
        {
            GameObject powerup = Instantiate(objToSpawn, spawnPoint.transform.position, Quaternion.identity);
            powerup.transform.SetParent(spawnPoint.transform);
            canObjSpawn = false;
            objSpawned = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && objSpawned)
        {
            GameObject powerup = spawnPoint.transform.GetChild(0).gameObject;
            powerup.transform.position = playerHoldPowerupPoint.transform.position;
            powerup.transform.SetParent(playerHoldPowerupPoint.transform);
            objSpawned = false;
            canObjSpawn = true;
        }
    }
}
