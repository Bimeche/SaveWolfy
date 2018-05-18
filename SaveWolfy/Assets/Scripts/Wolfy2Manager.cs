using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolfy2Manager : AIManager {

	float lastVertical;
	float lastHorizontal;
	Rigidbody2D myRB;
	bool bumpPossible;

	// Use this for initialization
	void Start () {
		myRB = this.GetComponent<Rigidbody2D> ();
		bumpPossible = true;
	}

	// Update is called once per frame
	void Update () {

		//Impulse joystick de gauche------------------------------------------------------------------------------------------------
		if (bumpPossible && ((Input.GetAxis ("Vertical2") > 0.3 || Input.GetAxis ("Vertical2") < -0.3) || (Input.GetAxis ("Horizontal2") > 0.3 || Input.GetAxis ("Horizontal2") < -0.3 ))) {

			//Si on veut reset la vélocité avant bump (s'apparente à un Dash):
			myRB.velocity = new Vector2 (0, 0);
			//A mettre en commentaire si on veux garder les effets de la cinétique

			//Si on veut utiliser le delta du stick:
			myRB.AddForce (Vector2.up * (Input.GetAxis ("Vertical2") - lastVertical) * 1000);
			myRB.AddForce (Vector2.right * (Input.GetAxis ("Horizontal2") - lastHorizontal) * 1000);

			//Si on veut utiliser la valeur instantanée du stick
			/*myRB.AddForce (Vector2.up * (Input.GetAxis ("Vertical") * 1000));
				myRB.AddForce (Vector2.right * (Input.GetAxis ("Horizontal") * 1000));*/

			bumpPossible = false;
		}

		if ((Input.GetAxis ("Horizontal2") < 0.3 && Input.GetAxis ("Horizontal2") > -0.3 ) && (Input.GetAxis ("Vertical2") < 0.3 && Input.GetAxis ("Vertical2") > -0.3)){
			bumpPossible = true;
		}

		lastVertical = Input.GetAxis ("Vertical2");
		lastHorizontal = Input.GetAxis ("Horizontal2");
	}

}
