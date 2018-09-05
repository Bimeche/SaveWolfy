using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.SceneManagement;

public class StoreManager : MonoBehaviour {

	public void OnPurchaseCompleted(Product product){
		if (product != null) {
			PlayerPrefs.SetInt ("AdsRemoved", 1);
			SceneManager.LoadScene("MainMenu");
		}
	}
}
