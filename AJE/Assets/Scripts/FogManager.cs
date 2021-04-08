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
    Animator[] anim;

    public void CheckForFogToActivate()
    {
        if (nextWaveNum.RuntimeValue + 1 == RemoveFog1AtWaveX)
        {
            StartCoroutine(DespawnFog(fog1));
            SpawnPointsToActivateWithFog(SpawnPointsToActivateWithFog1);
        }
        if (nextWaveNum.RuntimeValue + 1 == RemoveFog2AtWaveX)
        {
            StartCoroutine(DespawnFog(fog2));
            SpawnPointsToActivateWithFog(SpawnPointsToActivateWithFog2);
        }
        if (nextWaveNum.RuntimeValue + 1 == RemoveFog3AtWaveX)
        {
            StartCoroutine(DespawnFog(fog3));
            SpawnPointsToActivateWithFog(SpawnPointsToActivateWithFog3);
        }
        if (nextWaveNum.RuntimeValue + 1 == RemoveFog4AtWaveX)
        {
            StartCoroutine(DespawnFog(fog4));
            SpawnPointsToActivateWithFog(SpawnPointsToActivateWithFog4);
        }
        if (nextWaveNum.RuntimeValue + 1 == RemoveFog5AtWaveX)
        {
            StartCoroutine(DespawnFog(fog5));
            SpawnPointsToActivateWithFog(SpawnPointsToActivateWithFog5);
        }
        if (nextWaveNum.RuntimeValue + 1 == RemoveFog6AtWaveX)
        {
            StartCoroutine(DespawnFog(fog6));
            SpawnPointsToActivateWithFog(SpawnPointsToActivateWithFog6);
        }
        if (nextWaveNum.RuntimeValue + 1 == RemoveFog7AtWaveX)
        {
            StartCoroutine(DespawnFog(fog7));
            SpawnPointsToActivateWithFog(SpawnPointsToActivateWithFog7);

        }
        if (nextWaveNum.RuntimeValue + 1 == RemoveFog8AtWaveX)
        {
            StartCoroutine(DespawnFog(fog8));
            SpawnPointsToActivateWithFog(SpawnPointsToActivateWithFog8);
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
    }

    IEnumerator DespawnFog(GameObject fogName)
    {
        anim = fogName.transform.GetComponentsInChildren<Animator>();
        foreach (Animator a in anim)
        {
            float randomTime = Random.Range(0, 1);
            
            a.Play("FogShrink");
            yield return new WaitForSeconds(randomTime);
        }
        yield return new WaitForSeconds(2);
        fogName.SetActive(false);
    }
}
