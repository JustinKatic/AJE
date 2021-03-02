using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public FloatVariable OrbRotateSpeed;
    GameObject player;
    [SerializeField] StringVariable TagOfObjectsToRotateAround;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(TagOfObjectsToRotateAround.Value);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        transform.RotateAround(player.transform.position, Vector3.up, OrbRotateSpeed.RuntimeValue * Time.deltaTime);
    }
}
