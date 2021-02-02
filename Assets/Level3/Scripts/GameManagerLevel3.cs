using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerLevel3 : MonoBehaviour
{

	private bool canTouch = false;
	private bool hasSaid = false;
	private int currentState = 0;

	[SerializeField] private GameObject hatchPrefab;
	[SerializeField] private AudioClip scribbleClip;
	
	[SerializeField] private AudioClip[] narrations;
	[SerializeField] private AudioClip touchToContinue;
	[SerializeField] private AudioClip goToExercise;

	[SerializeField] private Sprite yellowBanana;
	[SerializeField] private Sprite redApple;
	[SerializeField] private Sprite greenWatermelon;
	[SerializeField] private Sprite purpleBerry;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine(delayStart(1f));
	}

	IEnumerator delayStart(float delay)
	{
		yield return new WaitForSeconds(delay);
		StartCoroutine(drawSequence(
			greenWatermelon, yellowBanana, greenWatermelon, yellowBanana,
			greenWatermelon,yellowBanana,greenWatermelon,yellowBanana,
			
			Color.green, Color.yellow, Color.green, Color.yellow,
			Color.green, Color.yellow, Color.green, Color.yellow
		));
	}

	IEnumerator drawSequence(
		Sprite sprite1, Sprite sprite2, Sprite sprite3, Sprite sprite4, Sprite sprite5, Sprite sprite6, Sprite sprite7, Sprite sprite8,
		Color color1, Color color2, Color color3, Color color4, Color color5, Color color6, Color color7, Color color8)
	{
		canTouch = false;

		GameObject[] hatchTemp = GameObject.FindGameObjectsWithTag("hatch");
		foreach (GameObject temp in hatchTemp)
		{
			Destroy(temp);
		}
		
		GameObject.Find("fruit1").GetComponent<SpriteRenderer>().sprite = sprite1;
		GameObject.Find("fruit2").GetComponent<SpriteRenderer>().sprite = sprite2;
		GameObject.Find("fruit3").GetComponent<SpriteRenderer>().sprite = sprite3;
		GameObject.Find("fruit4").GetComponent<SpriteRenderer>().sprite = sprite4;
		GameObject.Find("fruit5").GetComponent<SpriteRenderer>().sprite = sprite5;
		GameObject.Find("fruit6").GetComponent<SpriteRenderer>().sprite = sprite6;
		GameObject.Find("fruit7").GetComponent<SpriteRenderer>().sprite = sprite7;
		GameObject.Find("fruit8").GetComponent<SpriteRenderer>().sprite = sprite8;
		
		AudioSource.PlayClipAtPoint(narrations[currentState], Camera.main.transform.position);
		yield return new WaitForSeconds(narrations[currentState].length);
		
		//Hatching1
		AudioSource.PlayClipAtPoint(scribbleClip, Camera.main.transform.position, 0.3f);
		GameObject hatch1 = Instantiate(hatchPrefab,
			new Vector3(-4.45f, -0.12f, 0f),
			Quaternion.identity);
		hatch1.GetComponent<SpriteRenderer>().color = color1;
		yield return new WaitForSeconds(1.2f);
		
		//Hatching2
		AudioSource.PlayClipAtPoint(scribbleClip, Camera.main.transform.position, 0.3f);
		GameObject hatch2 = Instantiate(hatchPrefab,
			new Vector3(-3.18f, -0.12f, 0f),
			Quaternion.identity);
		hatch2.GetComponent<SpriteRenderer>().color = color2;
		yield return new WaitForSeconds(1.2f);
		
		//Hatching3
		AudioSource.PlayClipAtPoint(scribbleClip, Camera.main.transform.position, 0.3f);
		GameObject hatch3 = Instantiate(hatchPrefab,
			new Vector3(-1.9f, -0.12f, 0f),
			Quaternion.identity);
		hatch3.GetComponent<SpriteRenderer>().color = color3;
		yield return new WaitForSeconds(1.2f);
		
		//Hatching4
		AudioSource.PlayClipAtPoint(scribbleClip, Camera.main.transform.position, 0.3f);
		GameObject hatch4 = Instantiate(hatchPrefab,
			new Vector3(-0.63f, -0.12f, 0f),
			Quaternion.identity);
		hatch4.GetComponent<SpriteRenderer>().color = color4;
		yield return new WaitForSeconds(1.2f);
		
		//Hatching5
		AudioSource.PlayClipAtPoint(scribbleClip, Camera.main.transform.position, 0.3f);
		GameObject hatch5 = Instantiate(hatchPrefab,
			new Vector3(0.63f, -0.12f, 0f),
			Quaternion.identity);
		hatch5.GetComponent<SpriteRenderer>().color = color5;
		yield return new WaitForSeconds(1.2f);
		
		//Hatching6
		AudioSource.PlayClipAtPoint(scribbleClip, Camera.main.transform.position, 0.3f);
		GameObject hatch6 = Instantiate(hatchPrefab,
			new Vector3(1.9f, -0.12f, 0f),
			Quaternion.identity);
		hatch6.GetComponent<SpriteRenderer>().color = color6;
		yield return new WaitForSeconds(1.2f);
		
		//Hatching7
		AudioSource.PlayClipAtPoint(scribbleClip, Camera.main.transform.position, 0.3f);
		GameObject hatch7 = Instantiate(hatchPrefab,
			new Vector3(3.17f, -0.12f, 0f),
			Quaternion.identity);
		hatch7.GetComponent<SpriteRenderer>().color = color7;
		yield return new WaitForSeconds(1.2f);
		
		//Hatching8
		AudioSource.PlayClipAtPoint(scribbleClip, Camera.main.transform.position, 0.3f);
		GameObject hatch8 = Instantiate(hatchPrefab,
			new Vector3(4.44f, -0.12f, 0f),
			Quaternion.identity);
		hatch8.GetComponent<SpriteRenderer>().color = color8;
		yield return new WaitForSeconds(2.4f);

		currentState++;
		AudioSource.PlayClipAtPoint(touchToContinue, Camera.main.transform.position);
		yield return new WaitForSeconds(touchToContinue.length - 0.5f);
		canTouch = true;
	}

	private void OnMouseUp()
	{
		if (canTouch)
		{
			switch (currentState)
			{
				case 1:
					StartCoroutine(drawSequence(
						greenWatermelon, greenWatermelon, redApple, redApple,
						greenWatermelon,greenWatermelon,redApple,redApple,
			
						Color.green, Color.green, Color.red, Color.red,
						Color.green, Color.green, Color.red, Color.red
					));
					break;
				
				case 2:
					StartCoroutine(drawSequence(
						redApple, purpleBerry, purpleBerry, redApple,
						purpleBerry,purpleBerry,redApple,purpleBerry,
			
						Color.red, Color.magenta, Color.magenta, Color.red,
						Color.magenta, Color.magenta, Color.red, Color.magenta
					));
					break;
				
				/*case 3:
					StartCoroutine(drawSequence(
						yellowBanana, purpleBerry, purpleBerry, purpleBerry,
						yellowBanana,purpleBerry,purpleBerry,purpleBerry,
			
						Color.yellow, Color.magenta, Color.magenta, Color.magenta,
						Color.yellow, Color.magenta, Color.magenta, Color.magenta
					));
					break;
				*/
				//case 4:
					case 3:
					if (!hasSaid)
					{
						hasSaid = true;
						AudioSource.PlayClipAtPoint(goToExercise, Camera.main.transform.position);
					}
					break;
			}
		}
	}
}
