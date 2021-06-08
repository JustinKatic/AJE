using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianDamageWhileColliding : DamagePlayerWhileColliding
{
    public Animator anim;
    public override void AttackAnimation()
    {
        anim.SetBool("isWalking", false);
        SFXAudioManager.instance.Play("SFX_Default_Attack");
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        anim.SetBool("isWalking", true);
    }

}
