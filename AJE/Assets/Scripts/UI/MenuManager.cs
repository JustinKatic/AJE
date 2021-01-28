using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject credits;
    [SerializeField] GameObject controls;

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

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        credits.SetActive(false);
        controls.SetActive(false);
    }

    public void SettingsMenu()
    {
        settingsMenu.SetActive(true);
        credits.SetActive(false);
        controls.SetActive(false);
        mainMenu.SetActive(false);
    }

    public void ShowCredits()
    {
        credits.SetActive(true);
        settingsMenu.SetActive(false);
        controls.SetActive(false);
        mainMenu.SetActive(false);
    }

    public void ShowControls()
    {
        controls.SetActive(true);
        credits.SetActive(false);
        settingsMenu.SetActive(false);
        mainMenu.SetActive(false);
    }

}
