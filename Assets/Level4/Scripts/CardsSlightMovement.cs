using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsSlightMovement : MonoBehaviour
{
	private Vector3 startPosition;
	[SerializeField] private float deltaMovement = 0.5f;
	[SerializeField] private float movementSpeed = 0.1f;

	private void Awake()
	{
		startPosition = transform.position;
	}

	private void Start()
	{
		StartCoroutine(ContinueingAnimation(0f));
	}

	IEnumerator ContinueingAnimation(float delay)
	{
		yield return new WaitForSeconds(delay);
		
		while (true)
		{
			Vector3 tempTarget = new Vector3(
				Random.Range(
					startPosition.x - deltaMovement,
					startPosition.x + deltaMovement
					),
				Random.Range(
					startPosition.y - deltaMovement,
					startPosition.y + deltaMovement
				),
				0f);

			Coroutine randomCoroutine =
				StartCoroutine(RandomMovement(transform.position, tempTarget, 10, movementSpeed));

			yield return randomCoroutine;
		}
	}
	
	IEnumerator RandomMovement(Vector3 from, Vector3 to, int frames, float speed)
	{
		for (int i = 0; i < frames; i++)
		{
			transform.position = Vector3.Lerp(
				from,
				to,
				((float)i / frames) * speed);
			yield return new WaitForEndOfFrame();
		}
	}
}
