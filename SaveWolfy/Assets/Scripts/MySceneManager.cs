using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MySceneManager : MonoBehaviour {

	public AudioClip gameStart;

	public void LoadScene (string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	public void LoadIntro () {
		if (PlayerPrefs.GetInt ("Intro") == 0) {
			SceneManager.LoadScene ("Intro");
			PlayerPrefs.SetInt ("Intro", 1);
		} else {
			SceneManager.LoadScene ("SaveWolfy");
		}
	}

	public void LeaveGame () {
		SoundManager.instance.RandomizeSfx (gameStart, gameStart);
		Application.Quit();
	}
}