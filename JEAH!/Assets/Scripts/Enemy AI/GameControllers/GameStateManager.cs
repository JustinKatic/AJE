using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStateManager : MonoBehaviour
{

    private void Awake()
    {
        Time.timeScale = 1;
    }
    public void PauseGameWithTimer(float seconds)
    {
        Debug.Log("pause game being called");
        //Time.timeScale = 0;
        StartCoroutine(PauseAfterX(seconds));

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void GoToScene(string level)
    {
        SceneManager.LoadScene(level);
    }
    IEnumerator PauseAfterX(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Time.timeScale = 0;
    }

    //IEnumerator ResumeAfterX()
    //{
    //    yield return new WaitForSeconds(1);
    //    Time.timeScale = 1;
    //}

}
