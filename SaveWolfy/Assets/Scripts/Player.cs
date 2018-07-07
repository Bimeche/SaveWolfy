using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	Camera cam;
	Rigidbody2D rb;
	public GameObject footTrailPrefab;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		Vector2 newPosition = cam.ScreenToWorldPoint (Input.mousePosition);
		rb.position = newPosition;
		Instantiate (footTrailPrefab, transform);
	}
}

