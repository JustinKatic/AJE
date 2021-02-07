using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    public float ScrollSpeed;

    // Update is called once per frame
    void Update()
    {
        float OffsetX = Time.time * ScrollSpeed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX, 0);
    }
}
