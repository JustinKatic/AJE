using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStats : MonoBehaviour
{

    [Header("Barbarian Stats")]
    [SerializeField] float BarbarianMaxHealth;

    [SerializeField] float BarbarianCollisionDmg;
    [SerializeField] FloatVariable SOBarbarianMaxHealth;
    [SerializeField] FloatVariable SOBarbarianCollisionDmg;


    [Header("Cannoneer Stats")]
    [SerializeField] float CannoneerMaxHealth;
    [SerializeField] float CannoneerCollisionDmg;
    [SerializeField] float CannoneerProjectileDmg;
    [SerializeField] FloatVariable SOCannoneerMaxHealth;
    [SerializeField] FloatVariable SOCannoneerCollisionDmg;
    [SerializeField] FloatVariable SOCannoneerProjectileDmg;

    [Header("Archer Stats")]
    [SerializeField] float ArcherMaxHealth;
    [SerializeField] float ArcherCollisionDmg;
    [SerializeField] float ArcherProjectileDmg;
    [SerializeField] FloatVariable SOArcherMaxHealth;
    [SerializeField] FloatVariable SOArcherCollisionDmg;
    [SerializeField] FloatVariable SOArcherProjectileDmg;

    [Header("Bird Stats")]
    [SerializeField] float BirdMaxHealth;
    [SerializeField] float BirdCollisionDmg;
    [SerializeField] FloatVariable SOBirdMaxHealth;
    [SerializeField] FloatVariable SOBirdCollisionDmg;

    [Header("Knight Stats")]
    [SerializeField] float KnightMaxHealth;
    [SerializeField] float KnightCollisionDmg;
    [SerializeField] FloatVariable SOKnightMaxHealth;
    [SerializeField] FloatVariable SOKnightCollisionDmg;

    private void Start()
    {
        //BARBARIAN
        SOBarbarianMaxHealth.RuntimeValue = BarbarianMaxHealth;
        SOBarbarianCollisionDmg.RuntimeValue = BarbarianCollisionDmg;

        //Cannoneer
        SOCannoneerMaxHealth.RuntimeValue = CannoneerMaxHealth;
        SOCannoneerCollisionDmg.RuntimeValue = CannoneerCollisionDmg;
        SOCannoneerProjectileDmg.RuntimeValue = CannoneerProjectileDmg;

        //Archer
        SOArcherMaxHealth.RuntimeValue = ArcherMaxHealth;
        SOArcherCollisionDmg.RuntimeValue = ArcherCollisionDmg;
        SOArcherProjectileDmg.RuntimeValue = ArcherProjectileDmg;

        //Bird
        SOBirdMaxHealth.RuntimeValue = BirdMaxHealth;
        SOBirdCollisionDmg.RuntimeValue = BirdCollisionDmg;

        //Knight
        SOKnightMaxHealth.RuntimeValue = KnightMaxHealth;
        SOKnightCollisionDmg.RuntimeValue = KnightCollisionDmg;
    }

}
