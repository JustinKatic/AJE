using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;


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
    private int nextWave = 0;


    [Header("WAVE DETAILS")]
    [SerializeField] Wave[] waves;
    private int _currentEnemy = 0;
    private float searchCountdown = 1f;

    [SerializeField] float timeBetweenWaves = 5f;
    [SerializeField] float timeBeforeFirstWave = 10f;
    private float waveCountdown;

    [SerializeField] FloatVariable NumberOfActiveEnemies;

    [Header("EVENTS")]
    [SerializeField] GameEvent WaveCompletedEvent;
    [SerializeField] GameEvent AllWavesCompleted;



    [Header("UI TEXT")]
    [SerializeField] TextMeshProUGUI waveCounterTxt;
    [SerializeField] TextMeshProUGUI currentWaveTxt;
    [SerializeField] GameObject buildPromptTxt;

    [Header("REMOVE FOG")]
    [SerializeField] GameObject fog1;
    [SerializeField] int RemoveFog1AtWaveX;
    [SerializeField] GameObject fog2;
    [SerializeField] int RemoveFog2AtWaveX;
    [SerializeField] GameObject fog3;
    [SerializeField] int RemoveFog3AtWaveX;
    [SerializeField] GameObject fog4;
    [SerializeField] int RemoveFog4AtWaveX;
    [SerializeField] GameObject fog5;
    [SerializeField] int RemoveFog5AtWaveX;
    [SerializeField] GameObject fog6;
    [SerializeField] int RemoveFog6AtWaveX;
    [SerializeField] GameObject fog7;
    [SerializeField] int RemoveFog7AtWaveX;
    [SerializeField] GameObject fog8;
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


    FogShake fog1Shake;
    FogShake fog2Shake;
    FogShake fog3Shake;
    FogShake fog4Shake;
    FogShake fog5Shake;

    public SpawnState State { get; private set; } = SpawnState.COUNTING;

    void Start()
    {
        currentWaveTxt.text = waves[nextWave].name;
        waveCountdown = timeBeforeFirstWave;
        ShowBuildPromptText();
        //fog1Shake = fog1.GetComponent<FogShake>();
        //fog2Shake = fog2.GetComponent<FogShake>();
        //fog3Shake = fog3.GetComponent<FogShake>();
        //fog4Shake = fog4.GetComponent<FogShake>();
        //fog5Shake = fog5.GetComponent<FogShake>();

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
                waveCounterTxt.text = string.Empty;
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

        if (nextWave + 1 < waves.Length)
            currentWaveTxt.text = waves[nextWave + 1].name;

        WaveCompletedEvent.Raise();

        if (nextWave + 1 > waves.Length - 1)
        {
            AllWavesCompleted.Raise();
        }
        else
        {
            nextWave++;
        }


        if (nextWave + 1 == RemoveFog1AtWaveX)
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
        else if (nextWave + 1 == RemoveFog2AtWaveX)
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
        else if (nextWave + 1 == RemoveFog3AtWaveX)
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
        else if (nextWave + 1 == RemoveFog4AtWaveX)
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
        else if (nextWave + 1 == RemoveFog5AtWaveX)
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
        else if (nextWave + 1 == RemoveFog6AtWaveX)
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
        else if (nextWave + 1 == RemoveFog7AtWaveX)
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
        else if (nextWave + 1 == RemoveFog8AtWaveX)
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
    }

    bool StartNextWave()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;

            if (NumberOfActiveEnemies.RuntimeValue <= 0)
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
        NumberOfActiveEnemies.RuntimeValue += 1;

        _currentEnemy++;
        if (_currentEnemy >= spawnPoints.Length)
            _currentEnemy = 0;
    }

    void ShowBuildPromptText()
    {
        StartCoroutine(ShowTextForX());
        IEnumerator ShowTextForX()
        {
            buildPromptTxt.SetActive(true);
            yield return new WaitForSeconds(timeBeforeFirstWave);
            buildPromptTxt.SetActive(false);
        }
    }

    IEnumerator FogShake(GameObject fogOb)
    {
        //shake.ShakeFog();
        yield return new WaitForSeconds(1.4f);
        fogOb.SetActive(false);
    }
}
