using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExerciseSelectionHandler : MonoBehaviour
{

	[SerializeField] private int thisColliderId;

	private void OnMouseUp()
	{
		if (GameManagerExercise.canClick)
		{
			GameManagerExercise.canClick = false;
			if (thisColliderId == GameManagerExercise.randomIndex)
			{
				Debug.Log("you win");
				GameManagerExercise.secondChance = false;
				BoxCollider2D[] tempColliders = gameObject.GetComponentInParent<Transform>()
					.GetComponentsInChildren<BoxCollider2D>();

				foreach (BoxCollider2D collider in tempColliders)
				{
					Destroy(collider);
				}
				
				Instantiate(
					GameObject.Find("GameManager").GetComponent<GameManagerExercise>().YouWonGameObject,
					Vector3.zero, Quaternion.identity
				);
			
				AudioSource.PlayClipAtPoint(
					GameObject.Find("GameManager").GetComponent<GameManagerExercise>().winClip,
					Camera.main.transform.position
				);
				AudioSource.PlayClipAtPoint(
					GameObject.Find("GameManager").GetComponent<GameManagerExercise>().winMusic,
					Camera.main.transform.position,
					0.3f
				);
			}
			else
			{
				if (GameManagerExercise.secondChance == false)
				{
					AudioSource.PlayClipAtPoint(
						GameObject.Find("GameManager").GetComponent<GameManagerExercise>().loseClip,
						Camera.main.transform.position
					);
					GameManagerExercise.canClick = true;
					GameManagerExercise.secondChance = true;
				}
				else
				{


					GameManagerExercise.secondChance = false;
					
					BoxCollider2D[] tempColliders = gameObject.GetComponentInParent<Transform>()
						.GetComponentsInChildren<BoxCollider2D>();

					foreach (BoxCollider2D collider in tempColliders)
					{
						Destroy(collider);
					}
				
					Instantiate(
						GameObject.Find("GameManager").GetComponent<GameManagerExercise>().YouWonGameObject,
						Vector3.zero, Quaternion.identity
					);
					GameObject.Find("layer 9").GetComponent<SpriteRenderer>().sprite =
						GameObject.Find("GameManager").GetComponent<GameManagerExercise>().loseSprite;

					GameObject.Find("layer 8").GetComponent<SpriteRenderer>().color = Color.black;
					GameObject.Find("layer 7").GetComponent<SpriteRenderer>().color = Color.red;
			
					AudioSource.PlayClipAtPoint(
						GameObject.Find("GameManager").GetComponent<GameManagerExercise>().loseForSureClip,
						Camera.main.transform.position
					);
					AudioSource.PlayClipAtPoint(
						GameObject.Find("GameManager").GetComponent<GameManagerExercise>().loseMusic,
						Camera.main.transform.position,
						0.3f
					);
					
					
					
					
					
					
					Debug.Log("you lose");
				}
				

			}
		}
		
		
	}
}
