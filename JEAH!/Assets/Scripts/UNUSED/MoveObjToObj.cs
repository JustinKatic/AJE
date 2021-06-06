using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjToObj : MonoBehaviour
{
    float speed = 45f;
    private bool shouldObjMove;
    GameObject uiObject;
    [SerializeField] GameEvent updateCurrency;

    private void OnEnable()
    {
        uiObject = GameObject.FindGameObjectWithTag("UICurrency");
        shouldObjMove = false;
        StartCoroutine(MoveAfterX());
    }

    private void Update()
    {
        if (shouldObjMove)
        {
            Vector3 screenPoint = uiObject.transform.position + new Vector3(0, 0, 5);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPoint);
            transform.position = Vector3.MoveTowards(transform.position, worldPos, speed * Time.deltaTime);

            float dist = Vector3.Distance(transform.position, worldPos);
            if (dist <= 1f)
            {
                updateCurrency.Raise();
                gameObject.SetActive(false);
                SFXAudioManager.instance.Play("GainSouls");
            }
        }
    }

    IEnumerator MoveAfterX()
    {
        yield return new WaitForSeconds(1.5f);
        shouldObjMove = true;
    }
}