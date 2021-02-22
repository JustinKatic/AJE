
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShakeTest : MonoBehaviour
{
	private CameraShake shake;

	private void Start()
	{
		shake = GameObject.FindObjectOfType<CameraShake>().GetComponent<CameraShake>();
	}


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			shake.CamShake();
		}
	}
}
