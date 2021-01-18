using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{

    [SerializeField] float _damageEveryX = 1.0f;
    float _timer;
    [SerializeField] FloatVariable _damage;
    [SerializeField] GameEvent HurtPlayer;
    

    private void Start()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _timer += Time.deltaTime;
            if (_timer > _damageEveryX)
            {
                HurtPlayer.Raise();
                _timer = 0.0f;
            }
        }
    }
}
