using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class MySceneManager : MonoBehaviour {

	public AudioClip gameStart;

	public void LoadScene (string sceneName) {
		if (string.Equals(sceneName, "SaveWolfy")) {
			if (PlayerPrefs.GetInt ("AdCount") >= 125) {
				ShowAd ();
			}
			else {
				SceneManager.LoadScene("SaveWolfy");
				PlayerPrefs.SetInt ("AdCount", PlayerPrefs.GetInt ("AdCount") + 35);
			}
		}
		else {
			SceneManager.LoadScene(sceneName);
			PlayerPrefs.SetInt ("AdCount", PlayerPrefs.GetInt ("AdCount") + 35);
		}
	}

	public void LoadIntro () {
		if (PlayerPrefs.GetInt ("Intro") == 0) {
			SceneManager.LoadScene ("Intro");
			PlayerPrefs.SetInt ("Intro", 1);
		} else {
			if (PlayerPrefs.GetInt ("AdCount") >= 125) {
				ShowAd ();
			}
			else {
				SceneManager.LoadScene("SaveWolfy");
			}
		}
	}

	public void LeaveGame () {
		SoundManager.instance.RandomizeSfx (gameStart, gameStart);
		Application.Quit();
	}

	public void ShowAd(){
		if (Advertisement.IsReady ("video") && PlayerPrefs.GetInt ("AdsRemoved") == 0) {
			Advertisement.Show ("video", new ShowOptions (){ resultCallback = HandleAdResult });
			PlayerPrefs.SetInt ("AdCount", 0);
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