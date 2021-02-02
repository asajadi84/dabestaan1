using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPaletteCollider : MonoBehaviour
{

	[SerializeField] private GameObject otherOne;

	private void OnMouseUp()
	{
		otherOne.transform.localScale = Vector3.one;
		transform.localScale = new Vector3(1.2f,1.2f,1f);

		GameObject.Find("Game Manager").GetComponent<GameManagerLevel3Exercise2>().ActiveColor =
			GetComponent<SpriteRenderer>().color;
	}
}
