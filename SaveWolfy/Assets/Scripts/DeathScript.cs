﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour {

	public GameManager gMan;

	private void OnTriggerEnter2D (Collider2D collision) {
		if (collision.gameObject.tag == "Cow")
		{
			if(collision.gameObject.GetComponent<CowScript>().isCowVisible)
				gMan.DestroyCow(collision.gameObject);
		}
		else if (collision.gameObject.tag == "Wolf")
		{
			if (collision.gameObject.GetComponent<Wolfy>().isWolfVisible)
				gMan.EndGame(collision.gameObject);
		}
	}
}
