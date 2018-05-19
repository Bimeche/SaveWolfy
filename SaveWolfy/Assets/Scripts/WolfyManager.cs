using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfyManager : AIManager {

	float lastVertical;
	float lastHorizontal;
	Rigidbody2D myRB;
	bool bumpPossible;

	//Cooldown du Dash
	float dashRate = 0.2f;
	private float nextDash;

	// Use this for initialization
	void Start () {
		myRB = this.GetComponent<Rigidbody2D> ();
		bumpPossible = true;
	}
	
	// Update is called once per frame
	void Update () {

		//Impulse joystick de gauche------------------------------------------------------------------------------------------------
		if (bumpPossible && ((Input.GetAxis ("Vertical") > 0.3 || Input.GetAxis ("Vertical") < -0.3) || (Input.GetAxis ("Horizontal") > 0.3 || Input.GetAxis ("Horizontal") < -0.3 ))) {

			//Si on veut reset la vélocité avant bump (s'apparente à un Dash):
			myRB.velocity = new Vector2 (0, 0);
			//A mettre en commentaire si on veux garder les effets de la cinétique

			//Si on veut utiliser le delta du stick:
			/*myRB.AddForce (Vector2.up * (Input.GetAxis ("Vertical") - lastVertical) * 1000);
			myRB.AddForce (Vector2.right * (Input.GetAxis ("Horizontal") - lastHorizontal) * 1000);*/

			//Si on veut utiliser la valeur instantanée du stick
			myRB.AddForce (Vector2.up * (Input.GetAxis ("Vertical") * 2000));
			myRB.AddForce (Vector2.right * (Input.GetAxis ("Horizontal") * 2000));

			bumpPossible = false;
		}

		if ((Input.GetAxis ("Horizontal") < 0.3 && Input.GetAxis ("Horizontal") > -0.3 ) && (Input.GetAxis ("Vertical") < 0.3 && Input.GetAxis ("Vertical") > -0.3)){
			bumpPossible = true;
		}

		//lastVertical = Input.GetAxis ("Vertical");
		//lastHorizontal = Input.GetAxis ("Horizontal");

		if (Input.GetButtonUp("Dash") && Time.time > nextDash) {
			nextDash = Time.time + dashRate;
			Debug.Log ("Test");
			myRB.AddForce (Vector2.up * (Input.GetAxis ("Vertical") * 3000));
			myRB.AddForce (Vector2.right * (Input.GetAxis ("Horizontal") * 3000));
		}
	}
		
}
