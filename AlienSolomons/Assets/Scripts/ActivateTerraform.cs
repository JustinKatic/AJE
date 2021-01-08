using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTerraform : MonoBehaviour
{
    private bool _areaAlreadyTerraformed;

    UpgradeManager _upgradeManager;

    private void Start()
    {
        _upgradeManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UpgradeManager>();
    }

    private void OnMouseUpAsButton()
    {
        if (_areaAlreadyTerraformed || TerraformManager.terraformNoOptionSlected)
            return;

        if (TerraformManager.terraformSlowChosen)
        {
            gameObject.GetComponent<TerraformSlow>().enabled = true;
            SetTerraformNoOptionSlectedTrue();
            _upgradeManager.DisplayUpgradeScreen();
        }

        else if (TerraformManager.terraformDamageChosen)
        {
            gameObject.GetComponent<TerraformDamage>().enabled = true;
            SetTerraformNoOptionSlectedTrue();
            _upgradeManager.DisplayUpgradeScreen();
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
