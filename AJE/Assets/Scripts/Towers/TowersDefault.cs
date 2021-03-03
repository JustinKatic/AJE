using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class TowersDefault : MonoBehaviour
{
    private float _timer;
    [SerializeField] protected LayerMaskVariable EnemyLayerMask;
    [SerializeField] protected FloatVariable ActivateEveryX;
    [SerializeField] protected FloatVariable TowerRadius;
    [SerializeField] protected FloatVariable TowerDamage;

    [SerializeField] protected GameObject floatingDmg;

    [SerializeField] protected ParticleSystem pulseFX;
    private void Start()
    {
        //pulseFX.transform.localScale = new Vector3(TowerRadius.Value, TowerRadius.Value, TowerRadius.Value);
        //pulseFX.GetComponent<ParticleSystem>().emissionRate = ActivateEveryX.Value * 
    }
    private void OnEnable()
    {
        var emission = pulseFX.emission;
        emission.SetBursts(new ParticleSystem.Burst[] { new ParticleSystem.Burst(0f, 1, 1000, ActivateEveryX.RuntimeValue) });
        var main = pulseFX.main;
        main.startLifetime = ActivateEveryX.RuntimeValue;
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= ActivateEveryX.RuntimeValue)
        {
            MyCollisions();
            _timer = 0;
        }
    }

    protected virtual void MyCollisions()
    {
        Debug.Log("Select a specifc tower script");
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, TowerRadius.RuntimeValue);
    }
}
