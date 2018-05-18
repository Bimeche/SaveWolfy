using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour {

	public GameManager gMan;

	private void OnTriggerEnter2D (Collider2D collision) {
		if (collision.gameObject.tag == "Cow")
		{
			Debug.Log ("Yoho");
			if(collision.gameObject.GetComponent<CowScript>().isCowVisible)
				gMan.DestroyCow(collision.gameObject);
		}
	}
}
