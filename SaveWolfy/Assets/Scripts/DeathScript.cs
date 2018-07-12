using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class DeathScript : MonoBehaviour {

	public GameManager gMan;
	public GameObject FloatingTextPrefab;
	ObjectPooler objectPooler;
	public Transform fxDeath;

	public void Start () {
		objectPooler = ObjectPooler.Instance;
	}

	private void OnTriggerEnter2D (Collider2D collision) {
		if (collision.gameObject.tag == "Cow")
		{
			if (collision.gameObject.GetComponent<CowScript> ().isCowVisible){
				if (collision.gameObject.GetComponent<CowScript> ().strikeMeter < 6) {
					//ShakeOnce("puissance", "fréquence", "fade in", "fade out")
					CameraShaker.Instance.ShakeOnce (collision.gameObject.GetComponent<CowScript> ().strikeMeter+0.5f, 10f, 0.1f, (((collision.gameObject.GetComponent<CowScript> ().strikeMeter)/5f)+0.1f));
				} 
				else {
					CameraShaker.Instance.ShakeOnce (5f, 10f, 0.1f, 1.2f);
				}

				if (FloatingTextPrefab) {
					ShowTextPrefab (collision);
				}

				gMan.DestroyCow(collision.gameObject, collision.gameObject.GetComponent<CowScript>().strikeMeter);
				collision.gameObject.GetComponent<CowScript> ().OnDespawn();
				GameData.CowDeaths++;
			}
		}
		else if (collision.gameObject.tag == "Wolf")
		{
			if (collision.gameObject.GetComponent<Wolfy>().isWolfVisible)
				gMan.EndGame(collision.gameObject);
		}
	}

	void ShowTextPrefab(Collider2D collision){
		int strikeMeter = collision.gameObject.GetComponent<CowScript> ().strikeMeter;
		Vector3 v3Screen = Camera.main.WorldToViewportPoint(collision.gameObject.GetComponent<SpriteRenderer> ().transform.position);
		v3Screen.x = Mathf.Clamp (v3Screen.x, -0.01f, 1.01f);
		v3Screen.y = Mathf.Clamp (v3Screen.y, -0.01f, 1.01f);
		Vector3 fxPosition = Camera.main.ViewportToWorldPoint (v3Screen);

		//ça marche mais je sais pas si c'est trés opti...
		if (strikeMeter < 5) {
			fxDeath.transform.localScale = new Vector3 (strikeMeter + 1.0f, strikeMeter + 1.0f, strikeMeter + 1.0f);
		} 
		else {
			fxDeath.transform.localScale = new Vector3 (6.0f, 6.0f, 6.0f);
		}
			
		var deathGO = objectPooler.SpawnFromPool ("CowDeath", fxPosition, Quaternion.identity);
		//ça marche mais je sais pas si c'est trés opti...
		if (strikeMeter < 5) {
			deathGO.transform.localScale = new Vector3 (strikeMeter + 1.0f, strikeMeter + 1.0f, strikeMeter + 1.0f);
		} 
		else {
			deathGO.transform.localScale = new Vector3 (6.0f, 6.0f, 6.0f);
		}

		Vector3 popPosition = fxPosition * 0.5f;
		int displayedText = collision.gameObject.GetComponent<CowScript> ().strikeMeter + 1;
		var textGO = objectPooler.SpawnFromPool ("FloatingText", popPosition, Quaternion.identity);
		//var go = Instantiate (FloatingTextPrefab, popPosition, Quaternion.identity, transform);
		textGO.GetComponent<TextMesh> ().characterSize = displayedText * 0.1f;
		textGO.GetComponent<TextMesh> ().color = new Color (1f, 1f - displayedText* 0.2f, 0f);
		textGO.GetComponent<TextMesh> ().text = "+" + displayedText.ToString ();
		StartCoroutine (Despawn (textGO, deathGO));

	}

	IEnumerator Despawn(GameObject textGO, GameObject deathGO){
		yield return new WaitForSeconds (1.0f);
		objectPooler.DespawnToPool (textGO);
		objectPooler.DespawnToPool (deathGO);
	}
}
