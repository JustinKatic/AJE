using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogManager : MonoBehaviour
{
    [SerializeField] IntVariable nextWaveNum;

    [SerializeField] GameObject fog1;
    [SerializeField] GameObject fog2;
    [SerializeField] GameObject fog3;
    [SerializeField] GameObject fog4;
    [SerializeField] GameObject fog5;
    [SerializeField] GameObject fog6;
    [SerializeField] GameObject fog7;
    [SerializeField] GameObject fog8;

    [Header("REMOVE FOG")]
    [SerializeField] int RemoveFog1AtWaveX;
    [SerializeField] int RemoveFog2AtWaveX;
    [SerializeField] int RemoveFog3AtWaveX;
    [SerializeField] int RemoveFog4AtWaveX;
    [SerializeField] int RemoveFog5AtWaveX;
    [SerializeField] int RemoveFog6AtWaveX;
    [SerializeField] int RemoveFog7AtWaveX;
    [SerializeField] int RemoveFog8AtWaveX;

    [Header("SPAWN POINTS TO ACTIVATE WITH FOG")]
    [SerializeField] GameObject[] SpawnPointsToActivateWithFog1;
    [SerializeField] GameObject[] SpawnPointsToActivateWithFog2;
    [SerializeField] GameObject[] SpawnPointsToActivateWithFog3;
    [SerializeField] GameObject[] SpawnPointsToActivateWithFog4;
    [SerializeField] GameObject[] SpawnPointsToActivateWithFog5;
    [SerializeField] GameObject[] SpawnPointsToActivateWithFog6;
    [SerializeField] GameObject[] SpawnPointsToActivateWithFog7;
    [SerializeField] GameObject[] SpawnPointsToActivateWithFog8;


    [Header("SHRINES TO ACTIVATE WITH FOG")]
    [SerializeField] GameObject[] ShrinesToActivateWithFog1;
    [SerializeField] GameObject[] ShrinesToActivateWithFog2;
    [SerializeField] GameObject[] ShrinesToActivateWithFog3;
    [SerializeField] GameObject[] ShrinesToActivateWithFog4;
    [SerializeField] GameObject[] ShrinesToActivateWithFog5;
    [SerializeField] GameObject[] ShrinesToActivateWithFog6;
    [SerializeField] GameObject[] ShrinesToActivateWithFog7;
    [SerializeField] GameObject[] ShrinesToActivateWithFog8;

    public void CheckForFogToActivate()
    {
        if (nextWaveNum.RuntimeValue + 1 == RemoveFog1AtWaveX)
        {
            fog1.SetActive(false);
            SpawnPointsToActivateWithFog(SpawnPointsToActivateWithFog1);
            ShrinesToActivateWithFog(ShrinesToActivateWithFog1);
        }
        if (nextWaveNum.RuntimeValue + 1 == RemoveFog2AtWaveX)
        {
            fog2.SetActive(false);
            SpawnPointsToActivateWithFog(SpawnPointsToActivateWithFog2);
            ShrinesToActivateWithFog(ShrinesToActivateWithFog2);
        }
        if (nextWaveNum.RuntimeValue + 1 == RemoveFog3AtWaveX)
        {
            fog3.SetActive(false);
            SpawnPointsToActivateWithFog(SpawnPointsToActivateWithFog3);
            ShrinesToActivateWithFog(ShrinesToActivateWithFog3);
        }
        if (nextWaveNum.RuntimeValue + 1 == RemoveFog4AtWaveX)
        {
            fog4.SetActive(false);
            SpawnPointsToActivateWithFog(SpawnPointsToActivateWithFog4);
            ShrinesToActivateWithFog(ShrinesToActivateWithFog4);
        }
        if (nextWaveNum.RuntimeValue + 1 == RemoveFog5AtWaveX)
        {
            fog5.SetActive(false);
            SpawnPointsToActivateWithFog(SpawnPointsToActivateWithFog5);
            ShrinesToActivateWithFog(ShrinesToActivateWithFog5);
        }
        if (nextWaveNum.RuntimeValue + 1 == RemoveFog6AtWaveX)
        {
            fog6.SetActive(false);
            SpawnPointsToActivateWithFog(SpawnPointsToActivateWithFog6);
            ShrinesToActivateWithFog(ShrinesToActivateWithFog6);
        }
        if (nextWaveNum.RuntimeValue + 1 == RemoveFog7AtWaveX)
        {
            fog7.SetActive(false);

            SpawnPointsToActivateWithFog(SpawnPointsToActivateWithFog7);
            ShrinesToActivateWithFog(ShrinesToActivateWithFog7);

        }
        if (nextWaveNum.RuntimeValue + 1 == RemoveFog8AtWaveX)
        {
            fog8.SetActive(false);
            SpawnPointsToActivateWithFog(SpawnPointsToActivateWithFog8);
            ShrinesToActivateWithFog(ShrinesToActivateWithFog8);
        }

        void SpawnPointsToActivateWithFog(GameObject[] spawnPointToActivate)
        {
            if (spawnPointToActivate.Length >= 1)
            {
                for (int i = 0; i < spawnPointToActivate.Length; i++)
                {
                    spawnPointToActivate[i].gameObject.SetActive(true);
                }
            }
        }

        void ShrinesToActivateWithFog(GameObject[] spawnPointToActivate)
        {
            if (spawnPointToActivate.Length >= 1)
            {
                for (int i = 0; i < spawnPointToActivate.Length; i++)
                {
                    spawnPointToActivate[i].gameObject.SetActive(true);
                }
            }
        }

    }
}
