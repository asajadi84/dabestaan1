using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerLevel5 : MonoBehaviour
{

	[SerializeField] private Sprite[] finger1;
	[SerializeField] private Sprite[] finger2;
	[SerializeField] private Sprite[] finger3;
	[SerializeField] private Sprite[] finger4;
	
	[SerializeField] private GameObject[] fingerSlots = new GameObject[5];

	[SerializeField] private AudioClip[] narrationClips;
	[SerializeField] private AudioClip nowGoToTheExercise;

	private void Start()
	{
		StartCoroutine(delayedStart(1f));
	}

	IEnumerator delayedStart(float delay)
	{
		yield return new WaitForSeconds(delay);
		
		StartCoroutine(ShowById(1));
		yield return new WaitForSeconds(narrationClips[0].length+3f);
		
		StartCoroutine(ShowById(2));
		yield return new WaitForSeconds(narrationClips[1].length+3f);
		
		StartCoroutine(ShowById(3));
		yield return new WaitForSeconds(narrationClips[2].length+3f);
		
		StartCoroutine(ShowById(4));
		yield return new WaitForSeconds(narrationClips[3].length+3f);
		
		AudioSource.PlayClipAtPoint(nowGoToTheExercise, Camera.main.transform.position);
	}

	IEnumerator ShowById(int n)
	{
		AudioSource.PlayClipAtPoint(narrationClips[n - 1], Camera.main.transform.position);
		switch (n)
		{		
			case 1:
				for (int i = 0; i < finger1.Length; i++)
				{
					fingerSlots[i].GetComponent<SpriteRenderer>().sprite = finger1[i];
				}
				for (int j = finger1.Length+1; j < fingerSlots.Length; j++)
				{
					fingerSlots[j].GetComponent<SpriteRenderer>().sprite = null;
				}

				for (int k = 0; k < finger1.Length; k++)
				{
					StartCoroutine(FadeGO(fingerSlots[k], true, 2f));
					yield return new WaitForSeconds(1.02f);
				}
				break;
			
			case 2:
				for (int i = 0; i < finger2.Length; i++)
				{
					fingerSlots[i].GetComponent<SpriteRenderer>().sprite = finger2[i];
				}
				for (int j = finger2.Length+1; j < fingerSlots.Length; j++)
				{
					fingerSlots[j].GetComponent<SpriteRenderer>().sprite = null;
				}

				for (int k = 0; k < finger2.Length; k++)
				{
					StartCoroutine(FadeGO(fingerSlots[k], true, 2f));
					yield return new WaitForSeconds(1.02f);
				}
				break;
			
			case 3:
				for (int i = 0; i < finger3.Length; i++)
				{
					fingerSlots[i].GetComponent<SpriteRenderer>().sprite = finger3[i];
				}
				for (int j = finger3.Length+1; j < fingerSlots.Length; j++)
				{
					fingerSlots[j].GetComponent<SpriteRenderer>().sprite = null;
				}

				for (int k = 0; k < finger3.Length; k++)
				{
					StartCoroutine(FadeGO(fingerSlots[k], true, 2f));
					yield return new WaitForSeconds(0.5f);
				}
				break;

			
			case 4:
				for (int i = 0; i < finger4.Length; i++)
				{
					fingerSlots[i].GetComponent<SpriteRenderer>().sprite = finger4[i];
				}
				for (int j = finger4.Length+1; j < fingerSlots.Length; j++)
				{
					fingerSlots[j].GetComponent<SpriteRenderer>().sprite = null;
				}

				for (int k = 0; k < finger4.Length; k++)
				{
					StartCoroutine(FadeGO(fingerSlots[k], true, 2f));
					yield return new WaitForSeconds(1.02f);
				}
				break;
			
			
				
		}

		yield return new WaitForSeconds(narrationClips[n - 1].length);
		
		foreach (GameObject GO in fingerSlots)
		{
			StartCoroutine(FadeGO(GO, false, 5f));
		}

	}


	IEnumerator FadeGO(GameObject GO, bool fadeIn, float speed)
	{
		SpriteRenderer tempRenderer = GO.GetComponent<SpriteRenderer>();
		Color tempColor;

		while (fadeIn ? tempRenderer.color.a < 1.0f : tempRenderer.color.a > 0f)
		{
			tempColor = tempRenderer.color;
			tempColor.a += Time.deltaTime * speed * (fadeIn ? 1 : -1);
			GO.GetComponent<SpriteRenderer>().color = tempColor;
			yield return new WaitForEndOfFrame();
		}

		yield return null;
	}
}
