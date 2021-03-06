using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagingOrb : MonoBehaviour
{

    [SerializeField] FloatVariable _critChance;
    [SerializeField] FloatVariable _critDamage;
    [SerializeField] FloatVariable _orbDamage;


    [SerializeField] Color _critDamageColor;
    [SerializeField] Color _normDmgColor;

    [SerializeField] GameObject floatingTxtPrefab;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            float randValue = Random.value;

            if (randValue < _critChance.RuntimeValue)
            {
                other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(_orbDamage.RuntimeValue * _critDamage.RuntimeValue);
                FloatingTxt(_orbDamage.RuntimeValue * _critDamage.RuntimeValue, other.transform, _critDamageColor);
            }
            else
            {
                other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(_orbDamage.RuntimeValue);
                FloatingTxt(_orbDamage.RuntimeValue, other.transform, _normDmgColor);
            }
        }
    }
    public void FloatingTxt(float damage, Transform transformToSpawnTxtAt, Color color)
    {
        GameObject points = Instantiate(floatingTxtPrefab, transformToSpawnTxtAt.position, Quaternion.identity);
        TextMeshPro textmeshPro = points.transform.GetChild(0).GetComponent<TextMeshPro>();
        textmeshPro.text = "-" + damage.ToString();
        textmeshPro.color = color;
    }
}
