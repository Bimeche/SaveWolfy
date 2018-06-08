using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	Camera cam;
	Rigidbody2D rb;
	public GameObject footTrailPrefab;
	private GameObject currentFootTrail;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		Vector2 newPosition = cam.ScreenToWorldPoint (Input.mousePosition);
		rb.position = newPosition;
		currentFootTrail = Instantiate (footTrailPrefab, transform);

		/*Vector3 pos = Input.mousePosition;
		pos.z = transform.position.z - Camera.main.transform.position.z;
		Move(pos);*/
	}

	/*void Move (Vector3 position) {
		//Restricting position for the mouse
		if (position.x > Screen.width)
			position.x = Screen.width;
		else if (position.x < 0)
			position.x = 0;

		if (position.y > Screen.height)
			position.y = Screen.height;
		else if (position.y < 0)
			position.y = 0;

		transform.position = cam.ScreenToWorldPoint(position);
	}*/
}

