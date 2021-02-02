using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardButtonL3Ex2 : MonoBehaviour
{

	[SerializeField] private AudioClip errorClip;
	
	private void OnMouseUp()
	{
		if (GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise2>().canColorSequence)
		{
			bool checkTheResult = true;
			for (int i = 0; i < 8; i++)
			{
				if (
					GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise2>().currentSeqColor[i] !=
					GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise2>().correctSequenceColors[i])
				{
					checkTheResult = false;
				}
			}

			if (checkTheResult)
			{
				GameObject.Find("Game Manager").SendMessage("PlayerFinalWin");
			}
			else
			{
				GameObject.Find("Game Manager").SendMessage("PlayerLose");
			}
		}
		else
		{
			AudioSource.PlayClipAtPoint(errorClip, Camera.main.transform.position);
		}
	}
}
