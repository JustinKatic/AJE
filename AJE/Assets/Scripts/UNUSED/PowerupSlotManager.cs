using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSlotManager : MonoBehaviour
{
    [System.Serializable]
    struct Slots
    {
        public Transform slot;
        public bool slotted;
    }

    [SerializeField] Slots[] slots;

    [HideInInspector] int powerupCount;
    [HideInInspector] public bool slotsFull;

   [HideInInspector] public bool powerupAdded;


    public void AddPowerupToSlot(Transform powerup)
    {
        powerupAdded = true;
        if (!slotsFull)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].slotted == false)
                {
                    powerup.SetParent(slots[i].slot);
                    powerup.position = slots[i].slot.position;
                    slots[i].slotted = true;
                    powerupCount++;
                    break;
                }
            }
            if (powerupCount >= slots.Length)
                slotsFull = true;
        }
    }


}
