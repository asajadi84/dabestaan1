using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowColliderManager : MonoBehaviour
{

	[SerializeField] private bool isTheTopRow;
	
	private void OnMouseUp()
	{
		if (isTheTopRow)
		{

			if (GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise2>().theTopIsCorrect)
			{
				GameObject.Find("Game Manager").SendMessage("PlayerWin");
			}
			else
			{
				GameObject.Find("Game Manager").SendMessage("PlayerLose");
			}
			
		}
		else
		{
			
			if (!GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise2>().theTopIsCorrect)
			{
				GameObject.Find("Game Manager").SendMessage("PlayerWin");
			}
			else
			{
				GameObject.Find("Game Manager").SendMessage("PlayerLose");
			}
			
		}
	}
}
