﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate2D : MonoBehaviour
{

	[SerializeField] private float rotationSpeed;

	// Update is called once per frame
	void Update ()
	{
		transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
	}
}
