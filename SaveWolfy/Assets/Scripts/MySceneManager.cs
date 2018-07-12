using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour {

	public void ChangeScene (string sceneName) {
		SceneManager.LoadScene(sceneName);
		int count = SceneManager.sceneCount;
		Scene scene;
		for (int i = 0; i < count; i++)
		{
			scene = SceneManager.GetSceneAt(i);
			print(scene.name);
			if (scene.name != sceneName)
			{
				SceneManager.UnloadSceneAsync(scene);
			}
		}
	}

	public static void LoadScene (string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	public void LeaveGame () {
		Application.Quit();
	}
}