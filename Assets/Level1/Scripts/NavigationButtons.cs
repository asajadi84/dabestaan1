using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationButtons : MonoBehaviour
{

	[SerializeField] private AudioClip click;
	[SerializeField] private AudioClip error;

	public int value;
	private void OnMouseUp()
	{
		if (0 <= GameManager.currentState + value && GameManager.currentState+value < 5)
		{
			GameManager.currentState += value;
			AudioSource.PlayClipAtPoint(click, Camera.main.transform.position);
			GameObject.Find("Game Manager").GetComponent<GameManager>().MessageFromNavigationButtons(GameManager.currentState);
		}
		else
		{
			AudioSource.PlayClipAtPoint(error, Camera.main.transform.position);
		}
	}
}
