using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapePressed : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			//SceneManager.LoadScene(0);
			Application.Quit();
		}
	}
}
