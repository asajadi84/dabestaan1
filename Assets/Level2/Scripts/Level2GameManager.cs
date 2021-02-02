using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2GameManager : MonoBehaviour
{

	[SerializeField] private AudioClip[] rowsNarration;
	[SerializeField] private GameObject hatchPrefab;
	[SerializeField] private GameObject crossPrefab;

	[SerializeField] private AudioClip touchClip;
	[SerializeField] private AudioClip exerciseClip;
	[SerializeField] private AudioClip scribbleClip;

	[SerializeField] private GameObject[] hands;

	private bool canTouch = false;
	private int currentState = 0;
	
	// Use this for initialization
	void Start ()
	{
		StartCoroutine(startNarration(1.0f));
	}

	IEnumerator startNarration(float delay)
	{
		yield return new WaitForSeconds(delay);
		StartCoroutine(row1narration());
	}

	private void OnMouseUp()
	{
		if (canTouch)
		{
			switch (currentState)
			{
				case 2:
					StartCoroutine(row2narration());
					break;
				
				case 3:
					StartCoroutine(row3narration());
					break;
				
				case 4:
					StartCoroutine(row4narration());
					break;
				
				case 5:
					StartCoroutine(row5narration());
					break;
				
				default:
					canTouch = false;
					AudioSource.PlayClipAtPoint(exerciseClip, Camera.main.transform.position);
					break;
			}
		}
	}

	IEnumerator row1narration()
	{
		AudioSource.PlayClipAtPoint(
			rowsNarration[0],
			Camera.main.transform.position
			);

		GameObject[] tempRow1GOs = GameObject.FindGameObjectsWithTag("Circle");
		foreach (GameObject tempGO in tempRow1GOs)
		{
			tempGO.AddComponent<TiltAnimation>();
		}

		yield return new WaitForSeconds(rowsNarration[0].length);
		
		foreach (GameObject tempGO in tempRow1GOs)
		{
			Color tempColor = tempGO.GetComponent<SpriteRenderer>().color;
			tempColor.a = 256;
			tempGO.GetComponent<SpriteRenderer>().color = tempColor;

			Destroy(tempGO.GetComponent<TiltAnimation>());
		}

		hands[0].SetActive(true);
		AudioSource.PlayClipAtPoint(scribbleClip, Camera.main.transform.position);
		GameObject row1hatch1 = Instantiate(hatchPrefab,
			new Vector3(-5.9f, 3.6f, 0f),
			Quaternion.identity);
		row1hatch1.GetComponent<SpriteRenderer>().color = Color.red;
		yield return new WaitForSeconds(2.4f);
		
		Destroy(hands[0]);
		hands[1].SetActive(true);
		AudioSource.PlayClipAtPoint(scribbleClip, Camera.main.transform.position);
		GameObject row1hatch2 = Instantiate(hatchPrefab,
			new Vector3(-4.6f, 3.6f, 0f),
			Quaternion.identity);
		row1hatch2.GetComponent<SpriteRenderer>().color = Color.red;
		yield return new WaitForSeconds(2.4f);
		
		Destroy(hands[1]);
		hands[2].SetActive(true);
		AudioSource.PlayClipAtPoint(scribbleClip, Camera.main.transform.position);
		GameObject row1hatch3 = Instantiate(hatchPrefab,
			new Vector3(-3.4f, 3.6f, 0f),
			Quaternion.identity);
		row1hatch3.GetComponent<SpriteRenderer>().color = Color.red;
		yield return new WaitForSeconds(2.4f);
		
		Destroy(hands[2]);
		foreach (GameObject tempGO in tempRow1GOs)
		{
			Instantiate(
				crossPrefab,
				tempGO.transform.position,
				Quaternion.identity
			);
		}
		
		yield return new WaitForSeconds(1f);
		AudioSource.PlayClipAtPoint(touchClip, Camera.main.transform.position);
		yield return new WaitForSeconds(touchClip.length);
		currentState = 2;
		canTouch = true;

	}
	
	IEnumerator row2narration()
	{
		canTouch = false;
		AudioSource.PlayClipAtPoint(
			rowsNarration[1],
			Camera.main.transform.position
		);

		GameObject[] tempRow1GOs = GameObject.FindGameObjectsWithTag("Triangle");
		foreach (GameObject tempGO in tempRow1GOs)
		{
			tempGO.AddComponent<TiltAnimation>();
		}

		yield return new WaitForSeconds(rowsNarration[1].length);

		foreach (GameObject tempGO in tempRow1GOs)
		{
			Color tempColor = tempGO.GetComponent<SpriteRenderer>().color;
			tempColor.a = 256;
			tempGO.GetComponent<SpriteRenderer>().color = tempColor;

			Destroy(tempGO.GetComponent<TiltAnimation>());
		}
		
		hands[3].SetActive(true);
		AudioSource.PlayClipAtPoint(scribbleClip, Camera.main.transform.position);
		GameObject row2hatch1 = Instantiate(hatchPrefab,
			new Vector3(-5.9f, 2.4f, 0f),
			Quaternion.identity);
		row2hatch1.GetComponent<SpriteRenderer>().color = Color.yellow;
		yield return new WaitForSeconds(2.4f);
		
		Destroy(hands[3]);
		hands[4].SetActive(true);
		AudioSource.PlayClipAtPoint(scribbleClip, Camera.main.transform.position);
		GameObject row2hatch2 = Instantiate(hatchPrefab,
			new Vector3(-4.6f, 2.4f, 0f),
			Quaternion.identity);
		row2hatch2.GetComponent<SpriteRenderer>().color = Color.yellow;
		yield return new WaitForSeconds(2.4f);
		
		Destroy(hands[4]);
		hands[5].SetActive(true);
		AudioSource.PlayClipAtPoint(scribbleClip, Camera.main.transform.position);
		GameObject row2hatch3 = Instantiate(hatchPrefab,
			new Vector3(-3.4f, 2.4f, 0f),
			Quaternion.identity);
		row2hatch3.GetComponent<SpriteRenderer>().color = Color.yellow;
		yield return new WaitForSeconds(2.4f);
		
		Destroy(hands[5]);
		hands[6].SetActive(true);
		AudioSource.PlayClipAtPoint(scribbleClip, Camera.main.transform.position);
		GameObject row2hatch4 = Instantiate(hatchPrefab,
			new Vector3(-2.1f, 2.4f, 0f),
			Quaternion.identity);
		row2hatch4.GetComponent<SpriteRenderer>().color = Color.yellow;
		yield return new WaitForSeconds(2.4f);
		
		Destroy(hands[6]);
		foreach (GameObject tempGO in tempRow1GOs)
		{
			Instantiate(
				crossPrefab,
				tempGO.transform.position,
				Quaternion.identity
			);
		}
		
		yield return new WaitForSeconds(1f);
		AudioSource.PlayClipAtPoint(touchClip, Camera.main.transform.position);
		yield return new WaitForSeconds(touchClip.length);
		currentState = 3;
		canTouch = true;
	}
	
	IEnumerator row3narration()
	{
		canTouch = false;
		AudioSource.PlayClipAtPoint(
			rowsNarration[2],
			Camera.main.transform.position
		);

		GameObject[] tempRow1GOs = GameObject.FindGameObjectsWithTag("Star");
		foreach (GameObject tempGO in tempRow1GOs)
		{
			tempGO.AddComponent<TiltAnimation>();
		}

		yield return new WaitForSeconds(rowsNarration[2].length);

		foreach (GameObject tempGO in tempRow1GOs)
		{
			Color tempColor = tempGO.GetComponent<SpriteRenderer>().color;
			tempColor.a = 256;
			tempGO.GetComponent<SpriteRenderer>().color = tempColor;

			Destroy(tempGO.GetComponent<TiltAnimation>());
		}
		
		hands[7].SetActive(true);
		AudioSource.PlayClipAtPoint(scribbleClip, Camera.main.transform.position);
		GameObject row3hatch1 = Instantiate(hatchPrefab,
			new Vector3(-5.9f, 1.3f, 0f),
			Quaternion.identity);
		row3hatch1.GetComponent<SpriteRenderer>().color = Color.green;
		yield return new WaitForSeconds(2.4f);
		
		
		Destroy(hands[7]);
		hands[8].SetActive(true);
		AudioSource.PlayClipAtPoint(scribbleClip, Camera.main.transform.position);
		GameObject row2hatch2 = Instantiate(hatchPrefab,
			new Vector3(-4.6f, 1.3f, 0f),
			Quaternion.identity);
		row2hatch2.GetComponent<SpriteRenderer>().color = Color.green;
		yield return new WaitForSeconds(2.4f);
		
		Destroy(hands[8]);
		foreach (GameObject tempGO in tempRow1GOs)
		{
			Instantiate(
				crossPrefab,
				tempGO.transform.position,
				Quaternion.identity
			);
		}
		
		yield return new WaitForSeconds(1f);
		AudioSource.PlayClipAtPoint(touchClip, Camera.main.transform.position);
		yield return new WaitForSeconds(touchClip.length);
		currentState = 4;
		canTouch = true;
	}
	
	IEnumerator row4narration()
	{
		canTouch = false;
		AudioSource.PlayClipAtPoint(
			rowsNarration[3],
			Camera.main.transform.position
		);

		GameObject[] tempRow1GOs = GameObject.FindGameObjectsWithTag("Square");
		foreach (GameObject tempGO in tempRow1GOs)
		{
			tempGO.AddComponent<TiltAnimation>();
		}

		yield return new WaitForSeconds(rowsNarration[3].length);

		foreach (GameObject tempGO in tempRow1GOs)
		{
			Color tempColor = tempGO.GetComponent<SpriteRenderer>().color;
			tempColor.a = 256;
			tempGO.GetComponent<SpriteRenderer>().color = tempColor;

			Destroy(tempGO.GetComponent<TiltAnimation>());
		}
		
		hands[9].SetActive(true);
		AudioSource.PlayClipAtPoint(scribbleClip, Camera.main.transform.position);
		GameObject row4hatch1 = Instantiate(hatchPrefab,
			new Vector3(-5.9f, 0.2f, 0f),
			Quaternion.identity);
		row4hatch1.GetComponent<SpriteRenderer>().color = Color.blue;
		yield return new WaitForSeconds(2.4f);
		
		Destroy(hands[9]);
		hands[10].SetActive(true);
		AudioSource.PlayClipAtPoint(scribbleClip, Camera.main.transform.position);
		GameObject row4hatch2 = Instantiate(hatchPrefab,
			new Vector3(-4.6f, 0.2f, 0f),
			Quaternion.identity);
		row4hatch2.GetComponent<SpriteRenderer>().color = Color.blue;
		yield return new WaitForSeconds(2.4f);
		
		Destroy(hands[10]);
		hands[11].SetActive(true);
		AudioSource.PlayClipAtPoint(scribbleClip, Camera.main.transform.position);
		GameObject row4hatch3 = Instantiate(hatchPrefab,
			new Vector3(-3.4f, 0.2f, 0f),
			Quaternion.identity);
		row4hatch3.GetComponent<SpriteRenderer>().color = Color.blue;
		yield return new WaitForSeconds(2.4f);
		
		Destroy(hands[11]);
		hands[12].SetActive(true);
		AudioSource.PlayClipAtPoint(scribbleClip, Camera.main.transform.position);
		GameObject row4hatch4 = Instantiate(hatchPrefab,
			new Vector3(-2.1f, 0.2f, 0f),
			Quaternion.identity);
		row4hatch4.GetComponent<SpriteRenderer>().color = Color.blue;
		yield return new WaitForSeconds(2.4f);
		
		Destroy(hands[12]);
		hands[13].SetActive(true);
		AudioSource.PlayClipAtPoint(scribbleClip, Camera.main.transform.position);
		GameObject row4hatch5 = Instantiate(hatchPrefab,
			new Vector3(-0.8f, 0.2f, 0f),
			Quaternion.identity);
		row4hatch5.GetComponent<SpriteRenderer>().color = Color.blue;
		yield return new WaitForSeconds(2.4f);
		
		Destroy(hands[13]);
		foreach (GameObject tempGO in tempRow1GOs)
		{
			Instantiate(
				crossPrefab,
				tempGO.transform.position,
				Quaternion.identity
			);
		}
		
		yield return new WaitForSeconds(1f);
		AudioSource.PlayClipAtPoint(touchClip, Camera.main.transform.position);
		yield return new WaitForSeconds(touchClip.length);
		currentState = 5;
		canTouch = true;
	}
	
	IEnumerator row5narration()
	{
		canTouch = false;
		AudioSource.PlayClipAtPoint(
			rowsNarration[4],
			Camera.main.transform.position
		);

		GameObject[] tempRow1GOs = GameObject.FindGameObjectsWithTag("Polygon");
		foreach (GameObject tempGO in tempRow1GOs)
		{
			tempGO.AddComponent<TiltAnimation>();
		}

		yield return new WaitForSeconds(rowsNarration[4].length);

		foreach (GameObject tempGO in tempRow1GOs)
		{
			Color tempColor = tempGO.GetComponent<SpriteRenderer>().color;
			tempColor.a = 256;
			tempGO.GetComponent<SpriteRenderer>().color = tempColor;

			Destroy(tempGO.GetComponent<TiltAnimation>());
		}
		
		hands[14].SetActive(true);
		AudioSource.PlayClipAtPoint(scribbleClip, Camera.main.transform.position);
		GameObject row5hatch1 = Instantiate(hatchPrefab,
			new Vector3(-5.9f, -1f, 0f),
			Quaternion.identity);
		row5hatch1.GetComponent<SpriteRenderer>().color = Color.magenta;
		yield return new WaitForSeconds(2.4f);
		
		Destroy(hands[14]);
		foreach (GameObject tempGO in tempRow1GOs)
		{	
			Instantiate(
				crossPrefab,
				tempGO.transform.position,
				Quaternion.identity
			);
		}
		
		yield return new WaitForSeconds(1f);
		AudioSource.PlayClipAtPoint(touchClip, Camera.main.transform.position);
		yield return new WaitForSeconds(touchClip.length);
		currentState = 6;
		canTouch = true;
	}
}
