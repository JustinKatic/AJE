using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{

    [SerializeField] List <GameObject> powerUps;

    private GameObject[] listOfActiveShrines;


    public void SpawnPowerUpObj()
    {
        listOfActiveShrines = GameObject.FindGameObjectsWithTag("Shrine");
        if (listOfActiveShrines.Length > 0)
        {
            int randShrine = Random.Range(0, listOfActiveShrines.Length - 1);
            int randPowerup = Random.Range(0, powerUps.Count - 1);
            if (powerUps.Count > 0)
            {
                listOfActiveShrines[randShrine].GetComponent<Shrine>().SpawnObj(powerUps[randPowerup]);
                powerUps.RemoveAt(randPowerup);
            }
        }
    }
}
