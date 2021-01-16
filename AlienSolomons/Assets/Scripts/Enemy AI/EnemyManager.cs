using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public static EnemyManager instance;

    public List<Transform> _enemies;

    [Header("BarbarianStats")]
    public float _barbarianMaxHealth;
    public float _barbarianExpWorth;
    public float _barbarianDefaultMoveSpeed;

    [Header("ArcherStats")]
    public float _archerMaxHealth;
    public float _archerExpWorth;
    public float _archerDefaultMoveSpeed;
    public float _archerTimeBetweenShotsSpeed;
    public float _timeBetweenShots;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
            Destroy(gameObject);
    }
}
