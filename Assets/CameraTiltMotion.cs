using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTiltMotion : MonoBehaviour
{

	private Vector3 acceleratorEffect;
	
	// Use this for initialization
	void Awake ()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		acceleratorEffect.z = -10;
		GetComponent<Camera>().orthographicSize = 4.8f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		acceleratorEffect.x = Mathf.Clamp(
			Input.acceleration.x * 0.4f - 0.2f,
			-0.2f,0.2f
			);
		acceleratorEffect.y = Input.acceleration.y / 5.0f;
		transform.position = acceleratorEffect;
	}
}
