using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    FloatingJoystick _moveJoystick;

    [SerializeField] FloatVariable _moveSpeed;

    [SerializeField] FloatVariable PlayerInGameCurrency;


    [SerializeField] CharacterController controller;

    float closestDist = Mathf.Infinity;
    GameObject closestTowerObj = null;


    private Vector3 _moveInput;
    Vector3 _playerDirection;

    private Vector3 _moveVelocity;

    Animator _anim;

    public LayerMask towerLayer;
    public Transform powerUpBeamPos;
    public LineRenderer LR;
    public GameObject playerBeamFX;
    public float beamRange = 5f;
    public float lookTowardsSpeed = 5f;

    private IEnumerator fadeCO;

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
            if (SFXAudioManager.instance.IsPlaying("PlayerBeam"))
            {
                //start and set variable fade corutine 
                if (fadeCO == null)
                {
                    fadeCO = SFXAudioManager.instance.FadeOut("PlayerBeam", .5f);
                    SFXAudioManager.instance.StartCoroutine(fadeCO);
                }

            }
            _anim.SetBool("IsRunning", true);
            if (!SFXAudioManager.instance.IsPlaying("PlayerMove"))
                SFXAudioManager.instance.Play("PlayerMove");
            if (closestTowerObj != null)
            {
                closestTowerObj.gameObject.GetComponent<TowersDefault>().powerdUp = false;
                closestTowerObj = null;
                LR.enabled = false;
                playerBeamFX.SetActive(false);
            }
        }
        else
        {
            _anim.SetBool("IsRunning", false);

            if (Time.timeScale == 0)
                SFXAudioManager.instance.Stop("PlayerBeam");


            if (closestTowerObj != null)
            {
                LookTowards(closestTowerObj.transform);
            }

            if (SFXAudioManager.instance.IsPlaying("PlayerMove"))
                SFXAudioManager.instance.Stop("PlayerMove");


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
                            playerBeamFX.SetActive(false);
                        }
                        closestTowerObj = hitColliders[i].transform.gameObject;
                    }
                }
                if (!SFXAudioManager.instance.IsPlaying("PlayerBeam"))
                {
                    if (fadeCO != null)
                    {
                        SFXAudioManager.instance.StopCoroutine(fadeCO);
                        fadeCO = null;
                    }
                    if (Time.timeScale > 0)
                        SFXAudioManager.instance.Play("PlayerBeam");

                }
                closestTowerObj.gameObject.GetComponent<TowersDefault>().powerdUp = true;
                LR.enabled = true;
                LR.SetPosition(0, powerUpBeamPos.position);
                LR.SetPosition(1, new Vector3(closestTowerObj.transform.position.x, 0.5f, closestTowerObj.transform.position.z));
                playerBeamFX.SetActive(true);
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

