using System.Collections;
using UnityEngine;
using GooglePlayGames;

public class SuccessManager : MonoBehaviour {

	public GameObject successFx;
	public GameObject fireImage;
	public GameObject iceImage;
	public GameObject desertImage;
	public GameObject greenImage;
	public GameObject purpleImage;
	public GameObject yellowImage;
	public GameObject redImage;
	public AudioClip successSound;
	private static SuccessManager instance;

	public static SuccessManager Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType<SuccessManager> ();
			}
			return instance;
		}
	}


	void Start(){
		successFx.SetActive(false);
		successFx.GetComponent<ParticleSystem> ().Play();
	}

	public void UnlockSkin(string name){
		PlayerPrefs.SetInt (name, 1);
		successFx.SetActive (true);
		successFx.SetActive (true);
		SoundManager.instance.RandomizeSfx3 (successSound, successSound);
		switch (name) {
		case "Fire":
            Social.ReportProgress(SWGameServices.achievement_apocalypse_cow, 100.0f, (bool success) =>
            {
            });
			fireImage.SetActive (true);
			StartCoroutine (Despawn (fireImage));
			break;
		case "Ice":
            Social.ReportProgress(SWGameServices.achievement_white_fang, 100.0f, (bool success) =>
            {
            });
            iceImage.SetActive (true);
			StartCoroutine (Despawn (iceImage));
			break;
		case "Desert":
            Social.ReportProgress(SWGameServices.achievement_red_cows_redemption, 100.0f, (bool success) =>
            {
                });
            desertImage.SetActive (true);
			StartCoroutine (Despawn (desertImage));
			break;
		case "Green":
            Social.ReportProgress(SWGameServices.achievement_release_the_cows, 100.0f, (bool success) =>
            {
            });
            greenImage.SetActive (true);
			StartCoroutine (Despawn (greenImage));
			break;
		case "Purple":
            Social.ReportProgress(SWGameServices.achievement_purple_rain, 100.0f, (bool success) =>
            {
            });
            purpleImage.SetActive (true);
			StartCoroutine (Despawn (purpleImage));
			break;
		case "Yellow":
            Social.ReportProgress(SWGameServices.achievement_why_cant_i_hold_all_these_cows, 100.0f, (bool success) =>
            {
            });
            yellowImage.SetActive (true);
			StartCoroutine (Despawn (yellowImage));
			break;
		case "Red":
            Social.ReportProgress(SWGameServices.achievement_its_a_bomb_a_bomb, 100.0f, (bool success) =>
            {
            });
            redImage.SetActive (true);
			StartCoroutine (Despawn (redImage));
			break;
		default:
			break;
		}
	}

	IEnumerator Despawn(GameObject image){
		yield return new WaitForSeconds (3.0f);
		Destroy (image);
		successFx.GetComponent<ParticleSystem>().Clear ();
		successFx.SetActive (false);
	}
}

