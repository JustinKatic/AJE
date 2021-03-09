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

    public GameObject dmgSquare;
    public GameObject speedSquare;
    public GameObject rangeSquare;



    private void Start()
    {
        dmgSquare.SetActive(false);
        speedSquare.SetActive(false);
        rangeSquare.SetActive(false);


        if (activateDamageEnviroment)
            Instantiate(damageEnviromentFx, transform.position, damageEnviromentFx.transform.rotation);

        if (activateSpeedEnviroment)
            Instantiate(speedEnviromentFx, transform.position, speedEnviromentFx.transform.rotation);

        if (activateRangeEnviroment)
            Instantiate(rangeEnviromentFx, transform.position, rangeEnviromentFx.transform.rotation);
    }


    private void OnValidate()
    {
        if (activateDamageEnviroment)
            dmgSquare.SetActive(true);
        else
            dmgSquare.SetActive(false);


        if (activateSpeedEnviroment)
            speedSquare.SetActive(true);
        else
            speedSquare.SetActive(false);


        if (activateRangeEnviroment)
            rangeSquare.SetActive(true);
        else
            rangeSquare.SetActive(false);

    }
}

