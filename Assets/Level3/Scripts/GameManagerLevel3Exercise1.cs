using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerLevel3Exercise1 : MonoBehaviour
{
	public bool notThisScene;
	
	private string tempString;
	
	public AudioClip winClip;
	public AudioClip winMusic;
	
	public AudioClip pickAColor;
	public AudioClip errorClip;
	public GameObject youWin;
	
	[SerializeField] private Sprite[] seqSprites;
	public Color[] seqColors;
	[SerializeField] private string[] seqColorNames;
	public Color activeColor;
	
	[SerializeField] private int seqFirstItem;
	[SerializeField] private int seqSecondItem;
	
	public Color[] seqColorsState = new Color[8];
	public Color[] currectAnswer = new Color[8];

	[SerializeField] private AudioClip exerciseNarration;

	public GameObject[] tileColrs;

	private void Awake()
	{

		GameObject.Find("color1").GetComponent<SpriteRenderer>().color = seqColors[0];
		GameObject.Find("color2").GetComponent<SpriteRenderer>().color = seqColors[1];
		GameObject.Find("color3").GetComponent<SpriteRenderer>().color = seqColors[2];
		GameObject.Find("color4").GetComponent<SpriteRenderer>().color = seqColors[3];
		GameObject.Find("color5").GetComponent<SpriteRenderer>().color = seqColors[4];
	
		seqFirstItem = Random.Range(0, 5);
		seqSecondItem = seqFirstItem;

		while (seqSecondItem == seqFirstItem)
		{
			seqSecondItem = Random.Range(0, 5);
		}
	}

	// Use this for initialization
	void Start ()
	{
		StartCoroutine(delayedStart(1.0f));
	}


	IEnumerator delayedStart(float delay)
	{
		yield return new WaitForSeconds(delay);

		AudioSource.PlayClipAtPoint(exerciseNarration, Camera.main.transform.position);
		
		int seqType = Random.Range(1, 4);
		switch (seqType)
		{
			case 1:
				tempString = "Type1";
				GameObject.Find("fruit1").GetComponent<SpriteRenderer>().sprite = seqSprites[seqFirstItem];
				currectAnswer[0] = seqColors[seqFirstItem];
				GameObject.Find("fruit2").GetComponent<SpriteRenderer>().sprite = seqSprites[seqSecondItem];
				currectAnswer[1] = seqColors[seqSecondItem];
				GameObject.Find("fruit3").GetComponent<SpriteRenderer>().sprite = seqSprites[seqFirstItem];
				currectAnswer[2] = seqColors[seqFirstItem];
				GameObject.Find("fruit4").GetComponent<SpriteRenderer>().sprite = seqSprites[seqSecondItem];
				currectAnswer[3] = seqColors[seqSecondItem];
				GameObject.Find("fruit5").GetComponent<SpriteRenderer>().sprite = seqSprites[seqFirstItem];
				currectAnswer[4] = seqColors[seqFirstItem];
				GameObject.Find("fruit6").GetComponent<SpriteRenderer>().sprite = seqSprites[seqSecondItem];
				currectAnswer[5] = seqColors[seqSecondItem];
				GameObject.Find("fruit7").GetComponent<SpriteRenderer>().sprite = seqSprites[seqFirstItem];
				currectAnswer[6] = seqColors[seqFirstItem];
				GameObject.Find("fruit8").GetComponent<SpriteRenderer>().sprite = seqSprites[seqSecondItem];
				currectAnswer[7] = seqColors[seqSecondItem];
				break;
			
			case 2:
				tempString = "Type2";
				GameObject.Find("fruit1").GetComponent<SpriteRenderer>().sprite = seqSprites[seqFirstItem];
				currectAnswer[0] = seqColors[seqFirstItem];
				GameObject.Find("fruit2").GetComponent<SpriteRenderer>().sprite = seqSprites[seqFirstItem];
				currectAnswer[1] = seqColors[seqFirstItem];
				GameObject.Find("fruit3").GetComponent<SpriteRenderer>().sprite = seqSprites[seqSecondItem];
				currectAnswer[2] = seqColors[seqSecondItem];
				GameObject.Find("fruit4").GetComponent<SpriteRenderer>().sprite = seqSprites[seqSecondItem];
				currectAnswer[3] = seqColors[seqSecondItem];
				GameObject.Find("fruit5").GetComponent<SpriteRenderer>().sprite = seqSprites[seqFirstItem];
				currectAnswer[4] = seqColors[seqFirstItem];
				GameObject.Find("fruit6").GetComponent<SpriteRenderer>().sprite = seqSprites[seqFirstItem];
				currectAnswer[5] = seqColors[seqFirstItem];
				GameObject.Find("fruit7").GetComponent<SpriteRenderer>().sprite = seqSprites[seqSecondItem];
				currectAnswer[6] = seqColors[seqSecondItem];
				GameObject.Find("fruit8").GetComponent<SpriteRenderer>().sprite = seqSprites[seqSecondItem];
				currectAnswer[7] = seqColors[seqSecondItem];
				break;
			
			case 3:
				tempString = "Type3";
				GameObject.Find("fruit1").GetComponent<SpriteRenderer>().sprite = seqSprites[seqFirstItem];
				currectAnswer[0] = seqColors[seqFirstItem];
				GameObject.Find("fruit2").GetComponent<SpriteRenderer>().sprite = seqSprites[seqSecondItem];
				currectAnswer[1] = seqColors[seqSecondItem];
				GameObject.Find("fruit3").GetComponent<SpriteRenderer>().sprite = seqSprites[seqSecondItem];
				currectAnswer[2] = seqColors[seqSecondItem];
				GameObject.Find("fruit4").GetComponent<SpriteRenderer>().sprite = seqSprites[seqFirstItem];
				currectAnswer[3] = seqColors[seqFirstItem];
				GameObject.Find("fruit5").GetComponent<SpriteRenderer>().sprite = seqSprites[seqSecondItem];
				currectAnswer[4] = seqColors[seqSecondItem];
				GameObject.Find("fruit6").GetComponent<SpriteRenderer>().sprite = seqSprites[seqSecondItem];
				currectAnswer[5] = seqColors[seqSecondItem];
				GameObject.Find("fruit7").GetComponent<SpriteRenderer>().sprite = seqSprites[seqFirstItem];
				currectAnswer[6] = seqColors[seqFirstItem];
				GameObject.Find("fruit8").GetComponent<SpriteRenderer>().sprite = seqSprites[seqSecondItem];
				currectAnswer[7] = seqColors[seqSecondItem];
				break;
			
		}

		StringManager.Level3Exercise1_SEQUENCE = tempString + seqColorNames[seqFirstItem] + seqColorNames[seqSecondItem];
		Debug.Log(StringManager.Level3Exercise1_SEQUENCE);
		
		seqColorsState[0] = currectAnswer[0];
		tileColrs[0].GetComponent<SpriteRenderer>().color=currectAnswer[0];
		seqColorsState[1] = currectAnswer[1];
		tileColrs[1].GetComponent<SpriteRenderer>().color=currectAnswer[1];
		seqColorsState[2] = currectAnswer[2];
		tileColrs[2].GetComponent<SpriteRenderer>().color=currectAnswer[2];
		seqColorsState[3] = currectAnswer[3];
		tileColrs[3].GetComponent<SpriteRenderer>().color=currectAnswer[3];

	}
}
