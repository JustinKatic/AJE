using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] float _damage;
    [SerializeField] FloatVariable playersCurrentHealth;
    [SerializeField] GameObject floatingDmg;
    [SerializeField] GameEvent PlayerHealthIncreasedEvent;



    private void Start()
    {

    }
    private void OnEnable()
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playersCurrentHealth.RuntimeValue += _damage;
            FloatingTxt(_damage, other.transform, "+", Color.green);
            PlayerHealthIncreasedEvent.Raise();
            Destroy(gameObject);
        }
    }
}
