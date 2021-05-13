using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class FloatVariable : ScriptableObject, ISerializationCallbackReceiver
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public float Value;

   // [System.NonSerialized]
    public float RuntimeValue;


public void OnAfterDeserialize()
    {
        RuntimeValue = Value;
    }

    public void OnBeforeSerialize()
    {
       
    }
}

