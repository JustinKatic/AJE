using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DebugEnviromentSquaresInEditor : MonoBehaviour
{
    public ActiveEnviromentSquare activeEnviromentSquare;

    public GameObject transenvirSquare;

    private void OnValidate()
    {
        Debug.Log("vali");
        if(activeEnviromentSquare.activateDamageEnviroment)
        transenvirSquare.SetActive(true);
        else if (activeEnviromentSquare.activateDamageEnviroment)
            transenvirSquare.SetActive(false);
    }

}

