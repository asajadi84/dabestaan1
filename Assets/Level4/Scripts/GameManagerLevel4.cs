using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerLevel4 : MonoBehaviour
{

	public int currentState = 0;
	
	[SerializeField] private Transform[] topRowCards = new Transform[5];
	[SerializeField] private Transform[] bottomRowCards = new Transform[5];
	[SerializeField] private Color[] cuteColors = new Color[5];
	private LineRenderer[] LineRenderers = new LineRenderer[5];
	[SerializeField] private AudioClip narration;
	private GameObject[] linesArray = new GameObject[5];
	
	[SerializeField] private AudioClip[] lineDrawNarrations = new AudioClip[5];
	//[SerializeField] private AudioClip touchToContinue;
	[SerializeField] private AudioClip nowGoToExercise;

//	private bool canTouch = false;
	
	private void Awake()
	{
		DrawLine(topRowCards[0].position, bottomRowCards[0].position,0);
		DrawLine(topRowCards[1].position, bottomRowCards[1].position,1);
		DrawLine(topRowCards[2].position, bottomRowCards[2].position,2);
		DrawLine(topRowCards[3].position, bottomRowCards[3].position,3);
		DrawLine(topRowCards[4].position, bottomRowCards[4].position,4);

		foreach (GameObject GO in linesArray)
		{
			GO.SetActive(false);
		}
	}

	private void Start()
	{
		StartCoroutine(PlayNarration(1.0f));
	}

	private void Update()
	{
		for (int i = 0; i < 5; i++)
		{
			LineRenderers[i].SetPosition(0, topRowCards[i].position);
			LineRenderers[i].SetPosition(1, bottomRowCards[i].position);
		}
		
	}

	IEnumerator PlayNarration(float delay)
	{
		yield return new WaitForSeconds(delay);
		AudioSource.PlayClipAtPoint(narration, Camera.main.transform.position);
		yield return new WaitForSeconds(narration.length);
		//AudioSource.PlayClipAtPoint(touchToContinue, Camera.main.transform.position);
		//yield return new WaitForSeconds(touchToContinue.length-0.75f);
		//canTouch = true;
		
		MakeVisibleByState(1);
		AudioSource.PlayClipAtPoint(lineDrawNarrations[0], Camera.main.transform.position);
		yield return new WaitForSeconds(lineDrawNarrations[0].length);
		
		MakeVisibleByState(2);
		AudioSource.PlayClipAtPoint(lineDrawNarrations[1], Camera.main.transform.position);
		yield return new WaitForSeconds(lineDrawNarrations[1].length);
		
		MakeVisibleByState(3);
		AudioSource.PlayClipAtPoint(lineDrawNarrations[2], Camera.main.transform.position);
		yield return new WaitForSeconds(lineDrawNarrations[2].length);
		
		MakeVisibleByState(4);
		AudioSource.PlayClipAtPoint(lineDrawNarrations[3], Camera.main.transform.position);
		yield return new WaitForSeconds(lineDrawNarrations[3].length);
		
		MakeVisibleByState(5);
		AudioSource.PlayClipAtPoint(lineDrawNarrations[4], Camera.main.transform.position);
		yield return new WaitForSeconds(lineDrawNarrations[4].length);
		
		AudioSource.PlayClipAtPoint(nowGoToExercise, Camera.main.transform.position);
		
	}

//	private void OnMouseUp()
//	{
//		if (canTouch)
//		{
//			StartCoroutine(NextStage());
//		}
//	}

/*	IEnumerator NextStage()
	{
		canTouch = false;

		if (currentState < 5)
		{
			currentState++;
			MakeVisibleByState(currentState);
			
			AudioSource.PlayClipAtPoint(lineDrawNarrations[currentState-1], Camera.main.transform.position);
			yield return new WaitForSeconds(lineDrawNarrations[currentState-1].length);
			
			AudioSource.PlayClipAtPoint(touchToContinue, Camera.main.transform.position);
			yield return new WaitForSeconds(touchToContinue.length-0.75f);
			canTouch = true;
		}
		else
		{
			AudioSource.PlayClipAtPoint(nowGoToExercise, Camera.main.transform.position);
		}
	}*/

	//inspired by => https://answers.unity.com/questions/8338/how-to-draw-a-line-using-script.html
	void DrawLine(Vector3 start, Vector3 end, int lineRendererIndex)
	{
		int temp1 = Random.Range(0, cuteColors.Length);
		int temp2 = temp1;
		while (temp2 == temp1)
		{
			temp2 = Random.Range(0, cuteColors.Length);
		}

		linesArray[lineRendererIndex] = new GameObject("LineRenderer No" + lineRendererIndex);
		linesArray[lineRendererIndex].tag = "lines";
		linesArray[lineRendererIndex].transform.position = start;
		linesArray[lineRendererIndex].AddComponent<LineRenderer>();
		LineRenderers[lineRendererIndex] = linesArray[lineRendererIndex].GetComponent<LineRenderer>();
		LineRenderers[lineRendererIndex].material = new Material(Shader.Find("Sprites/Default"));
		LineRenderers[lineRendererIndex].sortingOrder = 9;
		LineRenderers[lineRendererIndex].startColor = cuteColors[temp1];
		LineRenderers[lineRendererIndex].endColor = cuteColors[temp2];
		LineRenderers[lineRendererIndex].startWidth = 0.1f;
		LineRenderers[lineRendererIndex].endWidth = 0.1f;
		LineRenderers[lineRendererIndex].SetPosition(0, start);
		LineRenderers[lineRendererIndex].SetPosition(1, end);
	}

	public void MakeVisibleByState(int until)
	{
		for (int i = 0; i < linesArray.Length; i++)
		{
			if (i < until)
			{
				linesArray[i].SetActive(true);
			}
			else
			{
				linesArray[i].SetActive(false);
			}
		}
	}
}
