using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
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
    public void GoToScene(string level)
    {
        SceneManager.LoadScene(level);
    }
}
