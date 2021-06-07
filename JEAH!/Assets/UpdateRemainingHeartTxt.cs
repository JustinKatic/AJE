using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateRemainingHeartTxt : MonoBehaviour
{
    public TextMeshProUGUI heartText;
    public IntVariable hearts;
    private void OnEnable()
    {
        heartText.text = hearts.RuntimeValue.ToString();
    }
}
