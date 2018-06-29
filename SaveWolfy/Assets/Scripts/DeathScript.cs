using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class DeathScript : MonoBehaviour {

	public GameManager gMan;

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

				gMan.DestroyCow(collision.gameObject, collision.gameObject.GetComponent<CowScript>().strikeMeter);
					}
		}
		else if (collision.gameObject.tag == "Wolf")
		{
			if (collision.gameObject.GetComponent<Wolfy>().isWolfVisible)
				gMan.EndGame(collision.gameObject);
		}
	}
}
