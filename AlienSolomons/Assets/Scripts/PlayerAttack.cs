using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool _isFiring;

    [SerializeField] float _timeBetweenShots;
    private float _shotCounter;
    private MellieMovement _moveScript;
    Animator _anim;
    bool _swipeType;

    private void Start()
    {
        _moveScript = gameObject.GetComponent<MellieMovement>();
        _anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        if (_moveScript._shooting)
        {
            _shotCounter -= Time.deltaTime;
            if (_shotCounter <= 0)
            {
                _shotCounter = _timeBetweenShots;

                    _anim.Play("SwingWep");
                    _swipeType = false;
                
            }
        }
    }
}
