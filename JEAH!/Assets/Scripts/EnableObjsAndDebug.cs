using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObjsAndDebug : MonoBehaviour
{
    public bool shouldObjEnableAtStart;

    [SerializeField] GameObject enabledDebugObj;
    [SerializeField] GameObject disbaledDebugObj;

    void Awake()
    {
        enabledDebugObj.SetActive(false);
        disbaledDebugObj.SetActive(false);
        if (!shouldObjEnableAtStart)
            gameObject.SetActive(false);

    }
    private void OnValidate()
    {
        if (shouldObjEnableAtStart)
        {
            enabledDebugObj.SetActive(true);
            disbaledDebugObj.SetActive(false);
        }
        else
        {
            disbaledDebugObj.SetActive(true);
            enabledDebugObj.SetActive(false);
        }
    }
}
