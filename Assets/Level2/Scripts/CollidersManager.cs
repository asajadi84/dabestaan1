using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersManager : MonoBehaviour
{

	[SerializeField] private int rowId;
	[SerializeField] private int columnId;
	private GameObject myTempGO;

	private void OnMouseUp()
	{
				//the house is not colored
				if (columnId > GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().rowColored[rowId-1])
				{
					if (GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().rowColored[rowId-1] + 1 == columnId)
					{
						GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().rowColored[rowId-1]++;

						myTempGO = Instantiate(
							GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().hatchPrefab,
							GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().hatchPositions[(((rowId-1)*5)+columnId)-1],
							Quaternion.identity
							);
						myTempGO.GetComponent<SpriteRenderer>().color = GameObject.Find("Game Manager")
							.GetComponent<Level2GameManagerExercise>().rowColors[rowId-1];
					}
					else
					{
						AudioSource.PlayClipAtPoint(GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().errorClip, Camera.main.transform.position);
					}
				}
				else
				{
					if (columnId == GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().rowColored[rowId-1])
					{
						GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().rowColored[rowId-1]--;
						Destroy(myTempGO);
					}
					else
					{
						AudioSource.PlayClipAtPoint(GameObject.Find("Game Manager").GetComponent<Level2GameManagerExercise>().errorClip, Camera.main.transform.position);
					}
				}
	}
}
