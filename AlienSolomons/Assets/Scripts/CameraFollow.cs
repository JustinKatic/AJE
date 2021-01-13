using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
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
        posX = target.transform.position.x ;
        posZ = target.transform.position.z;

        transform.position = new Vector3(posX = Mathf.Clamp(posX, -18, 19), 0, posZ = Mathf.Clamp(posZ, -10f, 18.5f));
    }
}
