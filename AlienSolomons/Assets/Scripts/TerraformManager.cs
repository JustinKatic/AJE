using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerraformManager : MonoBehaviour
{
    public static bool terraformNoOptionSlected = true;
    public static bool terraformSlowChosen = false;
    public static bool terraformDamageChosen = false;

    public void TerraformSlowChosen()
    {
        terraformSlowChosen = true;
        terraformDamageChosen = false;
        terraformNoOptionSlected = false;
    }

    public void TerraformDamageChosen()
    {
        terraformSlowChosen = false;
        terraformDamageChosen = true;
        terraformNoOptionSlected = false;
    }
}
