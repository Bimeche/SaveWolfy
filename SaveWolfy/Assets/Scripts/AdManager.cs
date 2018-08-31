﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
			if (Advertisement.IsReady ("rewardedVideo")) {
				Advertisement.Show ("rewardedVideo");
			}
		}
	}
}
