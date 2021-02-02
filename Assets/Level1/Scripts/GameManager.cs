using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Text currentStateText;
	public static int currentState = 0;
	
	//Sprites
	[SerializeField] private Sprite[] sprites;
	[SerializeField] private GameObject[] batches;
	[SerializeField] private AudioClip[] howManyAudioClips;
	[SerializeField] private AudioClip[] thatsRightAudioClips;
	
	// Use this for initialization
	void Start ()
	{
		StartCoroutine(tutorialCoroutine());
	}

	public void MessageFromNavigationButtons(int i)
	{
		StopAllCoroutines();
		if (GameObject.FindGameObjectWithTag("batch") != null)
		{
			Destroy(GameObject.FindGameObjectWithTag("batch"));
		}
		
		AudioSource[] tempExtraSounds = GameObject.FindObjectsOfType<AudioSource>();
		foreach (AudioSource soundCheck in tempExtraSounds)
		{
			if (!soundCheck.gameObject.CompareTag("MainCamera"))
			{
				Destroy(soundCheck.gameObject);
			}
		}

		StartCoroutine(ShapeGenerator(currentState, 5.0f));
	}

	IEnumerator tutorialCoroutine()
	{
		yield return new WaitForSeconds(2.0f);

		StartCoroutine(ShapeGenerator(currentState, 5.0f));
	}

	IEnumerator ShapeGenerator(int index, float decayTime)
	{
		currentStateText.text = (currentState+1).ToString();
		// Shape index: 0=> circle    1=> square    2=> triangle
		int tempShapeIndex = Random.Range(0, sprites.Length);
		SpriteRenderer[] tempSpriteRendererComponents = batches[index].GetComponentsInChildren<SpriteRenderer>();
		foreach (var sprite in tempSpriteRendererComponents)
		{
			sprite.sprite = sprites[tempShapeIndex];
		}

		GameObject tempBatch = Instantiate(batches[index], new Vector3(1.76f, 0.82f, 0.0f),Quaternion.identity);
		StartCoroutine(Raise(tempBatch));
		StartCoroutine(Decay(tempBatch, decayTime-0.3f));
		AudioSource.PlayClipAtPoint(howManyAudioClips[tempShapeIndex], Camera.main.transform.position);
		yield return new WaitForSeconds(3.0f);
		AudioSource.PlayClipAtPoint(thatsRightAudioClips[index], Camera.main.transform.position);
		
		Destroy(tempBatch, decayTime);
		StopCoroutine(Raise(tempBatch));
		StopCoroutine(Decay(tempBatch, decayTime-0.3f));
	}

	IEnumerator Raise(GameObject temp)
	{
		while (temp!=null)
		{
			Vector3 tempVector3 = new Vector3(
				temp.transform.localScale.x+(Time.deltaTime/15),
				temp.transform.localScale.y+(Time.deltaTime/15),
				temp.transform.localScale.z
				);
			temp.transform.localScale = tempVector3;
			yield return new WaitForEndOfFrame();
		}
	}
	
	IEnumerator Decay(GameObject temp, float decayDelay)
	{
		yield return new WaitForSeconds(decayDelay);
		while (temp!=null)
		{
			float tempFloat = temp.GetComponentInChildren<SpriteRenderer>().color.a - (Time.deltaTime*5);
			SpriteRenderer[] tempSpriteRenderers = temp.GetComponentsInChildren<SpriteRenderer>();

			foreach (var batchMember in tempSpriteRenderers)
			{
				batchMember.GetComponent<SpriteRenderer>().color = new Color(
					batchMember.GetComponent<SpriteRenderer>().color.r,
					batchMember.GetComponent<SpriteRenderer>().color.g,
					batchMember.GetComponent<SpriteRenderer>().color.b,
					tempFloat
				);
			}

			yield return new WaitForEndOfFrame();
		}
	}

}
