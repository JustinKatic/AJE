using UnityEngine;
using System.Collections;


public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform[] enemy;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;


    private int _currentEnemy = 0;

    [SerializeField] ListOfTransforms ListOfEnemies;

    [SerializeField] GameObject fog1;
    [SerializeField] GameObject fog2;
    [SerializeField] GameObject fog3;
    [SerializeField] GameObject fog4;

    [SerializeField] int fog1Activation;
    [SerializeField] int fog2Activation;
    [SerializeField] int fog3Activation;
    [SerializeField] int fog4Activation;



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

    public SpawnState State { get; private set; } = SpawnState.COUNTING;

    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        if (State == SpawnState.WAITING)
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
            if (State != SpawnState.SPAWNING)
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
        State = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
        }
        else
        {
            nextWave++;
        }
        if(nextWave == fog1Activation)
        {
            fog1.SetActive(false);
        }
        if (nextWave == fog2Activation)
        {
            fog2.SetActive(false);
        }
        if (nextWave == fog3Activation)
        {
            fog3.SetActive(false);
        }
        if (nextWave == fog4Activation)
        {
            fog4.SetActive(false);
        }
    }

    bool StartNextWave()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;

            if (ListOfEnemies.RuntimeList.Count <= 0)
            {
                return true;
            }
        }
        return false;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        State = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.enemy.Length; i++)
        {
            SpawnEnemy(_wave.enemy[i], _wave);
            yield return new WaitForSeconds(_wave.rate);
        }

        State = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy, Wave _wave)
    {
        GameObject[] spawnPoints;
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoints");
        Transform _sp = spawnPoints[_currentEnemy].transform;

        GameObject enemy = ObjectPooler.SharedInstance.GetPooledObject(_enemy.name);
        enemy.transform.position = _sp.position;
        enemy.transform.rotation = _sp.rotation;
        enemy.SetActive(true);
        ListOfEnemies.RuntimeList.Add(enemy.transform);

        _currentEnemy++;
        if (_currentEnemy >= spawnPoints.Length)
            _currentEnemy = 0;
    }
}
