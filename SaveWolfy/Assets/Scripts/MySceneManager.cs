﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour {

	private void Start () {
		Cursor.visible = true;
	}

	public void ChangeScene (string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	public void LeaveGame () {
		Application.Quit();
	}
}
