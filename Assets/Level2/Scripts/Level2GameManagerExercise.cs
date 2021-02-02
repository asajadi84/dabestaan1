using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2GameManagerExercise : MonoBehaviour
{
	public bool canTouch = false;
	
	public GameObject hatchPrefab;
	public Vector3[] hatchPositions = new Vector3[25];
	public int[] rowColored;
	public Color[] rowColors = new Color[5];
	public AudioClip errorClip;
	[SerializeField] private AudioClip exerciseNarration;
	public GameObject youWonGO;
	public AudioClip winClip;
	public AudioClip winMusic;
	public AudioClip loseClip;
	public AudioClip loseMusic;
	public Sprite loseSprite;
	public AudioClip[] rowIncorrections;

	[SerializeField] private SpriteRenderer[] shapeSprites = new SpriteRenderer[14];
	[SerializeField] private Sprite[] shapes = new Sprite[5];
	public int[] correctAnswers = new int[5];
	
	void Awake () {
		rowColored = new int[5];
		
		rowColors[0] = Color.red;
		rowColors[1] = Color.yellow;
		rowColors[2] = Color.green;
		rowColors[3] = Color.blue;
		rowColors[4] = Color.magenta;

		for (int i = 0; i < 14; i++)
		{
			int temp = Random.Range(0, 5);

			if (correctAnswers[temp] < 5)
			{
				shapeSprites[i].sprite = shapes[temp];
				correctAnswers[temp]++;
			}
			else
			{
				Debug.Log("hi");
			}
			
		}

		StringManager.Level2Exercise1_ROWS = correctAnswers[0].ToString() + correctAnswers[1].ToString() + correctAnswers[2].ToString() +
		                                     correctAnswers[3].ToString() + correctAnswers[4].ToString();
		Debug.Log(StringManager.Level2Exercise1_ROWS);
	}

	private void Start()
	{
		StartCoroutine(startExerciseNarration(1.0f));
	}

	IEnumerator startExerciseNarration(float delay)
	{
		yield return new WaitForSeconds(delay);
		canTouch = true;
		AudioSource.PlayClipAtPoint(exerciseNarration, Camera.main.transform.position);
		
		
	}
}
