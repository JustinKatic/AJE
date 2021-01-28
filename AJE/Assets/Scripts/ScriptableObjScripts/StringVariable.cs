using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class StringVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    public string Value;

    public void SetValue(string newString)
    {
        Value = newString;
    }

    public void SetValue(StringVariable newString)
    {
        Value = newString.Value;
    }
}
