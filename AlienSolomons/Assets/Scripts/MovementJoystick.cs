using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementJoystick : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] VirtualJoystick _moveJoystick;
    [SerializeField] VirtualJoystick _shootJoystick;

    public bool _shooting;

    private Vector3 _moveInput;
    Vector3 _playerDirection;

    private Vector3 _moveVelocity;
    private Rigidbody _rb;

    Animator _anim;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
       // _anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        _moveInput = _moveJoystick.InputDirection;
        _moveVelocity = _moveInput * _moveSpeed;

        Vector3 leftStickRot = _moveJoystick.InputDirection;
        _playerDirection = Vector3.right * leftStickRot.x + Vector3.forward * leftStickRot.z;
        // returns 1 if any rotation is being inputed from right joystick
        if (_playerDirection.sqrMagnitude > 0.0f)
            transform.rotation = Quaternion.LookRotation(_playerDirection * Time.deltaTime, Vector3.up);


        Vector3 rightStickRot = _shootJoystick.InputDirection;
        _playerDirection = Vector3.right * rightStickRot.x + Vector3.forward * rightStickRot.z;
        // returns 1 if any rotation is being inputed from right joystick
        if (_playerDirection.sqrMagnitude > 0.0f)
            transform.rotation = Quaternion.LookRotation(_playerDirection * Time.deltaTime, Vector3.up);

        //if (_moveJoystick.InputDirection != Vector3.zero)
        //    _anim.Play("Rifle Run");

        if (_shootJoystick.InputDirection != Vector3.zero)
        {
            _shooting = true;
        }
        else
            _shooting = false;
    }

    private void FixedUpdate()
    {
        //add velocity to player
        _rb.velocity = _moveVelocity;
    }
}

