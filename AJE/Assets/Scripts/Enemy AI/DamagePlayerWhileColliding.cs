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
    [SerializeField] GameEvent PlayerHealthUpdated;




    private void Start()
    {

    }
    public void FloatingText(float damage, Vector3 ObjPos)
    {
        GameObject points = Instantiate(floatingDmg, ObjPos, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-" + damage.ToString();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _timer += Time.deltaTime;
            if (_timer > _damageEveryX)
            {
                PlayerHealthUpdated.Raise();
                PlayersCurrentHealth.RuntimeValue -= _damage.RuntimeValue;
                FloatingText(_damage.RuntimeValue, other.transform.position);
                _timer = 0.0f;
            }
        }
    }
}
