using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform[] enemy;
        public int count;
        public float rate;
        public Transform[] spawnPoints;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public static int _enemyCount;

    private int _currentEnemy = 0;


    public int NextWave
    {
        get { return nextWave + 1; }
    }

    public float timeBetweenWaves = 5f;
    private float waveCountdown;
    public float WaveCountdown
    {
        get { return waveCountdown; }
    }

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;
    public SpawnState State
    {
        get { return state; }
    }


    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (StartNextWave())
            {
                _currentEnemy = 0;
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }


    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
        }
        else
        {
            nextWave++;
        }
    }

    bool StartNextWave()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;

            if (_enemyCount <= 0)
            {
                return true;
            }
        }
        return false;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy[i], _wave);
            yield return new WaitForSeconds(_wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy, Wave _wave)
    {
        Transform _sp = _wave.spawnPoints[_currentEnemy];

        GameObject enemy = ObjectPooler.SharedInstance.GetPooledObject(_enemy.name);
        enemy.transform.position = _sp.position;
        enemy.transform.rotation = _sp.rotation;
        enemy.SetActive(true);
        GameStats.instance._enemies.Add(enemy.transform);
        _enemyCount += 1;

        _currentEnemy++;
    }
}
