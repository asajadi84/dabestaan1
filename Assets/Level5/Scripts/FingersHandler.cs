using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FingersHandler : MonoBehaviour
{

	[SerializeField] private int thisID;

	private void OnMouseUp()
	{
		if (thisID == GameObject.Find("Game Manager").GetComponent<GameManagerLevel5Exercise1>().randomIndex)
		{
			SceneManager.LoadScene("Level5Exercise1Pt2");
		}
		else
		{
			if (GameObject.Find("Game Manager").GetComponent<GameManagerLevel5Exercise1>().secondChance!=true)
			{
				AudioSource.PlayClipAtPoint(
					GameObject.Find("Game Manager").GetComponent<GameManagerLevel5Exercise1>().tryOneMoreTime,
					Camera.main.transform.position
					);
				GameObject.Find("Game Manager").GetComponent<GameManagerLevel5Exercise1>().secondChance = true;
			}
			else
			{
				foreach (GameObject GO in GameObject.Find("Game Manager").GetComponent<GameManagerLevel5Exercise1>().fingers)
				{
					Destroy(GO);
				}
				
				Instantiate(
					GameObject.Find("Game Manager").GetComponent<GameManagerLevel5Exercise1>().winPrefab,
					Vector3.zero, Quaternion.identity
				);
				GameObject.Find("layer 9").GetComponent<SpriteRenderer>().sprite = GameObject.Find("Game Manager").GetComponent<GameManagerLevel5Exercise1>().loseSprie;

				GameObject.Find("layer 8").GetComponent<SpriteRenderer>().color = Color.black;
				GameObject.Find("layer 7").GetComponent<SpriteRenderer>().color = Color.red;
			
				AudioSource.PlayClipAtPoint(
					GameObject.Find("Game Manager").GetComponent<GameManagerLevel5Exercise1>().loseClip,
					Camera.main.transform.position
				);
				AudioSource.PlayClipAtPoint(
					GameObject.Find("Game Manager").GetComponent<GameManagerLevel5Exercise1>().loseMusic,
					Camera.main.transform.position,
					0.3f
				);
			}
		}
	}
}
