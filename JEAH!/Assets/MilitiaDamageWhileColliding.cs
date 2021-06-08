using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitiaDamageWhileColliding : DamagePlayerWhileColliding
{
    public Animator anim;
    public override void AttackAnimation()
    {
        anim.SetBool("isWalking", false);
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        anim.SetBool("isWalking", true);
    }
}
