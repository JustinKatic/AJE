using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePlayerWhileColliding : MonoBehaviour
{
    [SerializeField] float _CollidingDamageEveryX;
    private float _timer;
    [SerializeField] float _damage;
    [SerializeField] FloatVariable playersCurrentHealth;
    [SerializeField] GameObject floatingDmg;
    [SerializeField] GameEvent PlayerHealthDecreasedEvent;

    private void Start()
    {
        _timer = _CollidingDamageEveryX;
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
            if (_timer > _CollidingDamageEveryX)
            {
                playersCurrentHealth.RuntimeValue -= _damage;
                FloatingText(_damage, other.transform.position);
                PlayerHealthDecreasedEvent.Raise();
                _timer = 0.0f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _timer = _CollidingDamageEveryX;
        }
    }
}
