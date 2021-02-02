using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerLevel4Exercise1 : MonoBehaviour
{
	[SerializeField] private Color[] cuteColors = new Color[2];

	[SerializeField] private GameObject[] topRowCards = new GameObject[5];
	[SerializeField] private GameObject[] bottomRowCards = new GameObject[5];
	
	[SerializeField] private GameObject[] topRowCardsDots = new GameObject[5];
	[SerializeField] private GameObject[] bottomRowCardsDots = new GameObject[5];
	
	[SerializeField] private Sprite[] topRowSprites = new Sprite[5];
	[SerializeField] private Sprite[] bottomRowSprites = new Sprite[5];
	
	int[] topRowRandom = new int[5];
	int[] bottomRowRandom = new int[5];

	private GameObject lineGO;

	private Vector3 startTouch;
	private Vector3 endTouch;
	
	private Vector2 startTouch2D;
	private Vector2 endTouch2D;

	private int rightAnswers = 0;

	[SerializeField] private GameObject winPrefab;
	[SerializeField] private AudioClip winMusic;
	[SerializeField] private AudioClip winClip;
	[SerializeField] private AudioClip errorClip;
	[SerializeField] private AudioClip narration;
	
	private void Awake()
	{
		StartCoroutine(PlayNarration(1.0f));
		
		topRowRandom[0] = Random.Range(0, 5);
		
		topRowRandom[1] = topRowRandom[0];
		while (topRowRandom[1] == topRowRandom[0])
		{
			topRowRandom[1] = Random.Range(0, 5);
		}
		
		topRowRandom[2] = topRowRandom[0];
		while (topRowRandom[2] == topRowRandom[0] || topRowRandom[2] == topRowRandom[1])
		{
			topRowRandom[2] = Random.Range(0, 5);
		}
		
		topRowRandom[3] = topRowRandom[0];
		while (topRowRandom[3] == topRowRandom[0] || topRowRandom[3] == topRowRandom[1] || topRowRandom[3] == topRowRandom[2])
		{
			topRowRandom[3] = Random.Range(0, 5);
		}
		
		topRowRandom[4] = topRowRandom[0];
		while (topRowRandom[4] == topRowRandom[0] || topRowRandom[4] == topRowRandom[1] || topRowRandom[4] == topRowRandom[2] || topRowRandom[4] == topRowRandom[3])
		{
			topRowRandom[4] = Random.Range(0, 5);
		}
		
		bottomRowRandom[0] = Random.Range(0, 5);
		
		bottomRowRandom[1] = bottomRowRandom[0];
		while (bottomRowRandom[1] == bottomRowRandom[0])
		{
			bottomRowRandom[1] = Random.Range(0, 5);
		}
		
		bottomRowRandom[2] = bottomRowRandom[0];
		while (bottomRowRandom[2] == bottomRowRandom[0] || bottomRowRandom[2] == bottomRowRandom[1])
		{
			bottomRowRandom[2] = Random.Range(0, 5);
		}
		
		bottomRowRandom[3] = bottomRowRandom[0];
		while (bottomRowRandom[3] == bottomRowRandom[0] || bottomRowRandom[3] == bottomRowRandom[1] || bottomRowRandom[3] == bottomRowRandom[2])
		{
			bottomRowRandom[3] = Random.Range(0, 5);
		}
		
		bottomRowRandom[4] = bottomRowRandom[0];
		while (bottomRowRandom[4] == bottomRowRandom[0] || bottomRowRandom[4] == bottomRowRandom[1] || bottomRowRandom[4] == bottomRowRandom[2] || bottomRowRandom[4] == bottomRowRandom[3])
		{
			bottomRowRandom[4] = Random.Range(0, 5);
		}

		StringManager.Level4Exercise2_TOPROWORDER =
			(topRowRandom[0]+1).ToString() + (topRowRandom[1]+1).ToString() + (topRowRandom[2]+1).ToString() +
			(topRowRandom[3]+1).ToString() + (topRowRandom[4]+1).ToString();
		
		StringManager.Level4Exercise2_BOTTOMROWORDER =
			(bottomRowRandom[0]+1).ToString() + (bottomRowRandom[1]+1).ToString() + (bottomRowRandom[2]+1).ToString() +
			(bottomRowRandom[3]+1).ToString() + (bottomRowRandom[4]+1).ToString();
		
		Debug.Log(StringManager.Level4Exercise2_TOPROWORDER);
		Debug.Log(StringManager.Level4Exercise2_BOTTOMROWORDER);

		for (int i = 0; i < 5; i++)
		{
			topRowCards[i].GetComponent<SpriteRenderer>().sprite = topRowSprites[topRowRandom[i]];
			topRowCards[i].GetComponent<CardIndexHandler>().cardValue = topRowRandom[i]+1;
			topRowCards[i].GetComponent<CardIndexHandler>().cardPosition = i;
			bottomRowCards[i].GetComponent<SpriteRenderer>().sprite = bottomRowSprites[bottomRowRandom[i]];
			bottomRowCards[i].GetComponent<CardIndexHandler>().cardValue = bottomRowRandom[i]+1;
			bottomRowCards[i].GetComponent<CardIndexHandler>().cardPosition = i;
		}
		
		lineGO = new GameObject("user touch");
		lineGO.AddComponent<LineRenderer>();
		LineRenderer lr = lineGO.GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Sprites/Default"));
		lr.sortingOrder = 12;
		lr.startColor = cuteColors[0];
		lr.endColor = cuteColors[1];
		lr.startWidth = 0.1f;
		lr.endWidth = 0.1f;
		lineGO.SetActive(false);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			lineGO.SetActive(true);
			startTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			startTouch.z = 10f;
		}
		
		if (Input.GetMouseButton(0))
		{
			endTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			endTouch.z = 10f;
			DrawLine(startTouch, endTouch);
		}

		if (Input.GetMouseButtonUp(0) && rightAnswers != 5)
		{
			lineGO.SetActive(false);

			startTouch2D = startTouch;
			endTouch2D = endTouch;

			RaycastHit2D startRaycastHit2D = Physics2D.Raycast(startTouch2D, Vector2.zero);
			RaycastHit2D endRaycastHit2D = Physics2D.Raycast(endTouch2D, Vector2.zero);

			if (startRaycastHit2D.collider != null && endRaycastHit2D.collider != null)
			{
				int startCardPosition =
					startRaycastHit2D.collider.gameObject.GetComponent<CardIndexHandler>().cardPosition;
				int startCardValue = startRaycastHit2D.collider.gameObject.GetComponent<CardIndexHandler>().cardValue;
				bool startCardTop = startRaycastHit2D.collider.gameObject.GetComponent<CardIndexHandler>().topRow;
				
				int endCardPosition =
					endRaycastHit2D.collider.gameObject.GetComponent<CardIndexHandler>().cardPosition;
				int endCardValue = endRaycastHit2D.collider.gameObject.GetComponent<CardIndexHandler>().cardValue;
				bool endCardTop = endRaycastHit2D.collider.gameObject.GetComponent<CardIndexHandler>().topRow;

				if (startCardTop != endCardTop)
				{
					if (startCardValue==endCardValue)
					{
						if (startCardTop)
						{
							Destroy(topRowCards[startCardPosition].GetComponent<BoxCollider2D>());
							Destroy(bottomRowCards[endCardPosition].GetComponent<BoxCollider2D>());
						}
						else
						{
							Destroy(bottomRowCards[startCardPosition].GetComponent<BoxCollider2D>());
							Destroy(topRowCards[endCardPosition].GetComponent<BoxCollider2D>());
						}

						rightAnswers++;
						GameObject line = new GameObject("currect line");
						line.tag = "removeAfterWin";
						line.AddComponent<LineRenderer>();
						LineRenderer lrt = line.GetComponent<LineRenderer>();
						lrt.material = new Material(Shader.Find("Sprites/Default"));
						lrt.sortingOrder = 9;
						lrt.startColor = Color.red;
						lrt.endColor = Color.blue;
						lrt.startWidth = 0.1f;
						lrt.endWidth = 0.1f;

						if (startCardTop)
						{
							lrt.SetPosition(0,
								new Vector3(
									topRowCardsDots[startCardPosition].transform.position.x,
									topRowCardsDots[startCardPosition].transform.position.y,
									10f));
					
							lrt.SetPosition(1,
								new Vector3(
									bottomRowCardsDots[endCardPosition].transform.position.x,
									bottomRowCardsDots[endCardPosition].transform.position.y,
									10f));
						}
						else
						{
							lrt.SetPosition(0,
								new Vector3(
									bottomRowCardsDots[startCardPosition].transform.position.x,
									bottomRowCardsDots[startCardPosition].transform.position.y,
									10f));
					
							lrt.SetPosition(1,
								new Vector3(
									topRowCardsDots[endCardPosition].transform.position.x,
									topRowCardsDots[endCardPosition].transform.position.y,
									10f));
						}
						
						if (rightAnswers == 5)
						{
							GameObject narrationRemain = GameObject.Find("One shot audio");
							if (narrationRemain != null)
							{
								Destroy(narrationRemain);
							}
							
							GameObject[] tempGOs = GameObject.FindGameObjectsWithTag("removeAfterWin");
							foreach (var tempGO in tempGOs)
							{
								Destroy(tempGO);
							}
							
							Instantiate(winPrefab);
							AudioSource.PlayClipAtPoint(winMusic, Camera.main.transform.position);
							AudioSource.PlayClipAtPoint(winClip, Camera.main.transform.position);
						}
					}
					else
					{
						AudioSource.PlayClipAtPoint(errorClip, Camera.main.transform.position);
					}

				}
				else
				{
					AudioSource.PlayClipAtPoint(errorClip, Camera.main.transform.position);
				}
			}
			else
			{
				AudioSource.PlayClipAtPoint(errorClip, Camera.main.transform.position);
			}

		}
		
	}

	IEnumerator PlayNarration(float delay)
	{
		yield return new WaitForSeconds(delay);
		AudioSource.PlayClipAtPoint(narration, Camera.main.transform.position);
	}


	void DrawLine(Vector3 start, Vector3 end)
	{
		lineGO.GetComponent<LineRenderer>().SetPosition(0, start);
		lineGO.GetComponent<LineRenderer>().SetPosition(1, end);
	}

}
