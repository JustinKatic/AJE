using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public void BuyTower(GameObject TowerSelect)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.collider.tag == "Ground")
            {
                SetAreaUnbuildable buildable = hit.collider.GetComponent<SetAreaUnbuildable>();
                if (buildable._hasAreaBeenBuiltOn)
                    return;
                else
                {
                    Instantiate(TowerSelect,
                        new Vector3(hit.collider.gameObject.transform.position.x,
                        hit.collider.gameObject.transform.transform.position.y + 0.65f,
                        hit.collider.gameObject.transform.position.z),
                        hit.collider.gameObject.transform.rotation);
                    buildable._hasAreaBeenBuiltOn = true;
                }
            }
        }
    }
}
