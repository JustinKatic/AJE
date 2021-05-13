using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjUnActiveAfterX : MonoBehaviour
{
    [SerializeField] float ObjectLife = 2;

    private void OnEnable()
    {
        Invoke("SetUnActive", ObjectLife);
    }

    void SetUnActive()
    {
        gameObject.SetActive(false);
        CancelInvoke();
    }
}
