using System.Collections;
using UnityEngine;

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
			fireImage.SetActive (true);
			StartCoroutine (Despawn (fireImage));
			break;
		case "Ice":
			iceImage.SetActive (true);
			StartCoroutine (Despawn (iceImage));
			break;
		case "Desert":
			desertImage.SetActive (true);
			StartCoroutine (Despawn (desertImage));
			break;
		case "Green":
			greenImage.SetActive (true);
			StartCoroutine (Despawn (greenImage));
			break;
		case "Purple":
			purpleImage.SetActive (true);
			StartCoroutine (Despawn (purpleImage));
			break;
		case "Yellow":
			yellowImage.SetActive (true);
			StartCoroutine (Despawn (yellowImage));
			break;
		case "Red":
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

