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
        public float waveTimer;
    }

    public Wave[] waves;
    private int nextWave = 0;
    private UpgradeManager _upgradeManager;

    public static int _enemyCount;


    public int NextWave
    {
        get { return nextWave + 1; }
    }

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;
    public float WaveCountdown
    {
        get { return waveCountdown; }
    }

    private float searchCountdown = 1f;

    [SerializeField] float waveLengthx;

    private SpawnState state = SpawnState.COUNTING;
    public SpawnState State
    {
        get { return state; }
    }

    public GameObject victoryScreen;

    void Start()
    {
        _upgradeManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UpgradeManager>();

        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced.");
        }
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (StartNextWave())
            {
                _upgradeManager.DisplayUpgradeScreen();
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
            victoryScreen.SetActive(true);
        }
        else
        {
            nextWave++;
        }
    }

    bool StartNextWave()
    {
        waves[NextWave - 1].waveTimer -= Time.deltaTime;
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;

            if (waves[NextWave - 1].waveTimer <= 0f)
            {
                return true;
            }

            if (_enemyCount <= 5)
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
            SpawnEnemy(_wave.enemy[Random.Range(0, _wave.enemy.Length)]);
            yield return new WaitForSeconds(_wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];

        if (_enemy.tag == "Enemy1" || _enemy.tag == "Enemy2" || _enemy.tag == "Enemy3" || _enemy.tag == "EnemyRanged")
        {
            GameObject enemy = ObjectPooler.SharedInstance.GetPooledObject(_enemy.name);
            enemy.transform.position = _sp.position;
            enemy.transform.rotation = _sp.rotation;
            enemy.SetActive(true);
            _enemyCount += 1;
        }
    }
}
