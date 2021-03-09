using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActiveEnviromentSquare : MonoBehaviour
{
    public bool activateDamageEnviroment;
    [SerializeField] GameObject damageEnviromentFx;
    public float damageEnviromentMultiplier;

    public bool activateSpeedEnviroment;
    [SerializeField] GameObject speedEnviromentFx;
    public float speedEnviromentMultiplier;


    public bool activateRangeEnviroment;
    [SerializeField] GameObject rangeEnviromentFx;
    public float rangeEnviromentMultiplier;

    public GameObject transenvirSquare;
    new Renderer model;
    Material newMat;

    private void Start()
    {
        transenvirSquare.SetActive(false);

        if (activateDamageEnviroment)
            Instantiate(damageEnviromentFx, transform.position, damageEnviromentFx.transform.rotation);

        if (activateSpeedEnviroment)
            Instantiate(speedEnviromentFx, transform.position, speedEnviromentFx.transform.rotation);

        if (activateRangeEnviroment)
            Instantiate(rangeEnviromentFx, transform.position, rangeEnviromentFx.transform.rotation);
    }


    private void OnValidate()
    {
        model = transenvirSquare.GetComponent<Renderer>();
        newMat = new Material(model.material);
        model.material = newMat;
  
        if (activateDamageEnviroment || activateRangeEnviroment || activateSpeedEnviroment)
        {
            transenvirSquare.SetActive(true);

            if (activateDamageEnviroment)
                model.material.color = Color.red;
            if (activateSpeedEnviroment)
                model.material.color = Color.blue;
            if (activateRangeEnviroment)
                model.material.color = Color.green;
        }
        else
            transenvirSquare.SetActive(false);

    }
}

