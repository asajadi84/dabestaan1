using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltAnimation : MonoBehaviour
{
	[SerializeField] private float speed = 7.0f;
	private SpriteRenderer thisSprite;

	void Awake ()
	{
		thisSprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Color tempColor = thisSprite.color;
		tempColor.a = Mathf.Cos(Time.time * speed);
		thisSprite.color = tempColor;
	}
}
