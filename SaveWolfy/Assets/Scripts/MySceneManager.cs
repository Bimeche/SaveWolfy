using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class MySceneManager : MonoBehaviour {

	public AudioClip gameStart;

	public void LoadScene (string sceneName) {
		if (string.Equals(sceneName, "SaveWolfy")) {
			ShowAd ();
		}
		else {
			SceneManager.LoadScene(sceneName);
		}
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

	public void ShowAd(){
		if (Advertisement.IsReady ("video")) {
			Advertisement.Show ("video", new ShowOptions (){ resultCallback = HandleAdResult });
		} else {
			SceneManager.LoadScene("SaveWolfy");
		}
	}

	private void HandleAdResult(ShowResult result){
		switch (result) {
		case ShowResult.Finished:
			SceneManager.LoadScene("SaveWolfy");
			break;

		case ShowResult.Skipped:
			SceneManager.LoadScene("SaveWolfy");
			break;

		case ShowResult.Failed:
			SceneManager.LoadScene("SaveWolfy");
			break;
		}
	}
}