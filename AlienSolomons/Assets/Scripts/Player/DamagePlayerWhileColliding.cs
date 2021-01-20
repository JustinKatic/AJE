using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePlayerWhileColliding : MonoBehaviour
{
    [SerializeField] float _damageEveryX = 1.0f;
    float _timer;
    [SerializeField] FloatVariable _damage;
    [SerializeField] FloatVariable PlayersCurrentHealth;
    [SerializeField] GameObject floatingDmg;


    private void Start()
    {

    }
    public void FloatingText(float damage)
    {
        GameObject points = Instantiate(floatingDmg, transform.position, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-" + damage.ToString();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _timer += Time.deltaTime;
            if (_timer > _damageEveryX)
            {
                PlayersCurrentHealth.Value -= _damage.Value;
                FloatingText(_damage.Value);
                _timer = 0.0f;
            }
        }
    }
}
