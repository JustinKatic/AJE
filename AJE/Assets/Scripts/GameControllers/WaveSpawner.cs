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
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;
    [SerializeField] GameEvent WaveCompletedEvent;

    [SerializeField] GameEvent AllWavesCompleted;



    private int _currentEnemy = 0;

    public float timeBetweenWaves = 5f;
    [SerializeField] float timeBeforeFirstWave = 10f;
    private float waveCountdown;

    [SerializeField] ListOfTransforms ListOfEnemies;

    [SerializeField] TextMeshProUGUI waveCounterTxt;


    [Header("Fog1")]
    [SerializeField] GameObject fog1;
    [SerializeField] int RemoveFog1AtWaveX;
    [SerializeField] GameObject[] SpawnPointsToActivateWithFog1;
    [Header("Fog2")]
    [SerializeField] GameObject fog2;
    [SerializeField] int RemoveFog2AtWaveX;
    [SerializeField] GameObject[] SpawnPointsToActivateWithFog2;
    [Header("Fog3")]
    [SerializeField] GameObject fog3;
    [SerializeField] int RemoveFog3AtWaveX;
    [SerializeField] GameObject[] SpawnPointsToActivateWithFog3;
    [Header("Fog4")]
    [SerializeField] GameObject fog4;
    [SerializeField] int RemoveFog4AtWaveX;
    [SerializeField] GameObject[] SpawnPointsToActivateWithFog4;


    private float searchCountdown = 1f;

    public SpawnState State { get; private set; } = SpawnState.COUNTING;

    void Start()
    {
        waveCountdown = timeBeforeFirstWave;
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
                waveCounterTxt.text = string.Empty;
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
            waveCounterTxt.text = Mathf.Round(waveCountdown).ToString();
        }
    }


    void WaveCompleted()
    {
        State = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;
        WaveCompletedEvent.Raise();

        if (nextWave + 1 > waves.Length - 1)
        {
            AllWavesCompleted.Raise();           
        }
        else
        {
            nextWave++;
        }
        if (nextWave == RemoveFog1AtWaveX)
        {
            fog1.SetActive(false);
            if (SpawnPointsToActivateWithFog1.Length > 1)
            {
                for (int i = 0; i < SpawnPointsToActivateWithFog1.Length; i++)
                {
                    SpawnPointsToActivateWithFog1[i].gameObject.SetActive(true);
                }
            }
        }
        if (nextWave == RemoveFog2AtWaveX)
        {
            fog2.SetActive(false);
            if (SpawnPointsToActivateWithFog2.Length > 1)
            {
                for (int i = 0; i < SpawnPointsToActivateWithFog2.Length; i++)
                {
                    SpawnPointsToActivateWithFog2[i].gameObject.SetActive(true);
                }
            }
        }
        if (nextWave == RemoveFog3AtWaveX)
        {
            fog3.SetActive(false);
            if (SpawnPointsToActivateWithFog3.Length > 1)
            {
                for (int i = 0; i < SpawnPointsToActivateWithFog3.Length; i++)
                {
                    SpawnPointsToActivateWithFog3[i].gameObject.SetActive(true);
                }
            }
        }
        if (nextWave == RemoveFog4AtWaveX)
        {
            fog4.SetActive(false);
            if (SpawnPointsToActivateWithFog4.Length > 1)
            {
                for (int i = 0; i < SpawnPointsToActivateWithFog4.Length; i++)
                {
                    SpawnPointsToActivateWithFog4[i].gameObject.SetActive(true);
                }
            }
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
        enemy.SetActive(true);
        ListOfEnemies.RuntimeList.Add(enemy.transform);

        _currentEnemy++;
        if (_currentEnemy >= spawnPoints.Length)
            _currentEnemy = 0;
    }
}
