using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameManagerLevel5Exercise1 : MonoBehaviour
{
	public bool secondChance = false;

	[SerializeField] private Sprite[] finger1Sprites;
	[SerializeField] private Sprite[] finger2Sprites;
	[SerializeField] private Sprite[] finger3Sprites;
	[SerializeField] private Sprite[] finger4Sprites;

	public GameObject[] fingers;
	
	private int[] randomNums = new int[3];
	public int randomIndex;
	
	[SerializeField] private AudioClip[] whichOne = new AudioClip[4];
	public AudioClip tryOneMoreTime;

	public GameObject winPrefab;
	public Sprite loseSprie;
	public AudioClip winClip;
	public AudioClip winMusic;
	public AudioClip loseClip;
	public AudioClip loseMusic;
	
	private void Awake()
	{
		//first random number
		randomNums[0] = Random.Range(1, 5);
		
		//second random number
		randomNums[1] = randomNums[0];
		while (randomNums[1] == randomNums[0])
		{
			randomNums[1] = Random.Range(1, 5);
		}
		
		//third random number
		randomNums[2] = randomNums[0];
		while (randomNums[2] == randomNums[0] || randomNums[2] == randomNums[1])
		{
			randomNums[2] = Random.Range(1, 5);
		}

		randomIndex = Random.Range(0, 3);
	}

	private void Start()
	{
		StartCoroutine(delayedStart(1f));
	}

	IEnumerator delayedStart(float delay)
	{
		yield return new WaitForSeconds(delay);

		for (int i = 0; i < 3; i++)
		{
			GOSpriteHandler(fingers[i], randomNums[i]);
		}
		
		AudioSource.PlayClipAtPoint(whichOne[randomNums[randomIndex]-1], Camera.main.transform.position);

		foreach (GameObject GO in fingers)
		{
			GO.AddComponent<BoxCollider2D>();
		}

		Debug.Log("Choices are: " + randomNums[0] + " : " + randomNums[1] + " : " + randomNums[2]);
		Debug.Log("The correct answer is slot number: "+ (randomIndex+1));
		Debug.Log("Which is: " + randomNums[randomIndex]);
	}

	void GOSpriteHandler(GameObject GO, int index)
	{
		switch (index)
		{
			case 1:
				int temp1 = Random.Range(0, finger1Sprites.Length);
				GO.GetComponent<SpriteRenderer>().sprite = finger1Sprites[temp1];
				break;
			
			case 2:
				int temp2 = Random.Range(0, finger2Sprites.Length);
				GO.GetComponent<SpriteRenderer>().sprite = finger2Sprites[temp2];
				break;
			
			case 3:
				int temp3 = Random.Range(0, finger3Sprites.Length);
				GO.GetComponent<SpriteRenderer>().sprite = finger3Sprites[temp3];
				break;
			
			case 4:
				int temp4 = Random.Range(0, finger4Sprites.Length);
				GO.GetComponent<SpriteRenderer>().sprite = finger4Sprites[temp4];
				break;
		}
		
	}
}
