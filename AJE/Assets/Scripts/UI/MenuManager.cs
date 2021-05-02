using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenuScreen;
    [SerializeField] GameObject settingsScreen;
    [SerializeField] GameObject creditsScreen;
    [SerializeField] GameObject shopScreen;

    [SerializeField] BoolVariableList unlockedLevels;

    [SerializeField] GameObject[] lockedLevelOverlay;


    private void Start()
    {
        if (!GameSaveManager.instance.DoesSaveFileExist("unlockedLevels"))
        {
            for (int i = 0; i < unlockedLevels.boolList.Length; i++)
            {
                unlockedLevels.boolList[i].locked = true;
            }
            unlockedLevels.boolList[0].locked = false;
        }


        GameSaveManager.instance.LoadGame(unlockedLevels, "unlockedLevels");

        for (int i = 0; i < unlockedLevels.boolList.Length; i++)
        {
            if (unlockedLevels.boolList[i].locked == true)
                lockedLevelOverlay[i].SetActive(true);
            else
                lockedLevelOverlay[i].SetActive(false);
        }
    }
    public void GoToScene(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void GoToMainMenu()
    {
        mainMenuScreen.SetActive(true);
        settingsScreen.SetActive(false);
        creditsScreen.SetActive(false);
        shopScreen.SetActive(false);
    }

    public void GoToSettings()
    {
        settingsScreen.SetActive(true);
        creditsScreen.SetActive(false);
        mainMenuScreen.SetActive(false);
        shopScreen.SetActive(false);
    }

    public void GoToCredits()
    {
        creditsScreen.SetActive(true);
        settingsScreen.SetActive(false);
        mainMenuScreen.SetActive(false);
        shopScreen.SetActive(false);
    }
    public void GoToShop()
    {
        shopScreen.SetActive(true);
        creditsScreen.SetActive(false);
        settingsScreen.SetActive(false);
        mainMenuScreen.SetActive(false);
    }
    public void GoToEquipment()
    {
        shopScreen.SetActive(false);
        creditsScreen.SetActive(false);
        settingsScreen.SetActive(false);
        mainMenuScreen.SetActive(false);
    }
    public void GoToGenerals()
    {
        shopScreen.SetActive(false);
        creditsScreen.SetActive(false);
        settingsScreen.SetActive(false);
        mainMenuScreen.SetActive(false);
    }
    public void GoToMap()
    {
        shopScreen.SetActive(false);
        creditsScreen.SetActive(false);
        settingsScreen.SetActive(false);
        mainMenuScreen.SetActive(false);
    }
}
