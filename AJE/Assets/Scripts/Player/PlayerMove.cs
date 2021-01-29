using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] FloatingJoystick _moveJoystick;

    [SerializeField] FloatVariable _moveSpeed;
    [SerializeField] BoolVariable _shooting;
    [SerializeField] FloatVariable PlayerInGameCurrency;

    [SerializeField] ListOfTransforms ListOfEnemies;

    [SerializeField] CharacterController controller;

    [SerializeField] Transform CloestTargetObj;




    private Vector3 _moveInput;
    Vector3 _playerDirection;

    private Vector3 _moveVelocity;

    Animator _anim;

    private Transform cloestTarget;
    [SerializeField] FloatVariable PlayerLookTowardsSpeed;



    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        //Move Input
        _playerDirection = Vector3.forward * _moveJoystick.Vertical + Vector3.right * _moveJoystick.Horizontal;
        _moveInput = _playerDirection.normalized;
        _moveVelocity = _moveInput * _moveSpeed.Value;
        //Player Rotation
        if (_playerDirection.sqrMagnitude > 0.0f)
            transform.rotation = Quaternion.LookRotation(_playerDirection * Time.deltaTime, Vector3.up);


        if (cloestTarget == null || cloestTarget.gameObject.activeSelf == false)
        {
            cloestTarget = GetClosestEnemy(ListOfEnemies.List);
            if (cloestTarget != null)
            {
                SetIconAboveClosestTarget();
            }
        }

        if (_playerDirection != Vector3.zero)
        {
            _anim.SetBool("IsRunning", true);
            _shooting.Value = false;
            cloestTarget = GetClosestEnemy(ListOfEnemies.List);

            if (cloestTarget != null)
            {
                SetIconAboveClosestTarget();
            }
        }
        else
        {
            _anim.SetBool("IsRunning", false);
            _shooting.Value = true;
            LookTowards();
        }


        if (ListOfEnemies.List.Count == 0)
        {
            _shooting.Value = false;
        }
    }

    void LookTowards()
    {
        if (cloestTarget != null)
        {
            Vector3 lookPos = cloestTarget.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * PlayerLookTowardsSpeed.Value);
        }
    }

    private void FixedUpdate()
    {
        //movePlayer
        controller.Move(_moveVelocity * Time.deltaTime);
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

    public void SetIconAboveClosestTarget()
    {
        Vector3 targetPos = cloestTarget.position;
        targetPos.y = 3;
        CloestTargetObj.transform.position = targetPos;
        CloestTargetObj.transform.SetParent(cloestTarget);
    }
}

