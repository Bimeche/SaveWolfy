using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class DeathScript : MonoBehaviour {

	public GameManager gMan;
	public GameObject FloatingTextPrefab;

	private void OnTriggerEnter2D (Collider2D collision) {
		if (collision.gameObject.tag == "Cow")
		{
			if (collision.gameObject.GetComponent<CowScript> ().isCowVisible){
				if (collision.gameObject.GetComponent<CowScript> ().strikeMeter < 6) {
					//ShakeOnce("puissance", "fréquence", "fade in", "fade out")
					CameraShaker.Instance.ShakeOnce (collision.gameObject.GetComponent<CowScript> ().strikeMeter+0.5f, 10f, 0.1f, (((collision.gameObject.GetComponent<CowScript> ().strikeMeter)/5f)+0.1f));
				} else {
					CameraShaker.Instance.ShakeOnce (5f, 10f, 0.1f, 1.2f);
				}
				if (FloatingTextPrefab) {
					ShowTextPrefab (collision);
				}

				gMan.DestroyCow(collision.gameObject, collision.gameObject.GetComponent<CowScript>().strikeMeter);
					}
		}
		else if (collision.gameObject.tag == "Wolf")
		{
			if (collision.gameObject.GetComponent<Wolfy>().isWolfVisible)
				gMan.EndGame(collision.gameObject);
		}
	}

	void ShowTextPrefab(Collider2D collision){
		Vector3 v3Screen = Camera.main.WorldToViewportPoint(collision.gameObject.GetComponent<SpriteRenderer> ().transform.position);
		v3Screen.x = Mathf.Clamp (v3Screen.x, -0.01f, 1.01f);
		v3Screen.y = Mathf.Clamp (v3Screen.y, -0.01f, 1.01f);
		Vector3 fxPosition = Camera.main.ViewportToWorldPoint (v3Screen);

		Vector3 popPosition = fxPosition * 0.5f;
		int displayedText = collision.gameObject.GetComponent<CowScript> ().strikeMeter + 1;
		var go = Instantiate (FloatingTextPrefab, popPosition, Quaternion.identity, transform);
		go.GetComponent<TextMesh> ().characterSize = displayedText * 0.1f;
		go.GetComponent<TextMesh> ().color = new Color (1f, 1f - displayedText* 0.2f, 0f);
		go.GetComponent<TextMesh> ().text = "+" + displayedText.ToString ();
	}
}
