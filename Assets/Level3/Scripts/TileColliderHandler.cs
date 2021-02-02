using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColliderHandler : MonoBehaviour
{
	private int n = 0;
	[SerializeField] private int tileId;
	private bool canTouch = false;



	IEnumerator touchDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		canTouch = true;
	}

	private void Start()
	{
		StartCoroutine(touchDelay(1.2f));
	}

	private void OnMouseUp()
	{
		if (tileId == 10)
		{
			
			AudioSource.PlayClipAtPoint(
				GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().errorClip,
				Camera.main.transform.position
				);

			return;
		}
	
		this.n = 0;

		if (GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().activeColor == GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().seqColors[0]
		    ||
		    GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().activeColor == GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().seqColors[1]
		    ||
		    GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().activeColor == GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().seqColors[2]
		    ||
		    GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().activeColor == GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().seqColors[3]
		    ||
		    GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().activeColor == GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().seqColors[4]
		    )
		{
			GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().seqColorsState[tileId] =
				GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().activeColor;
		
			GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().tileColrs[tileId].GetComponent<SpriteRenderer>().color=
				GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().activeColor;
		}
		else
		{
			if(canTouch)
			{
				GameObject tempAudio = GameObject.Find("One shot audio");
				{
					if (tempAudio != null)
					{
						Destroy(tempAudio);
					}
				}
			
				AudioSource.PlayClipAtPoint(GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().pickAColor, Camera.main.transform.position);
			}

		}

		
		for (int i = 0; i < 8; i++)
		{
			if (GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().seqColorsState[i]
			== GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().currectAnswer[i])
			{
				n++;
			}
		}

		if (n == 8)
		{
			if (canTouch)
			{
				GameObject tempAudio = GameObject.Find("One shot audio");
				{
					if (tempAudio != null)
					{
						Destroy(tempAudio);
					}
				}
			
				GameObject[] temp = GameObject.FindGameObjectsWithTag("removeAfterWin");
				foreach (GameObject t in temp)
				{
					Destroy(t);
				}
				AudioSource.PlayClipAtPoint(GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().winClip, Camera.main.transform.position);
				AudioSource.PlayClipAtPoint(GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().winMusic, Camera.main.transform.position);

				Instantiate(GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().youWin, Vector3.zero, Quaternion.identity);
				
				if (GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().notThisScene)
				{
					GameObject.Find("layer 9").GetComponent<ExerciseRestart>().notThisScene = true;
					GameObject.Find("layer 9").GetComponent<ExerciseRestart>().sceneName = "Level5Exercise1";
				}
			}
		}
	}
}
