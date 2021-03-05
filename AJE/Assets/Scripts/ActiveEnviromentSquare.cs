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


    private void Awake()
    {
        if (activateDamageEnviroment)
            Instantiate(damageEnviromentFx, transform.position, damageEnviromentFx.transform.rotation);

        if (activateSpeedEnviroment)
            Instantiate(speedEnviromentFx, transform.position, damageEnviromentFx.transform.rotation);

        if (activateRangeEnviroment)
            Instantiate(rangeEnviromentFx, transform.position, damageEnviromentFx.transform.rotation);
    }

}
