using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RangeTowerProjectile : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _bulletLife;
    [SerializeField] float _damage;

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

    void MoveBullet()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    void SetUnActive()
    {
        gameObject.SetActive(false);
        CancelInvoke();
    }

    void FloatingTxt(float damage, Transform transformToSpawnTxtAt)
    {
        GameObject points = ObjectPooler.SharedInstance.GetPooledObject("FloatingTxt");
        points.transform.position = transformToSpawnTxtAt.position;
        points.transform.rotation = Quaternion.identity;
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-" + damage.ToString();
        points.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            other.GetComponent<EnemyHealthManager>().HurtEnemy(_damage);
            SetUnActive();
        }
        else if (other.gameObject.tag == "Wall")
        {
            SetUnActive();
        }
    }
}
