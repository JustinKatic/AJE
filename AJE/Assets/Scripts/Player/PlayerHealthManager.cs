using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public FloatVariable maxHealth;
    public FloatVariable currentHealth;

    [SerializeField] GameObject floatingDmg;
    [SerializeField] TextMeshPro _healthTxt;
    [SerializeField] GameEvent PlayerDeath;
    [SerializeField] PlayerHealthBar PlayerHealthBar;
    [SerializeField] GameObject modelGeo;
    [SerializeField] GameObject model;
    new Renderer renderer;
    Material newMat;
    [SerializeField] BoolVariable playerIsDead;


    void Awake()
    {
        playerIsDead.Value = false;
        currentHealth.RuntimeValue = maxHealth.RuntimeValue;
        _healthTxt.text = currentHealth.RuntimeValue.ToString();

        renderer = modelGeo.GetComponent<Renderer>();
        newMat = new Material(renderer.material);
        renderer.material = newMat;
        PlayerHealthBar = gameObject.GetComponentInChildren<PlayerHealthBar>();
    }

    void Update()
    {
        if (currentHealth.RuntimeValue <= 0)
        {
            if (playerIsDead.Value == false)
            {
                Debug.Log("playerdied");
                PlayerDeath.Raise();
                playerIsDead.Value = true;
            }
        }
        if (currentHealth.RuntimeValue > maxHealth.RuntimeValue)
        {
            currentHealth.RuntimeValue = maxHealth.RuntimeValue;
            PlayerHealthBar.UpdateHealthBar();
        }
    }

    public void PlayerDmgFX()
    {
        StartCoroutine(TakeDamageVFX());
    }

    IEnumerator TakeDamageVFX()
    {
        //model.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        renderer.material.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(0.1f);
        renderer.material.DisableKeyword("_EMISSION");
        //model.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void Revive()
    {
        currentHealth.RuntimeValue = maxHealth.RuntimeValue;
    }
}
