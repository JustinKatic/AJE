using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStateManager : MonoBehaviour
{
    public void PauseGameWithTimer()
    {
        Debug.Log("pause game being called");
        //Time.timeScale = 0;
        StartCoroutine(PauseAfterX());

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
    IEnumerator PauseAfterX()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
    }

    //IEnumerator ResumeAfterX()
    //{
    //    yield return new WaitForSeconds(1);
    //    Time.timeScale = 1;
    //}

}
