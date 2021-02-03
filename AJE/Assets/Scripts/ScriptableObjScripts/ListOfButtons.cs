using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu]
public class ListOfButtons : ScriptableObject, ISerializationCallbackReceiver
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    public List<GameObject> List;

    [System.NonSerialized]
    public List<GameObject> RuntimeList;


    public void OnAfterDeserialize()
    {
        RuntimeList = List;
    }

    public void OnBeforeSerialize()
    {

    }
    public void ClearList()
    {
        List.Clear();
    }
}
