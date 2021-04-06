using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenuScreen;
    [SerializeField] GameObject settingsScreen;
    [SerializeField] GameObject creditsScreen;
    //[SerializeField] GameObject shopScreen;
    //[SerializeField] GameObject equipmentScreen;
   // [SerializeField] GameObject generalsScreen;
    //[SerializeField] GameObject mapScreen;
    [SerializeField] GameObject pauseScreen;

    bool paused = false;
    private void Start()
    {
        Time.timeScale = 1;
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
       // shopScreen.SetActive(false);
        //equipmentScreen.SetActive(false);
       // generalsScreen.SetActive(false);
        //mapScreen.SetActive(false);
    }

    public void GoToSettings()
    {
        settingsScreen.SetActive(true);
        creditsScreen.SetActive(false);
        mainMenuScreen.SetActive(false);
      // shopScreen.SetActive(false);
        //equipmentScreen.SetActive(false);
       // generalsScreen.SetActive(false);
        //mapScreen.SetActive(false);
    }

    public void GoToCredits()
    {
        creditsScreen.SetActive(true);
        settingsScreen.SetActive(false);
        mainMenuScreen.SetActive(false);
      //  shopScreen.SetActive(false);
        //equipmentScreen.SetActive(false);
       // generalsScreen.SetActive(false);
        //mapScreen.SetActive(false);
    }
    public void GoToShop()
    {
      //  shopScreen.SetActive(true);
        creditsScreen.SetActive(false);
        settingsScreen.SetActive(false);
        mainMenuScreen.SetActive(false);
        //equipmentScreen.SetActive(false);
       // generalsScreen.SetActive(false);
        //mapScreen.SetActive(false);
    }
    public void GoToEquipment()
    {
        //equipmentScreen.SetActive(true);
      //  shopScreen.SetActive(false);
        creditsScreen.SetActive(false);
        settingsScreen.SetActive(false);
        mainMenuScreen.SetActive(false);
      //  generalsScreen.SetActive(false);
        //mapScreen.SetActive(false);
    }
    public void GoToGenerals()
    {
       // generalsScreen.SetActive(true);
       //equipmentScreen.SetActive(false);
      // shopScreen.SetActive(false);
        creditsScreen.SetActive(false);
        settingsScreen.SetActive(false);
        mainMenuScreen.SetActive(false);
        //mapScreen.SetActive(false);
    }
    public void GoToMap()
    {
        //mapScreen.SetActive(true);
        //generalsScreen.SetActive(false);
        //equipmentScreen.SetActive(false);
       //shopScreen.SetActive(false);
        creditsScreen.SetActive(false);
        settingsScreen.SetActive(false);
        mainMenuScreen.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }
}
