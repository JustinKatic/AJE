using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DebugEnviromentSquaresInEditor : MonoBehaviour
{
    public ActiveEnviromentSquare activeEnviromentSquare;

    void OnDrawGizmosSelected()
    {
        if (activeEnviromentSquare.activateDamageEnviroment)
        {
            Gizmos.color = new Color(1, 0, 0, .4f);
            Gizmos.DrawCube(new Vector3(transform.position.x,transform.position.y +2,transform.position.z), new Vector3(2, 2, 2));
        }
        if (activeEnviromentSquare.activateRangeEnviroment)
        {
            Gizmos.color = new Color(0, 1, 0, .4f);
            Gizmos.DrawCube(new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), new Vector3(2, 2, 2));
        }
        if (activeEnviromentSquare.activateSpeedEnviroment)
        {
            Gizmos.color = new Color(0, 0, 1, .4f);
            Gizmos.DrawCube(new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), new Vector3(2, 2, 2));
        }
    }

}

