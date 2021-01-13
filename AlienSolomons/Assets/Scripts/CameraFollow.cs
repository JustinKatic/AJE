using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    float posX;
    float posZ;

    [SerializeField] float posXminClamp;
    [SerializeField] float posXmaxClamp;

    [SerializeField] float posZminClamp;
    [SerializeField] float posZMaxClamp;

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

        transform.position = new Vector3(posX = Mathf.Clamp(posX, posXminClamp, posXmaxClamp), 0, posZ = Mathf.Clamp(posZ, posZminClamp, posZMaxClamp));
    }
}
