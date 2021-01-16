using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager instance;

    public GameObject _damageTower;

    [Header("All Towers")]
    public LayerMask m_LayerMask;

    [Header("Slow Tower Stats")]
    public float _slowDebuffAmount = 3f;
    public float _slowActivateEveryX = 1f;
    public float _slowRadius;
    public float _slowDamage;
    public float _slowedDuration = 2.0f;

    [Header("Damage Tower Stats")]
    public float _damageActivateEveryX = 1.0f;
    public float _damageDamage;
    public float _damageRadius;



    private Transform _player;

    private void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

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

    public void BuyTower(GameObject TowerSelect)
    {
        RaycastHit hit;
        if (Physics.Raycast(_player.position, Vector3.down, out hit))
        {
            if (hit.collider.tag == "Ground")
            {
                Instantiate(TowerSelect,
                    new Vector3(hit.collider.gameObject.transform.position.x,
                    hit.collider.gameObject.transform.transform.position.y + 0.65f,
                    hit.collider.gameObject.transform.position.z),
                    hit.collider.gameObject.transform.rotation);
            }
        }
    }
}
