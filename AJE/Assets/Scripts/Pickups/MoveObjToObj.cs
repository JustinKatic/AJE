using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjToObj : MonoBehaviour
{
    [SerializeField] StringVariable TagOfObjToMoveTowards;
    private GameObject target;
    [SerializeField] FloatVariable speed;
    private bool shouldObjMoveToPlayer;

    private void OnEnable()
    {
        target = GameObject.FindGameObjectWithTag(TagOfObjToMoveTowards.Value);
        shouldObjMoveToPlayer = false;
    }

    private void Update()
    {
        if (shouldObjMoveToPlayer)
        {
            if (target != null)
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed.RuntimeValue * Time.deltaTime);
        }
    }

    public void MoveObjToPlayer()
    {
        shouldObjMoveToPlayer = true;
    }
}
