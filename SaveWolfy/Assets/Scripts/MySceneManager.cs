using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MySceneManager : MonoBehaviour {

	public AudioClip gameStart;

	public void LoadScene (string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	public void LeaveGame () {
		SoundManager.instance.RandomizeSfx (gameStart, gameStart);
		Application.Quit();
	}
}