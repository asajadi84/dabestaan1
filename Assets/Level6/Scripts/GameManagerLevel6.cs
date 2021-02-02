using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerLevel6 : MonoBehaviour
{

	[SerializeField] private GameObject[] solutions;
	[SerializeField] private GameObject[] targets;
	[SerializeField] private Sprite houseSprite;
	[SerializeField] private Sprite cloudSprite;
	[SerializeField] private Sprite trousersSprite;
	[SerializeField] private Sprite houseSpriteSketch;
	[SerializeField] private Sprite cloudSpriteSketch;
	[SerializeField] private Sprite trousersSpriteSketch;
	
	[SerializeField] private Sprite keySprite;
	[SerializeField] private Sprite umbrellaSprite;
	[SerializeField] private Sprite coatSprite;

	[SerializeField] private AudioClip[] narrations;
	[SerializeField] private AudioClip paintingClip;
	
	
	private void Start()
	{
		StartCoroutine(DelayedStart(1f, 0.5f));
	}

	IEnumerator DelayedStart(float delay, float tinyDelays)
	{
		yield return new WaitForSeconds(delay);

		//Step1
		solutions[0].GetComponent<SpriteRenderer>().sprite = keySprite;
		solutions[1].GetComponent<SpriteRenderer>().sprite = keySprite;
		solutions[2].GetComponent<SpriteRenderer>().sprite = keySprite;
		targets[0].GetComponent<SpriteRenderer>().sprite = houseSpriteSketch;
		targets[1].GetComponent<SpriteRenderer>().sprite = houseSpriteSketch;
		targets[2].GetComponent<SpriteRenderer>().sprite = houseSpriteSketch;
		targets[3].GetComponent<SpriteRenderer>().sprite = null;
		
		AudioSource.PlayClipAtPoint(narrations[0], Camera.main.transform.position);
		yield return new WaitForSeconds(narrations[0].length);

		StartCoroutine(Solve(solutions[0], targets[0], houseSprite));
		yield return new WaitForSeconds(tinyDelays);
		StartCoroutine(Solve(solutions[1], targets[1], houseSprite));
		yield return new WaitForSeconds(tinyDelays);
		StartCoroutine(Solve(solutions[2], targets[2], houseSprite));
		yield return new WaitForSeconds(3f);
		
		//Step2
		solutions[0].GetComponent<SpriteRenderer>().sprite = umbrellaSprite;
		solutions[1].GetComponent<SpriteRenderer>().sprite = null;
		solutions[2].GetComponent<SpriteRenderer>().sprite = null;
		targets[0].GetComponent<SpriteRenderer>().sprite = cloudSpriteSketch;
		targets[1].GetComponent<SpriteRenderer>().sprite = cloudSpriteSketch;
		targets[2].GetComponent<SpriteRenderer>().sprite = cloudSpriteSketch;
		targets[3].GetComponent<SpriteRenderer>().sprite = null;
		
		AudioSource.PlayClipAtPoint(narrations[1], Camera.main.transform.position);
		yield return new WaitForSeconds(narrations[1].length);

		StartCoroutine(Solve(solutions[0], targets[0], cloudSprite));
		yield return new WaitForSeconds(3f);
		
		//Step3
		solutions[0].GetComponent<SpriteRenderer>().sprite = coatSprite;
		solutions[1].GetComponent<SpriteRenderer>().sprite = coatSprite;
		solutions[2].GetComponent<SpriteRenderer>().sprite = null;
		targets[0].GetComponent<SpriteRenderer>().sprite = trousersSpriteSketch;
		targets[1].GetComponent<SpriteRenderer>().sprite = trousersSpriteSketch;
		targets[2].GetComponent<SpriteRenderer>().sprite = trousersSpriteSketch;
		targets[3].GetComponent<SpriteRenderer>().sprite = trousersSpriteSketch;
		
		AudioSource.PlayClipAtPoint(narrations[2], Camera.main.transform.position);
		yield return new WaitForSeconds(narrations[2].length);

		StartCoroutine(Solve(solutions[0], targets[0], trousersSprite));
		yield return new WaitForSeconds(tinyDelays);
		StartCoroutine(Solve(solutions[1], targets[1], trousersSprite));
		
		yield return new WaitForSeconds(3f);
		foreach (GameObject GO in targets)
		{
			Destroy(GO);
		}

	}

	IEnumerator Solve(GameObject SolutionGO, GameObject TargetGO, Sprite TargetSprite, float movementSpeed = 1)
	{
		Vector3 SolutionPosition = SolutionGO.transform.position;
		Vector3 targetPosition = TargetGO.transform.position;

		float currentProcess = 0f;

		while (currentProcess < 1f)
		{
			SolutionGO.transform.position = Vector3.Lerp(SolutionPosition,targetPosition,currentProcess);
			currentProcess += Time.deltaTime * movementSpeed;
			yield return new WaitForEndOfFrame();
		}

		AudioSource.PlayClipAtPoint(paintingClip, Camera.main.transform.position);
		TargetGO.GetComponent<SpriteRenderer>().sprite = TargetSprite;
		Coroutine tmp = StartCoroutine(Decay(SolutionGO));
		yield return tmp;

		SolutionGO.GetComponent<SpriteRenderer>().sprite = null;
		Color tempColor = SolutionGO.GetComponent<SpriteRenderer>().color;
		tempColor.a = 1f;
		SolutionGO.GetComponent<SpriteRenderer>().color = tempColor;
		SolutionGO.transform.position = SolutionPosition;
		
		yield return null;
	}

	IEnumerator Decay(GameObject GO, float decaySpeed = 1)
	{
		Color tempColor;
		while (GO.GetComponent<SpriteRenderer>().color.a > 0f)
		{
			tempColor = GO.GetComponent<SpriteRenderer>().color;
			tempColor.a -= Time.deltaTime * decaySpeed;
			GO.GetComponent<SpriteRenderer>().color = tempColor;
			
			yield return new WaitForEndOfFrame();
		}

		yield return null;
	}
}
