using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogShake : MonoBehaviour
{
    public Animator anim;

    public void ShakeFog()
    {
        StartCoroutine(PlayTwice());
    }
    IEnumerator PlayTwice()
    {
        anim.Play("Shake");
        yield return new WaitForSeconds(0.4f);
        anim.Play("Shake");
        yield return new WaitForSeconds(0.4f);
        anim.Play("Shake");
    }
}
