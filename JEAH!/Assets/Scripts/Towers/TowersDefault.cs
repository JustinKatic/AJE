using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;
using TMPro;


public class TowersDefault : MonoBehaviour
{
    private float _timer;
    [SerializeField] public LayerMask EnemyLayerMask;
    [SerializeField] public float TowerDamage;
    [SerializeField] public float TowerRadius;
    [SerializeField] public float ActivateEveryX;

    [SerializeField] protected GameObject floatingDmg;


    protected void OnTriggerEnter(Collider other)
    {
        MyTriggerEffect();
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

    protected virtual void MyTriggerEffect()
    {
        
    }

    protected virtual void MyCollisions()
    {
        
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

   void OnDrawGizmos()
   {
       Gizmos.color = Color.red;
       Gizmos.DrawWireSphere(transform.position, TowerRadius);
   }
}
