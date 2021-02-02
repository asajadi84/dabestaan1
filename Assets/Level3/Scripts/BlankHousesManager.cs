using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankHousesManager : MonoBehaviour
{

	[SerializeField] private int houseID;

	private void OnMouseUp()
	{
		//Debug.Log("house id: " + houseID);

		if (GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise2>().currentSeqColorHatchGOs[houseID-1]==null)
		{
			GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise2>()
					.currentSeqColorHatchGOs[houseID - 1] =
				Instantiate(
					GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise2>().hatchPrefab,
					GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise2>().hatchPositions[houseID-1],
					Quaternion.identity
					);
		}
		else
		{
			GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise2>().currentSeqColorHatchGOs[houseID-1].SetActive(false);
			GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise2>().currentSeqColorHatchGOs[houseID-1].SetActive(true);
		}
		
		GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise2>()
				.currentSeqColorHatchGOs[houseID - 1].GetComponent<SpriteRenderer>().color =
			GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise2>().ActiveColor;
		
		GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise2>().currentSeqColor[houseID-1] = 
			GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise2>().ActiveColor;
	}
}
