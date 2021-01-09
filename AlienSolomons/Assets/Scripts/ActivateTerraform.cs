using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTerraform : MonoBehaviour
{
    private bool _areaAlreadyTerraformed;
    [SerializeField] GameObject terraformCam;

    private void Start()
    {
    }

    private void OnMouseUpAsButton()
    {
        if (_areaAlreadyTerraformed || TerraformManager.terraformNoOptionSlected)
            return;

        if (TerraformManager.terraformSlowChosen)
        {
            gameObject.GetComponent<TerraformSlow>().enabled = true;
            SetTerraformNoOptionSlectedTrue();
            terraformCam.SetActive(false);
            GameStateManager.ResumeGame();
        }

        else if (TerraformManager.terraformDamageChosen)
        {
            gameObject.GetComponent<TerraformDamage>().enabled = true;
            SetTerraformNoOptionSlectedTrue();
            terraformCam.SetActive(false);
            GameStateManager.ResumeGame();
        }
        _areaAlreadyTerraformed = true;
    }


    private void SetTerraformNoOptionSlectedTrue()
    {
        TerraformManager.terraformSlowChosen = false;
        TerraformManager.terraformDamageChosen = false;
        TerraformManager.terraformNoOptionSlected = true;
    }

}
