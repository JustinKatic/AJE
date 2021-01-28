using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class IntVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public int Value;

    public void SetValue(int newValue)
    {
        Value = newValue;
    }

    public void SetValue(IntVariable newValue)
    {
        Value = newValue.Value;
    }

    public void ApplyChange(int amount)
    {
        Value += amount;
    }

    public void ApplyChange(IntVariable amount)
    {
        Value += amount.Value;
    }
}
