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

    [SerializeField] IntVariable nextWaveNum;

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





    FogShake fog1Shake;
    FogShake fog2Shake;
    FogShake fog3Shake;
    FogShake fog4Shake;
    FogShake fog5Shake;

    public SpawnState State { get; private set; } = SpawnState.COUNTING;

    void Start()
    {
        currentWaveTxt.text = waves[nextWaveNum.RuntimeValue].name;
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
                StartCoroutine(SpawnWave(waves[nextWaveNum.RuntimeValue]));
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


        if (nextWaveNum.RuntimeValue + 1 == waves.Length)
        {
            AllWavesCompleted.Raise();
        }
        else
        {
            nextWaveNum.RuntimeValue++;
            currentWaveTxt.text = waves[nextWaveNum.RuntimeValue].name;
            WaveCompletedEvent.Raise();
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
            SpawnEnemy(_wave.enemy[i]);
            yield return new WaitForSeconds(_wave.rate);
        }

        State = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
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
}
