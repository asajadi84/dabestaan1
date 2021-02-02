using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentStateHandlerButtons : MonoBehaviour
{

	[SerializeField] private AudioClip errorClip;
	[SerializeField] private int buttonValue;

	private void OnMouseUp()
	{
		if (GameObject.Find("Game Manager").GetComponent<GameManagerLevel4>().currentState + buttonValue > 5 ||
		    GameObject.Find("Game Manager").GetComponent<GameManagerLevel4>().currentState + buttonValue < 0)
		{
			AudioSource.PlayClipAtPoint(errorClip, Camera.main.transform.position);
		}
		else
		{
			GameObject.Find("Game Manager").GetComponent<GameManagerLevel4>().currentState += buttonValue;

			GameObject.Find("Game Manager").GetComponent<GameManagerLevel4>().MakeVisibleByState(
				GameObject.Find("Game Manager").GetComponent<GameManagerLevel4>().currentState);
		}
	}
}
