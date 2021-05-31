using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    FloatingJoystick _moveJoystick;

    [SerializeField] FloatVariable _moveSpeed;

    [SerializeField] FloatVariable PlayerInGameCurrency;


    [SerializeField] CharacterController controller;

    //[SerializeField] AudioSource beamSFXSource;

    float closestDist = Mathf.Infinity;
    GameObject closestTowerObj = null;


    private Vector3 _moveInput;
    Vector3 _playerDirection;

    private Vector3 _moveVelocity;

    Animator _anim;

    public LayerMask towerLayer;
    float _timer;
    public float checkToPowerTowerEveryX;
    public Transform powerUpBeamPos;
    public LineRenderer LR;
    public float beamRange =5f;
    public float lookTowardsSpeed = 5f;
    public ScriptableSoundObj beamSFXSource;

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
            _anim.SetBool("IsRunning", true);
            _timer = checkToPowerTowerEveryX;
            if (closestTowerObj != null)
            {
                closestTowerObj.gameObject.GetComponent<TowersDefault>().powerdUp = false;
                closestTowerObj = null;
                LR.enabled = false;                
            }
        }
        else
        {
            _anim.SetBool("IsRunning", false);
            if (closestTowerObj != null)
            {
                LookTowards(closestTowerObj.transform);
            }
            _timer += Time.deltaTime;
            if (_timer >= checkToPowerTowerEveryX)
            {
                
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, beamRange, towerLayer);
                if (hitColliders.Length > 0)
                {
                    closestDist = Mathf.Infinity;
                    closestTowerObj = null;

                    for (int i = 0; i < hitColliders.Length; i++)
                    {
                        float dist = Vector3.Distance(transform.position, hitColliders[i].transform.position);
                        if (dist < closestDist)
                        {
                            closestDist = dist;
                            if (closestTowerObj != null && closestTowerObj != hitColliders[i].gameObject)
                            {
                                closestTowerObj.gameObject.GetComponent<TowersDefault>().powerdUp = false;
                                LR.enabled = false;
                            }
                            closestTowerObj = hitColliders[i].transform.gameObject;
                        }
                    }
                    //beamSFXSource.Play();
                    closestTowerObj.gameObject.GetComponent<TowersDefault>().powerdUp = true;
                    LR.enabled = true;
                    LR.SetPosition(0, powerUpBeamPos.position);
                    LR.SetPosition(1, new Vector3(closestTowerObj.transform.position.x, 0.5f, closestTowerObj.transform.position.z));
                }
                _timer = 0;
            }

        }
    }



    private void FixedUpdate()
    {
        //movePlayer
        controller.Move(_moveVelocity * Time.deltaTime);
    }

    //look towards target destination smoothly
    public void LookTowards(Transform lookAtTarget)
    {
        Vector3 lookPos = lookAtTarget.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * lookTowardsSpeed);
    }
}

