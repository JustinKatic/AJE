using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStats : MonoBehaviour
{
    public static GameStats instance;

    public float _currency;
    public float _playerExp;
    public float _playerMaxHealth;
    public float _maxExp;
    public int _playerLevel;

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
