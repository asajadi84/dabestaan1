using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExerciseRestart : MonoBehaviour
{
	public bool notThisScene;
	public string sceneName;
	
	private void OnMouseUp()
	{
		if (notThisScene)
		{
			SceneManager.LoadScene(sceneName);
		}
		else
		{
			//Debug.Log("Game reset");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
