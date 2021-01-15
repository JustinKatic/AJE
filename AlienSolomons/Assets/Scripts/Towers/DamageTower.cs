using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTower : MonoBehaviour
{
    public LayerMask m_LayerMask;

    [SerializeField] float _activateEveryX = 1.0f;
    float _timer;
    [SerializeField] float _damage;

    public List<GameObject> _enemies;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _activateEveryX)
        {
            _timer = 0;
            DealDamageToEnemiesInList(_enemies);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _enemies.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        _enemies.Remove(other.gameObject);
    }

    private void DealDamageToEnemiesInList(List<GameObject> listOfEnemies)
    {
        if (listOfEnemies.Count <= 0)
            return;

        for (int i = 0; i < listOfEnemies.Count; i++)
        {
            if (_enemies[i].activeSelf == false)
            {
                listOfEnemies.Remove(listOfEnemies[i]);
            }
            else
            {
                listOfEnemies[i].GetComponent<EnemyHealthManager>().HurtEnemy(_damage);
            }
        }
    }
}
