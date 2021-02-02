using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class ListOfTransforms : ScriptableObject, ISerializationCallbackReceiver
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    public List<Transform> List;

    [System.NonSerialized]
    public List<Transform> RuntimeList;


    public void OnAfterDeserialize()
    {
        RuntimeList = List;
        RuntimeList.Clear();
        RuntimeList.AddRange(List);
    }

    public void OnBeforeSerialize()
    {

    }
}