using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAreaUnbuildable : MonoBehaviour
{
    public bool _hasAreaBeenBuiltOn = false;
    private void OnDrawGizmos()
    {
        if (_hasAreaBeenBuiltOn)
            Gizmos.DrawCube(new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Vector3.one);
    }
}
