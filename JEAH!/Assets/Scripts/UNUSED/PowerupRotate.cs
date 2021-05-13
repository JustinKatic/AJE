using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupRotate : MonoBehaviour
{
    public float speed = 10f;

    PowerupSlotManager powerupSlotManager;
    private void Awake()
    {
        powerupSlotManager = gameObject.GetComponentInParent<PowerupSlotManager>();
    }
    void Update()
    {
        if (powerupSlotManager.powerupAdded)
            transform.Rotate(Vector3.up * Time.deltaTime * speed, Space.World);
    }
}
