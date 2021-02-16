using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStats : MonoBehaviour
{

    [Header("Barbarian Stats")]
    [SerializeField] float BarbarianMaxHealth;
    [SerializeField] float BarbarianMoveSpeed;
    [SerializeField] float BarbarianCollisionDmg;
    [SerializeField] FloatVariable SOBarbarianMaxHealth;
    [SerializeField] FloatVariable SOBarbarianMoveSpeed;
    [SerializeField] FloatVariable SOBarbarianCollisionDmg;


    [Header("Cannoneer Stats")]
    [SerializeField] float CannoneerMaxHealth;
    [SerializeField] float CannoneerMoveSpeed;
    [SerializeField] float CannoneerCollisionDmg;
    [SerializeField] float CannoneerProjectileDmg;
    [SerializeField] FloatVariable SOCannoneerMaxHealth;
    [SerializeField] FloatVariable SOCannoneerMoveSpeed;
    [SerializeField] FloatVariable SOCannoneerCollisionDmg;
    [SerializeField] FloatVariable SOCannoneerProjectileDmg;

    [Header("Archer Stats")]
    [SerializeField] float ArcherMaxHealth;
    [SerializeField] float ArcherMoveSpeed;
    [SerializeField] float ArcherCollisionDmg;
    [SerializeField] float ArcherProjectileDmg;
    [SerializeField] FloatVariable SOArcherMaxHealth;
    [SerializeField] FloatVariable SOArcherMoveSpeed;
    [SerializeField] FloatVariable SOArcherCollisionDmg;
    [SerializeField] FloatVariable SOArcherProjectileDmg;

    [Header("Bird Stats")]
    [SerializeField] float BirdMaxHealth;
    [SerializeField] float BirdMoveSpeed;
    [SerializeField] float BirdCollisionDmg;
    [SerializeField] FloatVariable SOBirdMaxHealth;
    [SerializeField] FloatVariable SOBirdMoveSpeed;
    [SerializeField] FloatVariable SOBirdCollisionDmg;

    [Header("Knight Stats")]
    [SerializeField] float KnightMaxHealth;
    [SerializeField] float KnightMoveSpeed;
    [SerializeField] float KnightCollisionDmg;
    [SerializeField] FloatVariable SOKnightMaxHealth;
    [SerializeField] FloatVariable SOKnightMoveSpeed;
    [SerializeField] FloatVariable SOKnightCollisionDmg;

    private void Start()
    {
        //BARBARIAN
        SOBarbarianMaxHealth.RuntimeValue = BarbarianMaxHealth;
        SOBarbarianMoveSpeed.RuntimeValue = BarbarianMoveSpeed;
        SOBarbarianCollisionDmg.RuntimeValue = BarbarianCollisionDmg;

        //Cannoneer
        SOCannoneerMaxHealth.RuntimeValue = CannoneerMaxHealth;
        SOCannoneerMoveSpeed.RuntimeValue = CannoneerMoveSpeed;
        SOCannoneerCollisionDmg.RuntimeValue = CannoneerCollisionDmg;
        SOCannoneerProjectileDmg.RuntimeValue = CannoneerProjectileDmg;

        //Archer
        SOArcherMaxHealth.RuntimeValue = ArcherMaxHealth;
        SOArcherMoveSpeed.RuntimeValue = ArcherMoveSpeed;
        SOArcherCollisionDmg.RuntimeValue = ArcherCollisionDmg;
        SOArcherProjectileDmg.RuntimeValue = ArcherProjectileDmg;

        //Bird
        SOBirdMaxHealth.RuntimeValue = BirdMaxHealth;
        SOBirdMoveSpeed.RuntimeValue = BirdMoveSpeed;
        SOBirdCollisionDmg.RuntimeValue = BirdCollisionDmg;

        //Knight
        SOKnightMaxHealth.RuntimeValue = KnightMaxHealth;
        SOKnightMoveSpeed.RuntimeValue = KnightMoveSpeed;
        SOKnightCollisionDmg.RuntimeValue = KnightCollisionDmg;
    }

}
