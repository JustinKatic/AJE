using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] GameObject _upgradePanel;
    [SerializeField] GameObject _terraformCam;

    public static float _currency = 0;


    GameStateManager gameStateManager;

    private void Start()
    {
        gameStateManager = gameObject.GetComponent<GameStateManager>();
    }
    public void DisplayUpgradeScreen()
    {
        _terraformCam.SetActive(true);
        gameStateManager.PauseGame();
        _upgradePanel.SetActive(true);
    }

    public void ExitDisplayUpgradeScreen()
    {
        _terraformCam.SetActive(false);
        gameStateManager.ResumeGame();
        _upgradePanel.SetActive(false);
    }


}
