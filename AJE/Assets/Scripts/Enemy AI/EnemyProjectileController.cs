using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EnemyProjectileController : MonoBehaviour
{
    [SerializeField] protected FloatVariable _speed;
    [SerializeField] protected FloatVariable _bulletLife;
    [SerializeField] protected FloatVariable _damage;

    [SerializeField] protected StringVariable TagOfObjectCanHit;
    [SerializeField] protected GameEvent UpdatePlayerHealthEvent;
    [SerializeField] protected FloatVariable PlayerCurrentHp;

    [SerializeField] GameObject floatingDmg;

    private void OnEnable()
    {
        Invoke("SetUnActive", _bulletLife.RuntimeValue);
    }

    void Update()
    {
        //Move bullet forward
        MoveBullet();
    }

    virtual protected void MoveBullet()
    {
        transform.Translate(Vector3.forward * _speed.RuntimeValue * Time.deltaTime);
    }

    protected void SetUnActive()
    {
        gameObject.SetActive(false);
        CancelInvoke();
    }

    virtual protected void FloatingText(float damage, Vector3 ObjPos)
    {
        GameObject points = Instantiate(floatingDmg, ObjPos, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-" + damage.ToString();
    }

}
