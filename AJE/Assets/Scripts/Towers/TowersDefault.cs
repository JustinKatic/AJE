using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;
using TMPro;


public class TowersDefault : MonoBehaviour
{
    private float _timer;
    [SerializeField] public LayerMask EnemyLayerMask;
    [SerializeField] public float ActivateEveryX;
    [SerializeField] public float TowerRadius;
    [SerializeField] public float TowerDamage;

    [SerializeField] protected GameObject floatingDmg;

    [SerializeField] protected ParticleSystem pulseFX;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DmgPowerup")
        {
            other.gameObject.SetActive(false);
            TowerDamage = TowerDamage + other.gameObject.GetComponent<Powerup>().dmgPowerupValueMultiplier * TowerDamage / 100;    
        }
       else if (other.gameObject.tag == "SpeedPowerup")
        {
            other.gameObject.SetActive(false);
            ActivateEveryX = ActivateEveryX - other.gameObject.GetComponent<Powerup>().speedPowerupValueMultiplier * ActivateEveryX / 100;
            SetTowerEffects();
        }
        else if (other.gameObject.tag == "RangePowerup")
        {
            other.gameObject.SetActive(false);
            TowerRadius = TowerRadius + other.gameObject.GetComponent<Powerup>().rangePowerupValueMultiplier * TowerRadius / 100;
            SetTowerEffects();
        }
    }

    public void SetTowerEffects()
    {
        ParticleSystem.EmissionModule emission = pulseFX.emission;
        emission.SetBursts(new ParticleSystem.Burst[] { new ParticleSystem.Burst(0f, 1, 1000, ActivateEveryX) });
        ParticleSystem.MainModule main = pulseFX.main;
        main.startSize = TowerRadius * 2;
        main.startLifetime = ActivateEveryX;
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= ActivateEveryX)
        {
            MyCollisions();
            _timer = 0;
        }
    }

    protected virtual void MyCollisions()
    {
        Debug.Log("Select a specifc tower script");
    }

    public void FloatingTxt(float damage, Transform transformToSpawnTxtAt, string type, Color32 color)
    {
        GameObject points = ObjectPooler.SharedInstance.GetPooledObject("FloatingTxt");
        points.transform.position = transformToSpawnTxtAt.position;
        points.transform.rotation = Quaternion.identity;
        TextMeshPro txt = points.transform.GetChild(0).GetComponent<TextMeshPro>();
        txt.text = type + damage.ToString();
        txt.color = color;
        points.SetActive(true);
    }

    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, TowerRadius);
    //}
}
