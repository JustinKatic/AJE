using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStats : MonoBehaviour
{
    public static GameStats instance;


    [Header("Player Current Stats")]
    public float _currency;
    public float _playerExp;
    public int _playerLevel;
    public float _currentExpNeededForLevel;

    [Header("Starting Stats")]
    public float _playerMaxHealth;
    public float level1ExpNeeded;

    [Header("Player Bullet stats")]
    public float _playerBulletSpeed;
    public float _playerBulletDmg;
    public float _playerFireRate;

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
