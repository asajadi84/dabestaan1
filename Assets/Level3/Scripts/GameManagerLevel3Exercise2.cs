using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManagerLevel3Exercise2 : MonoBehaviour
{
	private string tempString1;
	private string tempString2;
	
	[SerializeField] private AudioClip whichSequence;
	
	[SerializeField] private Sprite[] randomSprites = new Sprite[5];
	[SerializeField] private Color[] randomSpritesColors = new Color[5];
	[SerializeField] private string[] randomSpritesColorsStrings = new String[5];
	
	[SerializeField] private Sprite[] correctSequence = new Sprite[8];
	public Color[] correctSequenceColors = new Color[8];
	[SerializeField] private Sprite[] incorrectSequence = new Sprite[8];
	
	[SerializeField] private SpriteRenderer[] topRowSprites = new SpriteRenderer[8];
	[SerializeField] private SpriteRenderer[] bottomRowSprites = new SpriteRenderer[8];

	[SerializeField] private GameObject YouWonGameObject;
	[SerializeField] private AudioClip correctRowCollectedClip;
	[SerializeField] private AudioClip wellDoneNowColor;
	
	[SerializeField] private GameObject blankHouses;
	public GameObject hatchPrefab;
	
	private int firstSprite;
	private int secondSprite;
	private int thirdSprite;
	private int fourthSprite;

	public bool canColorSequence = false;
	
	public Color[] currentSeqColor = new Color[8];
	public GameObject[] currentSeqColorHatchGOs = new GameObject[8];
	
	public Color ActiveColor;
	
	public bool theTopIsCorrect = false;
	
	[SerializeField] private Sprite loseSprite;
	[SerializeField] private AudioClip loseClip;
	[SerializeField] private AudioClip loseMusic;
	[SerializeField] private GameObject emptyRow;
	[SerializeField] private GameObject paintPalette;
	[SerializeField] private GameObject color1;
	[SerializeField] private GameObject color2;

	public Vector3[] hatchPositions = new Vector3[8];
	[SerializeField] private AudioClip winClip;
	[SerializeField] private AudioClip winMusic;

	private void Awake()
	{
		firstSprite = Random.Range(0, 5);

		secondSprite = firstSprite;
		while (secondSprite == firstSprite)
		{
			secondSprite = Random.Range(0, 5);
		}

		thirdSprite = firstSprite;
		while (thirdSprite == firstSprite || thirdSprite == secondSprite)
		{
			thirdSprite = Random.Range(0, 5);
		}

		fourthSprite = firstSprite;
		while (fourthSprite == firstSprite || fourthSprite == secondSprite || fourthSprite == thirdSprite)
		{
			fourthSprite = Random.Range(0, 5);
		}
	}

	// Use this for initialization
	void Start ()
	{
		StartCoroutine(GenerateSequences(1.0f));
	}

	IEnumerator GenerateSequences(float delay)
	{
		yield return new WaitForSeconds(delay);
		
		AudioSource.PlayClipAtPoint(whichSequence, Camera.main.transform.position);
		
		//Create the correct sequence
		int tempRandom1 = Random.Range(0, 3);
		switch (tempRandom1)
		{
			case 0:
				tempString1 = "Type1";
				correctSequence[0] = randomSprites[firstSprite];
				correctSequence[1] = randomSprites[secondSprite];
				correctSequence[2] = randomSprites[firstSprite];
				correctSequence[3] = randomSprites[secondSprite];
				correctSequence[4] = randomSprites[firstSprite];
				correctSequence[5] = randomSprites[secondSprite];
				correctSequence[6] = randomSprites[firstSprite];
				correctSequence[7] = randomSprites[secondSprite];
				
				correctSequenceColors[0] = randomSpritesColors[firstSprite];
				correctSequenceColors[1] = randomSpritesColors[secondSprite];
				correctSequenceColors[2] = randomSpritesColors[firstSprite];
				correctSequenceColors[3] = randomSpritesColors[secondSprite];
				correctSequenceColors[4] = randomSpritesColors[firstSprite];
				correctSequenceColors[5] = randomSpritesColors[secondSprite];
				correctSequenceColors[6] = randomSpritesColors[firstSprite];
				correctSequenceColors[7] = randomSpritesColors[secondSprite];
				break;
			
			case 1:
				tempString1 = "Type2";
				correctSequence[0] = randomSprites[firstSprite];
				correctSequence[1] = randomSprites[secondSprite];
				correctSequence[2] = randomSprites[secondSprite];
				correctSequence[3] = randomSprites[firstSprite];
				correctSequence[4] = randomSprites[secondSprite];
				correctSequence[5] = randomSprites[secondSprite];
				correctSequence[6] = randomSprites[firstSprite];
				correctSequence[7] = randomSprites[secondSprite];
				
				correctSequenceColors[0] = randomSpritesColors[firstSprite];
				correctSequenceColors[1] = randomSpritesColors[secondSprite];
				correctSequenceColors[2] = randomSpritesColors[secondSprite];
				correctSequenceColors[3] = randomSpritesColors[firstSprite];
				correctSequenceColors[4] = randomSpritesColors[secondSprite];
				correctSequenceColors[5] = randomSpritesColors[secondSprite];
				correctSequenceColors[6] = randomSpritesColors[firstSprite];
				correctSequenceColors[7] = randomSpritesColors[secondSprite];
				break;
			
			case 2:
				tempString1 = "Type3";
				correctSequence[0] = randomSprites[firstSprite];
				correctSequence[1] = randomSprites[firstSprite];
				correctSequence[2] = randomSprites[secondSprite];
				correctSequence[3] = randomSprites[secondSprite];
				correctSequence[4] = randomSprites[firstSprite];
				correctSequence[5] = randomSprites[firstSprite];
				correctSequence[6] = randomSprites[secondSprite];
				correctSequence[7] = randomSprites[secondSprite];
				
				correctSequenceColors[0] = randomSpritesColors[firstSprite];
				correctSequenceColors[1] = randomSpritesColors[firstSprite];
				correctSequenceColors[2] = randomSpritesColors[secondSprite];
				correctSequenceColors[3] = randomSpritesColors[secondSprite];
				correctSequenceColors[4] = randomSpritesColors[firstSprite];
				correctSequenceColors[5] = randomSpritesColors[firstSprite];
				correctSequenceColors[6] = randomSpritesColors[secondSprite];
				correctSequenceColors[7] = randomSpritesColors[secondSprite];
				break;
		}
		
		//Create the incorrect sequence
		int tempRandom2 = Random.Range(0, 3);
		switch (tempRandom2)
		{
			case 0:
				tempString2 = "Type1";
				incorrectSequence[0] = randomSprites[thirdSprite];
				incorrectSequence[1] = randomSprites[fourthSprite];
				incorrectSequence[2] = randomSprites[thirdSprite];
				incorrectSequence[3] = randomSprites[thirdSprite];
				incorrectSequence[4] = randomSprites[fourthSprite];
				incorrectSequence[5] = randomSprites[thirdSprite];
				incorrectSequence[6] = randomSprites[fourthSprite];
				incorrectSequence[7] = randomSprites[fourthSprite];
				break;
			
			case 1:
				tempString2 = "Type2";
				incorrectSequence[0] = randomSprites[thirdSprite];
				incorrectSequence[1] = randomSprites[fourthSprite];
				incorrectSequence[2] = randomSprites[fourthSprite];
				incorrectSequence[3] = randomSprites[thirdSprite];
				incorrectSequence[4] = randomSprites[thirdSprite];
				incorrectSequence[5] = randomSprites[fourthSprite];
				incorrectSequence[6] = randomSprites[thirdSprite];
				incorrectSequence[7] = randomSprites[fourthSprite];
				break;
			
			case 2:
				tempString2 = "Type3";
				incorrectSequence[0] = randomSprites[thirdSprite];
				incorrectSequence[1] = randomSprites[fourthSprite];
				incorrectSequence[2] = randomSprites[fourthSprite];
				incorrectSequence[3] = randomSprites[fourthSprite];
				incorrectSequence[4] = randomSprites[thirdSprite];
				incorrectSequence[5] = randomSprites[thirdSprite];
				incorrectSequence[6] = randomSprites[thirdSprite];
				incorrectSequence[7] = randomSprites[fourthSprite];
				break;
		}

		StringManager.Level3Exercise2_CorrectSEQUENCE = tempString1 + randomSpritesColorsStrings[firstSprite] +
		                                                randomSpritesColorsStrings[secondSprite];
		StringManager.Level3Exercise2_IncorrectSEQUENCE = tempString2 + randomSpritesColorsStrings[thirdSprite] +
		                                                randomSpritesColorsStrings[fourthSprite];
		Debug.Log(StringManager.Level3Exercise2_CorrectSEQUENCE);
		Debug.Log(StringManager.Level3Exercise2_IncorrectSEQUENCE);
		

		int tempRandom3 = Random.Range(0, 2);
		theTopIsCorrect = tempRandom3 == 0;

		if (theTopIsCorrect)
		{
			for (int i = 0; i < 8; i++)
			{
				topRowSprites[i].sprite = correctSequence[i];
				bottomRowSprites[i].sprite = incorrectSequence[i];
			}
		}
		else
		{
			for (int i = 0; i < 8; i++)
			{
				topRowSprites[i].sprite = incorrectSequence[i];
				bottomRowSprites[i].sprite = correctSequence[i];
			}
		}
	}

	void PlayerWin()
	{
		AudioSource.PlayClipAtPoint(correctRowCollectedClip, Camera.main.transform.position);
		
		StartCoroutine(GOFade(
			GameObject.Find("subMenu Top"),
			3.0f, 0.5f
			));
		
		StartCoroutine(GOFade(
			GameObject.Find("subMenu Bottom"),
			3.0f, 1.0f
		));

		StartCoroutine(fruitsFadeAnimation(10.0f, 0.05f));

		if (!theTopIsCorrect)
		{
			StartCoroutine(TranslateByTransform(
				GameObject.Find("Bottom Row Sprites"),
				GameObject.Find("Top Row Sprites").transform.position,
				5.0f,
				1.5f
				));
		}
		
		Destroy(GameObject.Find("Top Row Collider"));
		Destroy(GameObject.Find("Bottom Row Collider"));

		StartCoroutine(GOFadeIn(emptyRow, 2.0f, 2.0f));

		StartCoroutine(StartColoringProcess(2.0f));
	}

	void PlayerLose()
	{
		Destroy(GameObject.Find("Top Row Collider"));
		Destroy(GameObject.Find("Bottom Row Collider"));

		GameObject[] temp = GameObject.FindGameObjectsWithTag("removeAfterWin");
		foreach (GameObject GO in temp)
		{
			Destroy(GO);
		}
		
		Instantiate(
			YouWonGameObject,
			Vector3.zero, Quaternion.identity
		);
		GameObject.Find("layer 9").GetComponent<SpriteRenderer>().sprite = loseSprite;

		GameObject.Find("layer 8").GetComponent<SpriteRenderer>().color = Color.black;
		GameObject.Find("layer 7").GetComponent<SpriteRenderer>().color = Color.red;
			
		AudioSource.PlayClipAtPoint(
			loseClip,
			Camera.main.transform.position
		);
		AudioSource.PlayClipAtPoint(
			loseMusic,
			Camera.main.transform.position,
			0.3f
		);
	}

	void PlayerFinalWin()
	{
		GameObject[] temp = GameObject.FindGameObjectsWithTag("removeAfterWin");
		foreach (GameObject GO in temp)
		{
			Destroy(GO);
		}
		
		
		Instantiate(
			YouWonGameObject,
			Vector3.zero, Quaternion.identity
		);
			
		AudioSource.PlayClipAtPoint(
			winClip,
			Camera.main.transform.position
		);
		AudioSource.PlayClipAtPoint(
			winMusic,
			Camera.main.transform.position,
			0.3f
		);
	}

	IEnumerator GOFade(GameObject GO, float speed, float firstDelay)
	{
		yield return new WaitForSeconds(firstDelay);
		while (GO.GetComponent<SpriteRenderer>().color.a > 0f)
		{
			Color temp = GO.GetComponent<SpriteRenderer>().color;
			temp.a -= Time.deltaTime * speed;
			GO.GetComponent<SpriteRenderer>().color = temp;
			yield return new WaitForEndOfFrame();
		}
	}

	IEnumerator GOFadeIn(GameObject GO, float speed, float firstDelay)
	{
		yield return new WaitForSeconds(firstDelay);
		while (GO.GetComponent<SpriteRenderer>().color.a < 1f)
		{
			Color temp = GO.GetComponent<SpriteRenderer>().color;
			temp.a += Time.deltaTime * speed;
			GO.GetComponent<SpriteRenderer>().color = temp;
			yield return new WaitForEndOfFrame();
		}
	}
	
	IEnumerator fruitsFadeAnimation(float fadeSpeed, float tinyDelay)
	{
		if (theTopIsCorrect)
		{
			foreach (SpriteRenderer tempSR in bottomRowSprites)
			{
				StartCoroutine(GOFade(tempSR.gameObject, fadeSpeed,0f));
				yield return new WaitForSeconds(tinyDelay);
			}
		}
		else
		{
			foreach (SpriteRenderer tempSR in topRowSprites)
			{
				StartCoroutine(GOFade(tempSR.gameObject, fadeSpeed,0f));
				yield return new WaitForSeconds(tinyDelay);
			}
		}
		
		yield return null;
	}

	IEnumerator TranslateByTransform(GameObject GO, Vector3 destination, float speed, float firstDelay)
	{
		yield return new WaitForSeconds(firstDelay);
		while (GO.transform.position.y<destination.y)
		{
			GO.transform.Translate(Vector3.up * Time.deltaTime * speed);
			yield return new WaitForEndOfFrame();
		}

		GO.transform.position = destination;
		yield return null;
	}

	IEnumerator StartColoringProcess(float delay)
	{
		yield return new WaitForSeconds(delay);
		AudioSource.PlayClipAtPoint(wellDoneNowColor, Camera.main.transform.position);
		yield return new WaitForSeconds(wellDoneNowColor.length);

		paintPalette.SetActive(true);	
		color1.GetComponent<SpriteRenderer>().color = randomSpritesColors[firstSprite];
		color2.GetComponent<SpriteRenderer>().color = randomSpritesColors[secondSprite];
		color1.SetActive(true);	
		color2.SetActive(true);

		Instantiate(blankHouses);
		canColorSequence = true;
	}
}
