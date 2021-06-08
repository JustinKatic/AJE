using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianDamageWhileColliding : DamagePlayerWhileColliding
{
    public override void AttackAnimation()
    {
        anim.Play("Barbarian_Attack");
    }
}
