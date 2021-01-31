using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpButton : MonoBehaviour
{
    private Button button;
    private GameObject UpgradePanel;

    private void Awake()
    {
        UpgradePanel = GameObject.FindGameObjectWithTag("UpgradePanel");
        button = gameObject.GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(ResumeGame);
        button.onClick.AddListener(SetUpgradePanelFalse);
        button.onClick.AddListener(ApplyPowerUp);
    }

    virtual protected void ApplyPowerUp()
    {
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void SetUpgradePanelFalse()
    {
        UpgradePanel.SetActive(false);
    }
}
