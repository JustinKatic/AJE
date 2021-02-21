using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    FloatingJoystick _moveJoystick;

    [SerializeField] FloatVariable _moveSpeed;
    [SerializeField] FloatVariable PlayerInGameCurrency;


    [SerializeField] CharacterController controller;


    private Vector3 _moveInput;
    Vector3 _playerDirection;

    private Vector3 _moveVelocity;

    Animator _anim;


    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _moveJoystick = FindObjectOfType<FloatingJoystick>();
    }

    void Update()
    {
        //Move Input
        _playerDirection = Vector3.forward * _moveJoystick.Vertical + Vector3.right * _moveJoystick.Horizontal;
        _moveInput = _playerDirection.normalized;
        _moveVelocity = _moveInput * _moveSpeed.RuntimeValue;
        //Player Rotation
        if (_playerDirection.sqrMagnitude > 0.0f)
            transform.rotation = Quaternion.LookRotation(_playerDirection * Time.deltaTime, Vector3.up);


        if (_playerDirection != Vector3.zero)
        {
           // _anim.SetBool("IsRunning", true);
        }
        else
        {
           // _anim.SetBool("IsRunning", false);
        }
    }


    private void FixedUpdate()
    {
        //movePlayer
        controller.Move(_moveVelocity * Time.deltaTime);
    }
    //public Transform GetClosestEnemy(List<Transform> enemies)
    //{
    //    Transform bestTarget = null;
    //    float closestDistanceSqr = Mathf.Infinity;
    //    Vector3 currentPosition = transform.position;
    //    foreach (Transform potentialTarget in enemies)
    //    {
    //        Vector3 directionToTarget = potentialTarget.position - currentPosition;
    //        float dSqrToTarget = directionToTarget.sqrMagnitude;
    //        if (dSqrToTarget < closestDistanceSqr)
    //        {
    //            closestDistanceSqr = dSqrToTarget;
    //            bestTarget = potentialTarget;
    //        }
    //    }
    //    return bestTarget;
    //}
}

