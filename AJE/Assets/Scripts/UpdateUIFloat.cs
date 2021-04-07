using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UpdateUIFloat : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextToUpdate;
    [SerializeField] FloatVariable FloatNeedingUpdated;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        UpdateText(FloatNeedingUpdated);
    }

    public void UpdateText(FloatVariable floatVariable)
    {
        anim.Play("CurrencyTextScale");
        TextToUpdate.text = floatVariable.RuntimeValue.ToString();
    }
}
