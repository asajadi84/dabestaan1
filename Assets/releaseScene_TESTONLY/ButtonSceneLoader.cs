using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneLoader : MonoBehaviour
{

	public int sceneID;

	private void OnMouseUp()
	{
		SceneManager.LoadScene(sceneID);
	}
}
