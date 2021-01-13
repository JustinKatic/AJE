using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    float posX;
    float posZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //transform.position = target.transform.position + offset;
        posZ = target.transform.position.z;
        posX = target.transform.position.x;
        transform.position = new Vector3 (posX = Mathf.Clamp(posX, -13, 13), offset.y, posZ = Mathf.Clamp(posZ, -20, offset.z));
    }
}
