using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] VirtualJoystick _moveJoystick;

    [SerializeField] FloatVariable _moveSpeed;
    [SerializeField] BoolVariable _shooting;
    [SerializeField] FloatVariable PlayerInGameCurrency;

    [SerializeField] ListOfTransforms ListOfEnemies;

    [SerializeField] CharacterController controller;


    private Vector3 _moveInput;
    Vector3 _playerDirection;

    private Vector3 _moveVelocity;

    Animator _anim;

    private Transform cloestTarget;

    private void Awake()
    {
       
    }

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {            
        _moveInput = _moveJoystick.InputDirection;
        _moveVelocity = _moveInput * _moveSpeed.Value;
        controller.Move(_moveVelocity * Time.deltaTime);

        Vector3 leftStickRot = _moveJoystick.InputDirection;
        _playerDirection = Vector3.right * leftStickRot.x + Vector3.forward * leftStickRot.z;
        // returns 1 if any rotation is being inputed from right joystick
        if (_playerDirection.sqrMagnitude > 0.0f)
            transform.rotation = Quaternion.LookRotation(_playerDirection * Time.deltaTime, Vector3.up);


        if (cloestTarget == null || cloestTarget.gameObject.activeSelf == false)
        {
            cloestTarget = GetClosestEnemy(ListOfEnemies.List);
        }

        if (_moveJoystick.InputDirection != Vector3.zero)
        {
            _anim.SetBool("IsRunning", true);
            _shooting.Value = false;
            cloestTarget = GetClosestEnemy(ListOfEnemies.List);
        }
        else
        {
            _anim.SetBool("IsRunning", false);
            _shooting.Value = true;
            transform.LookAt(cloestTarget);
        }

        if (ListOfEnemies.List.Count == 0)
        {
            _shooting.Value = false;
        }
    }


    public Transform GetClosestEnemy(List<Transform> enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }
}

