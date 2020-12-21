using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealthManager : MonoBehaviour
{
    [SerializeField] float _maxHealth;
    private float _currentHealth;
    NavMeshAgent navMeshAgent;
    PlayerHurt hurtScript;
    EnemyMovement moveScript;

    private void Start()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        hurtScript = gameObject.GetComponent<PlayerHurt>();
        moveScript = gameObject.GetComponent<EnemyMovement>();
    }

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (_currentHealth <= 0)
            Die();
    }


    public void HurtEnemy(float damage)
    {
        _currentHealth -= damage;
    }

    void Die()
    {
        navMeshAgent.enabled = false;
        moveScript.enabled = false;
        hurtScript.enabled = false;
        //gameObject.SetActive(false);
    }
}
