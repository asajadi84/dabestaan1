using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerExercise : MonoBehaviour
{

	[SerializeField] private string tempString1;
	[SerializeField] private string tempString2;
	[SerializeField] private string tempString3;
	
	public static bool canClick = false;
	public static bool secondChance = false;

	public Sprite loseSprite;

	[SerializeField] private Sprite[] sprites;
	[SerializeField] private GameObject[] batches;
	[SerializeField] private AudioClip[] whichOneShowsTheNumber;
	public AudioClip winClip;
	public AudioClip winMusic;
	public AudioClip loseForSureClip;
	public AudioClip loseMusic;
	public AudioClip loseClip;
	[SerializeField] private int[] randomThree;
	[SerializeField] private int tempRandom;
	public static int randomIndex;
	
	public GameObject YouWonGameObject;
	
	void Awake ()
	{
		randomThree = new int[3];
		randomThree[0] = Random.Range(0, 5);
		
		randomThree[1] = randomThree[0];
		randomThree[2] = randomThree[0];

		while (randomThree[1] == randomThree[0])
		{
			randomThree[1] = Random.Range(0, 5);
		}
		
		while (randomThree[2] == randomThree[0] || randomThree[2] == randomThree[1])
		{
			randomThree[2] = Random.Range(0, 5);
		}
		
		tempString1 = (randomThree[0] + 1).ToString();
		tempString2 = (randomThree[1] + 1).ToString();
		tempString3 = (randomThree[2] + 1).ToString();

		randomIndex = Random.Range(0, 3);
		tempRandom = randomThree[randomIndex];
	}

	void Start()
	{
		AudioSource.PlayClipAtPoint(whichOneShowsTheNumber[tempRandom], Camera.main.transform.position);
		StartCoroutine(ExerciseCoroutine());
	}

	IEnumerator ExerciseCoroutine()
	{
		yield return new WaitForSeconds(2.0f);
		canClick = true;
		//First Shape
		// Shape index: 0=> circle    1=> square    2=> triangle
		int tempShapeIndex0 = Random.Range(0, sprites.Length);
		int tempShapeIndex1 = tempShapeIndex0;
		int tempShapeIndex2 = tempShapeIndex0;
		
		while (tempShapeIndex1 == tempShapeIndex0)
		{
			tempShapeIndex1 = Random.Range(0, sprites.Length);
		}
		
		while (tempShapeIndex2 == tempShapeIndex0 || tempShapeIndex2 == tempShapeIndex1)
		{
			tempShapeIndex2 = Random.Range(0, sprites.Length);
		}
		
		
		SpriteRenderer[] tempSpriteRendererComponents0 = batches[randomThree[0]].GetComponentsInChildren<SpriteRenderer>();
		foreach (var sprite in tempSpriteRendererComponents0)
		{
			sprite.sprite = sprites[tempShapeIndex0];
		}
		Instantiate(batches[randomThree[0]], new Vector3(-4.5f, 0.9f, 0f), Quaternion.identity);
		
		//Second Shape
		// Shape index: 0=> circle    1=> square    2=> triangle
		SpriteRenderer[] tempSpriteRendererComponents1 = batches[randomThree[1]].GetComponentsInChildren<SpriteRenderer>();
		foreach (var sprite in tempSpriteRendererComponents1)
		{
			sprite.sprite = sprites[tempShapeIndex1];
		}
		Instantiate(batches[randomThree[1]], new Vector3(0f, 0.9f, 0f), Quaternion.identity);
		
		//Third Shape
		// Shape index: 0=> circle    1=> square    2=> triangle
		SpriteRenderer[] tempSpriteRendererComponents2 = batches[randomThree[2]].GetComponentsInChildren<SpriteRenderer>();
		foreach (var sprite in tempSpriteRendererComponents2)
		{
			sprite.sprite = sprites[tempShapeIndex2];
		}
		Instantiate(batches[randomThree[2]], new Vector3(4.5f, 0.9f, 0f), Quaternion.identity);

		tempString1 += ShapeIndexCalculator(tempShapeIndex0);
		tempString2 += ShapeIndexCalculator(tempShapeIndex1);
		tempString3 += ShapeIndexCalculator(tempShapeIndex2);

		StringManager.Level1Exercise1_SLOT1 = tempString1;
		StringManager.Level1Exercise1_SLOT2 = tempString2;
		StringManager.Level1Exercise1_SLOT3 = tempString3;
		
		Debug.Log(StringManager.Level1Exercise1_SLOT1);
		Debug.Log(StringManager.Level1Exercise1_SLOT2);
		Debug.Log(StringManager.Level1Exercise1_SLOT3);
		
		yield return null;
	}

	string ShapeIndexCalculator(int shapeId)
	{
		switch (shapeId)
		{
			case 0:
				return "Cir";
			
			case 1:
				return "Squ";
			
			case 2:
				return "Tri";
		}

		return "";

	}
}
