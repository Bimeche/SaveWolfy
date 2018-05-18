using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfyManager2 : MonoBehaviour {

	float lastVertical;
	float lastHorizontal;
	float delta;
	Rigidbody2D myRB;

	// Use this for initialization
	void Start () {
		myRB = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		delta = DeltaStick (lastVertical, lastHorizontal, Input.GetAxis ("Vertical"), Input.GetAxis ("Horizontal"));

		if (delta > 0.1) {
			
			//Si on veut reset la vélocité avant bump (s'apparente à un Dash):
			myRB.velocity = new Vector2 (0, 0);
			//A mettre en commentaire si on veux garder les effets de la cinétique

			myRB.AddForce (Vector2.up * Input.GetAxis ("Vertical") * 1000);
			myRB.AddForce (Vector2.right * Input.GetAxis ("Horizontal") * 1000);
		}

		lastVertical = Input.GetAxis ("Vertical");
		lastHorizontal = Input.GetAxis ("Horizontal");
	}

	private float DeltaStick(float lastVertical, float lastHorizontal, float Vertical, float Horizontal){

		float deltaStick = Mathf.Abs(((Vector2.up * lastVertical + Vector2.right * lastHorizontal) - (Vector2.up * Vertical + Vector2.right * Horizontal)).sqrMagnitude);

		return deltaStick;
	}
}
