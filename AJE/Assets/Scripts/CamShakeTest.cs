
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShakeTest : MonoBehaviour
{
	private FogShake shake;

	private void Start()
	{
		shake = GameObject.FindObjectOfType<FogShake>().GetComponent<FogShake>();
	}


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			shake.ShakeFog();
		}
	}
}
