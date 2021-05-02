using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void GoToScene(string level)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(level);
    }
}
