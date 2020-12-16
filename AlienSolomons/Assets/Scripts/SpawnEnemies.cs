using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] Transform[] _spawnPoints;
    [SerializeField] GameObject[] _listOfEnemies;

    private void Start()
    {
        InvokeRepeating("Spawn", 0, 5);
    }

    private void Spawn()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Instantiate(_listOfEnemies[Random.Range(0, _listOfEnemies.Length)], _spawnPoints[i].transform.position, Quaternion.identity);
        }
    }
}
