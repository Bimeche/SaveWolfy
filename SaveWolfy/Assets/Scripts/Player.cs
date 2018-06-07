using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	Camera cam;
	bool isKicking = false;
	Rigidbody2D rb;
	CircleCollider2D circleCollider;
	public GameObject footTrailPrefab;
	private GameObject currentFootTrail;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		rb = GetComponent<Rigidbody2D> ();
		circleCollider = GetComponent<CircleCollider2D> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			StartKicking ();
		} else if (Input.GetMouseButtonUp (0)) {
			StopKicking ();
		}

		if (isKicking) {
			UpdateKick ();
		}

		//////////////
		/*Touch[] touches = Input.touches;
		if(touches.Length > 0){
			Vector3 pos = new Vector3(touches[0].position.x, touches[0].position.y, touches[0].position.z);
			paddle.transform.position = pos;*/
		/////////////

		/*Vector3 pos = Input.mousePosition;
		pos.z = transform.position.z - Camera.main.transform.position.z;
		Move(pos);*/
	}

	void UpdateKick(){
		Vector2 newPosition = cam.ScreenToWorldPoint (Input.mousePosition);
		rb.position = newPosition;
		}
	
	void StartKicking (){
		isKicking = true;
		currentFootTrail = Instantiate (footTrailPrefab, transform);
		//previousPosition = cam.ScreenToWorldPoint (Input.mousePosition);
		circleCollider.enabled = true;
	}

	void StopKicking(){
		isKicking = false;
		currentFootTrail.transform.SetParent (null);
		Destroy (currentFootTrail, 2f);
		circleCollider.enabled = false;
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

