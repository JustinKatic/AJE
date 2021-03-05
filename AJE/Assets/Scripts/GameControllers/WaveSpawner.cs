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

    [SerializeField] TextMeshProUGUI currentWaveTxt;

    [SerializeField] GameObject buildPromptTxt;


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
    [Header("Fog5")]
    [SerializeField] GameObject fog5;
    [SerializeField] int RemoveFog5AtWaveX;
    [SerializeField] GameObject[] SpawnPointsToActivateWithFog5;
    [Header("Fog6")]
    [SerializeField] GameObject fog6;
    [SerializeField] int RemoveFog6AtWaveX;
    [SerializeField] GameObject[] SpawnPointsToActivateWithFog6;
    [Header("Fog7")]
    [SerializeField] GameObject fog7;
    [SerializeField] int RemoveFog7AtWaveX;
    [SerializeField] GameObject[] SpawnPointsToActivateWithFog7;
    [Header("Fog8")]
    [SerializeField] GameObject fog8;
    [SerializeField] int RemoveFog8AtWaveX;
    [SerializeField] GameObject[] SpawnPointsToActivateWithFog;

    private float searchCountdown = 1f;

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
        fog1Shake = fog1.GetComponent<FogShake>();
        fog2Shake = fog2.GetComponent<FogShake>();
        fog3Shake = fog3.GetComponent<FogShake>();
        fog4Shake = fog4.GetComponent<FogShake>();
        fog5Shake = fog5.GetComponent<FogShake>();

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
        if (nextWave == RemoveFog1AtWaveX)
        {
            StartCoroutine(FogShake(fog1Shake, fog1));
            if (SpawnPointsToActivateWithFog1.Length >= 1)
            {
                for (int i = 0; i < SpawnPointsToActivateWithFog1.Length; i++)
                {
                    SpawnPointsToActivateWithFog1[i].gameObject.SetActive(true);
                }
            }
        }
        if (nextWave == RemoveFog2AtWaveX)
        {
            StartCoroutine(FogShake(fog2Shake, fog2));
            if (SpawnPointsToActivateWithFog2.Length >= 1)
            {
                for (int i = 0; i < SpawnPointsToActivateWithFog2.Length; i++)
                {
                    SpawnPointsToActivateWithFog2[i].gameObject.SetActive(true);
                }
            }
        }
        if (nextWave == RemoveFog3AtWaveX)
        {
            StartCoroutine(FogShake(fog3Shake, fog3));
            if (SpawnPointsToActivateWithFog3.Length >= 1)
            {
                for (int i = 0; i < SpawnPointsToActivateWithFog3.Length; i++)
                {
                    SpawnPointsToActivateWithFog3[i].gameObject.SetActive(true);
                }
            }
        }
        if (nextWave == RemoveFog4AtWaveX)
        {
            StartCoroutine(FogShake(fog4Shake, fog4));
            if (SpawnPointsToActivateWithFog4.Length >= 1)
            {
                for (int i = 0; i < SpawnPointsToActivateWithFog4.Length; i++)
                {
                    SpawnPointsToActivateWithFog4[i].gameObject.SetActive(true);
                }
            }
        }
        if (nextWave == RemoveFog5AtWaveX)
        {
            StartCoroutine(FogShake(fog5Shake, fog5));
            if (SpawnPointsToActivateWithFog5.Length >= 1)
            {
                for (int i = 0; i < SpawnPointsToActivateWithFog5.Length; i++)
                {
                    SpawnPointsToActivateWithFog5[i].gameObject.SetActive(true);
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

    IEnumerator FogShake(FogShake shake, GameObject fogOb)
    {
        //shake.ShakeFog();
        yield return new WaitForSeconds(1.4f);
        fogOb.SetActive(false);
    }
}
