using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class boolListWithStringName
{
    public string levelName;
    public bool locked;
}


[CreateAssetMenu(fileName = "boolList", menuName = "BoolVarList")]
public class BoolVariableList : ScriptableObject
{

    public boolListWithStringName[] boolList;
}
