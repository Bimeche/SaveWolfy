using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreManager : MonoBehaviour {

	public void BuyAdsRemove(){
		PlayerPrefs.SetInt ("AdsRemoved", 1);
		SceneManager.LoadScene("MainMenu");
	}
}
