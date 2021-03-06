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

    public void FloatingTxt(float damage, Transform transformToSpawnTxtAt)
    {
        GameObject points = ObjectPooler.SharedInstance.GetPooledObject("FloatingTxt");
        points.transform.position = transformToSpawnTxtAt.position;
        points.transform.rotation = Quaternion.identity;
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-" + damage.ToString();
        points.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _timer += Time.deltaTime;
            if (_timer > _CollidingDamageEveryX)
            {
                playersCurrentHealth.RuntimeValue -= _damage;
                FloatingTxt(_damage, other.transform);
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
