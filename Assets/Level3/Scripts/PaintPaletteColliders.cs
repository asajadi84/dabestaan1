using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintPaletteColliders : MonoBehaviour
{

	[SerializeField] private int paintId;
	
	private void OnMouseUp()
	{
		GameObject.Find("brush tip").GetComponent<SpriteRenderer>().color =
			GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().seqColors[paintId];
		
		GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().activeColor =
			GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise1>().seqColors[paintId];
	}
}
