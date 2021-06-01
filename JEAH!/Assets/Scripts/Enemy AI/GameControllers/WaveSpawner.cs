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

    bool allWavesComplete = false;

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

    [Header("SAVE")]
    [SerializeField] BoolVariableList unlockedLevels;
    [SerializeField] int currentLevel;


    IEnumerator cutsceneCo;

    [Header("CUTSCENE")]
    [SerializeField] GameObject UIManager;
    private Animator cutsceneAnim;
    [SerializeField] bool isThereACutscene;

    [SerializeField] bool isThereACutscene1Img;
    [SerializeField] GameObject cutsceneImg1;

    [SerializeField] bool isThereACutscene2Img;
    [SerializeField] GameObject cutsceneImg2;

    [SerializeField] bool isThereACutscene3Img;
    [SerializeField] GameObject cutsceneImg3;

    [SerializeField] float lengthOfCutscene1;
    [SerializeField] float lengthOfCutscene2;
    [SerializeField] float lengthOfCutscene3;





    public SpawnState State { get; private set; } = SpawnState.COUNTING;

    void Start()
    {
        cutsceneAnim = UIManager.GetComponent<Animator>();
        currentWaveTxt.text = waves[nextWaveNum.RuntimeValue].name;
        waveCountdown = timeBeforeFirstWave;
        ShowBuildPromptText();
    }

    void Update()
    {
        if (allWavesComplete)
            return;

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
            allWavesComplete = true;
            EndLevel();
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
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        Transform _sp = spawnPoints[randSpawnPoint].transform;

        GameObject enemy = ObjectPooler.SharedInstance.GetPooledObject(_enemy.name);
        enemy.transform.position = new Vector3(_sp.position.x, _sp.position.y - 0.95f, _sp.position.z);
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
            yield return new WaitForSeconds(timeBeforeFirstWave);
            buildPromptTxt.SetActive(false);
        }
    }

    void EndLevel()
    {
        //Save and unlock next level.
        if (unlockedLevels.boolList[currentLevel] != null)
            unlockedLevels.boolList[currentLevel].locked = false;
        GameSaveManager.instance.SaveGame(unlockedLevels, "unlockedLevels");

        if (isThereACutscene)
        {
            cutsceneCo = Cutscene();
            StartCoroutine(cutsceneCo);
        }
        else
            AllWavesCompleted.Raise();
            SFXAudioManager.instance.Play("Victory");

    }

    IEnumerator Cutscene()
    {
        cutsceneAnim.Play("FadeInFadeOut");

        yield return new WaitForSeconds(1f);


        //set cutscene 1 active
        if (isThereACutscene1Img)
            cutsceneImg1.SetActive(true);
        //if no cutscene 1 fade out and exit
        else
        {
            cutsceneAnim.Play("FadeInFadeOut");
            yield return new WaitForSeconds(1);
            Invoke("CallAllWavesComplete", 1);
            StopCoroutine(cutsceneCo);
        }


        yield return new WaitForSeconds(lengthOfCutscene1);
        cutsceneAnim.Play("FadeInFadeOut");
        yield return new WaitForSeconds(1f);
        cutsceneImg1.SetActive(false);

        //load cutscene 2
        if (isThereACutscene2Img)
            cutsceneImg2.SetActive(true);
        else
        {
            cutsceneAnim.Play("FadeInFadeOut");
            yield return new WaitForSeconds(1);
            Invoke("CallAllWavesComplete", 1);
            StopCoroutine(cutsceneCo);
        }

        yield return new WaitForSeconds(lengthOfCutscene2);
        cutsceneAnim.Play("FadeInFadeOut");
        yield return new WaitForSeconds(1f);
        cutsceneImg2.SetActive(false);

        


        if (isThereACutscene3Img)
            cutsceneImg3.SetActive(true);
        else
        {
            cutsceneAnim.Play("FadeInFadeOut");
            yield return new WaitForSeconds(1);
            Invoke("CallAllWavesComplete", 1);
            StopCoroutine(cutsceneCo);
        }


        yield return new WaitForSeconds(lengthOfCutscene3);
        cutsceneAnim.Play("FadeInFadeOut");
        yield return new WaitForSeconds(1);
        cutsceneImg3.SetActive(false);
        AllWavesCompleted.Raise();
        StopCoroutine(cutsceneCo);

    }

    void CallAllWavesComplete()
    {
        AllWavesCompleted.Raise();
    }

}