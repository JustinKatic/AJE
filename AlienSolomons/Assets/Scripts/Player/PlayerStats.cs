using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    [Header("Player Current Stats")]
    public float _currency;
    public float _playerExp;

   // public float level1ExpNeeded;



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
