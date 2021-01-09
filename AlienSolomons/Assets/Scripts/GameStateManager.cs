using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStateManager : MonoBehaviour
{
    public static void PauseGame()
    {
        Time.timeScale = 0;
    }
    public static void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void GoToScene(string level)
    {
        SceneManager.LoadScene(level);
    }

}
