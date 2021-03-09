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


    public void CheckForFogToActivate()
    {
        if (nextWaveNum.RuntimeValue + 1 == RemoveFog1AtWaveX)
        {
            StartCoroutine(FogShake(fog1));
            if (SpawnPointsToActivateWithFog1.Length >= 1)
            {
                for (int i = 0; i < SpawnPointsToActivateWithFog1.Length; i++)
                {
                    SpawnPointsToActivateWithFog1[i].gameObject.SetActive(true);
                }
            }
        }
        if (nextWaveNum.RuntimeValue + 1 == RemoveFog2AtWaveX)
        {
            StartCoroutine(FogShake(fog2));
            if (SpawnPointsToActivateWithFog2.Length >= 1)
            {
                for (int i = 0; i < SpawnPointsToActivateWithFog2.Length; i++)
                {
                    SpawnPointsToActivateWithFog2[i].gameObject.SetActive(true);
                }
            }
        }
        if (nextWaveNum.RuntimeValue + 1 == RemoveFog3AtWaveX)
        {
            StartCoroutine(FogShake(fog3));
            if (SpawnPointsToActivateWithFog3.Length >= 1)
            {
                for (int i = 0; i < SpawnPointsToActivateWithFog3.Length; i++)
                {
                    SpawnPointsToActivateWithFog3[i].gameObject.SetActive(true);
                }
            }
        }
        if (nextWaveNum.RuntimeValue + 1 == RemoveFog4AtWaveX)
        {
            StartCoroutine(FogShake(fog4));
            if (SpawnPointsToActivateWithFog4.Length >= 1)
            {
                for (int i = 0; i < SpawnPointsToActivateWithFog4.Length; i++)
                {
                    SpawnPointsToActivateWithFog4[i].gameObject.SetActive(true);
                }
            }
        }
        if (nextWaveNum.RuntimeValue + 1 == RemoveFog5AtWaveX)
        {
            StartCoroutine(FogShake(fog5));
            if (SpawnPointsToActivateWithFog5.Length >= 1)
            {
                for (int i = 0; i < SpawnPointsToActivateWithFog5.Length; i++)
                {
                    SpawnPointsToActivateWithFog5[i].gameObject.SetActive(true);
                }
            }
        }
        if (nextWaveNum.RuntimeValue + 1 == RemoveFog6AtWaveX)
        {
            StartCoroutine(FogShake(fog6));
            if (SpawnPointsToActivateWithFog6.Length >= 1)
            {
                for (int i = 0; i < SpawnPointsToActivateWithFog6.Length; i++)
                {
                    SpawnPointsToActivateWithFog6[i].gameObject.SetActive(true);
                }
            }
        }
        if (nextWaveNum.RuntimeValue + 1 == RemoveFog7AtWaveX)
        {
            StartCoroutine(FogShake(fog7));
            if (SpawnPointsToActivateWithFog7.Length >= 1)
            {
                for (int i = 0; i < SpawnPointsToActivateWithFog7.Length; i++)
                {
                    SpawnPointsToActivateWithFog7[i].gameObject.SetActive(true);
                }
            }
        }
        if (nextWaveNum.RuntimeValue + 1 == RemoveFog8AtWaveX)
        {
            StartCoroutine(FogShake(fog8));
            if (SpawnPointsToActivateWithFog8.Length >= 1)
            {
                for (int i = 0; i < SpawnPointsToActivateWithFog8.Length; i++)
                {
                    SpawnPointsToActivateWithFog8[i].gameObject.SetActive(true);
                }
            }
        }
        IEnumerator FogShake(GameObject fogOb)
        {
            //shake.ShakeFog();
            yield return new WaitForSeconds(1.4f);
            fogOb.SetActive(false);
        }
    }
}
