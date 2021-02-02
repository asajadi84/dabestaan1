using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardBottonHandler : MonoBehaviour
{

	private bool isRight;

	private void OnMouseUp()
	{
		if (GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().canTouch)
		{
			isRight =
			GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().rowColored[0] == GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().correctAnswers[0]
			&&
			GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().rowColored[1] == GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().correctAnswers[1]
			&&
			GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().rowColored[2] == GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().correctAnswers[2]
			&&
			GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().rowColored[3] == GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().correctAnswers[3]
			&&
			GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().rowColored[4] == GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().correctAnswers[4];

		GameObject checkForNarration = GameObject.Find("One shot audio");
		if (checkForNarration != null)
		{
			Destroy(checkForNarration);
		}
		
		
		GameObject[] temp = GameObject.FindGameObjectsWithTag("removeAfterWin");
		foreach (GameObject tempG in temp)
		{
			Destroy(tempG);
		}
		
		gameObject.SetActive(false);
		
		if (isRight)
		{
			Instantiate(
				GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().youWonGO,
				Vector3.zero, Quaternion.identity
			);
			
			AudioSource.PlayClipAtPoint(
				GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().winClip,
				Camera.main.transform.position
			);
			AudioSource.PlayClipAtPoint(
				GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().winMusic,
				Camera.main.transform.position,
				0.3f
			);
		}
		else
		{
			Instantiate(
				GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().youWonGO,
				Vector3.zero, Quaternion.identity
			);
			GameObject.Find("layer 9").GetComponent<SpriteRenderer>().sprite =
				GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().loseSprite;

			GameObject.Find("layer 8").GetComponent<SpriteRenderer>().color = Color.black;
			GameObject.Find("layer 7").GetComponent<SpriteRenderer>().color = Color.red;
			

			AudioSource.PlayClipAtPoint(
				GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().loseMusic,
				Camera.main.transform.position,
				0.3f
			);
			
			//Finding the wrong row logic

			int numberOfIncorrections = 0;
			int incorrectionRow = 0;

			for (int i = 0; i < 5; i++)
			{
				if (GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().rowColored[i] != GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().correctAnswers[i])
				{
					numberOfIncorrections++;
					incorrectionRow = i;
				}
			}

			if (numberOfIncorrections > 1)
			{
				AudioSource.PlayClipAtPoint(
					GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().rowIncorrections[5],
					Camera.main.transform.position
				);
			}
			else
			{
				AudioSource.PlayClipAtPoint(
					GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().rowIncorrections[incorrectionRow],
					Camera.main.transform.position
				);
			}
			

			
			
			
			
			Debug.Log("LOSt");
		}
		}
		
	}
}
