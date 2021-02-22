using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemy : MonoBehaviour
{

    [SerializeField] GameObject EnemyToSetActive;
    [SerializeField] GameObject ParticleToSetUnActive;

    [SerializeField] float timeUntilSpawn;

    private void OnEnable()
    {
        StartCoroutine(WaitForSeconds());
    }

     IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(timeUntilSpawn);
        EnemyToSetActive.SetActive(true);
        ParticleToSetUnActive.SetActive(false);
    }
}
