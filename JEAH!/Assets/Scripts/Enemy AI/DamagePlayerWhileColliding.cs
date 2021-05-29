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
    [SerializeField] BoolVariable isPlayerInvincible;
    [SerializeField] ScriptableSoundObj meleeAttackSFX;



    private void Start()
    {
        _timer = _CollidingDamageEveryX;
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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _timer += Time.deltaTime;
            if (_timer > _CollidingDamageEveryX)
            {
                if (isPlayerInvincible.Value == false)
                {
                    playersCurrentHealth.RuntimeValue -= _damage;
                    FloatingTxt(_damage, other.transform, "-", Color.red);
                    PlayerHealthDecreasedEvent.Raise();
                    _timer = 0.0f;
                    if (meleeAttackSFX)
                        meleeAttackSFX.Play();
                    else
                        Debug.Log("no death sound added" + gameObject.name);
                }
            }
        }
        else if (other.gameObject.tag == "DamageableTower")
        {
            _timer += Time.deltaTime;
            if (_timer > _CollidingDamageEveryX)
            {
                FloatingTxt(_damage, other.transform, "-", Color.red);
                other.gameObject.GetComponent<TowerHealth>().HurtEnemy(_damage, true);
                _timer = 0.0f;
                if (meleeAttackSFX)
                    meleeAttackSFX.Play();
                else
                    Debug.Log("no death sound added" + gameObject.name);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "DamageableTower")
        {
            _timer = _CollidingDamageEveryX;
        }
    }
}
