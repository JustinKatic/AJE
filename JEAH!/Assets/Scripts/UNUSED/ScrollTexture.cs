using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    public float ScrollSpeed;
    Renderer rend;
    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float OffsetX = Time.time * ScrollSpeed;
        rend.material.mainTextureOffset = new Vector2(OffsetX, 0);
    }
}
