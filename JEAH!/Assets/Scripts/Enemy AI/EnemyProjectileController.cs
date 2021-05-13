using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EnemyProjectileController : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected float _bulletLife;
    [SerializeField] protected float _damage;

    [SerializeField] protected GameEvent UpdatePlayerHealthEvent;
    [SerializeField] protected FloatVariable PlayerCurrentHp;

    [SerializeField] GameObject floatingDmg;

    private void OnEnable()
    {
        Invoke("SetUnActive", _bulletLife);
    }

    void Update()
    {
        //Move bullet forward
        MoveBullet();
    }

    virtual protected void MoveBullet()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    virtual protected void SetUnActive()
    {
        gameObject.SetActive(false);
        CancelInvoke();
    }

    virtual protected void FloatingTxt(float damage, Transform transformToSpawnTxtAt, string type, Color32 color)
    {
        GameObject points = ObjectPooler.SharedInstance.GetPooledObject("FloatingTxt");
        points.transform.position = transformToSpawnTxtAt.position;
        points.transform.rotation = Quaternion.identity;
        TextMeshPro txt = points.transform.GetChild(0).GetComponent<TextMeshPro>();
        txt.text = type + damage.ToString();
        txt.color = color;
        points.SetActive(true);
    }
}
