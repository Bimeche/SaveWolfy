using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowScript : AIManager {
	[HideInInspector] public bool isCowVisible;
	public int strikeMeter = 0;
	public bool comboTouch = false;
	private Animator anim;
	public Transform fxDeath;
	public Transform fxHit;
	public Transform fxTrail;
	public Transform fxstrikeMeter1;
	public Transform fxstrikeMeter2;
	public Transform fxstrikeMeter3;
	public Transform fxstrikeMeter4;
	public Transform fxstrikeMeter5;
	bool panic = false;

	// Use this for initialization
	void Start () {
		isCowVisible = false;
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		StrikedState (strikeMeter);
		anim.SetBool ("Striked", false);
		anim.SetFloat ("Altitude", transform.position.y);
		if (rb.velocity.magnitude > maxMagnitude)
		{
			rb.velocity = rb.velocity / (rb.velocity.magnitude / maxMagnitude);
		}
	}

	private void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Player") {
			anim.SetBool ("Striked", true);
			if (collision.contacts.Length > 0) {
				strikeMeter++;
				Vector2 impactPoint = new Vector2 (collision.contacts [0].point.x - transform.position.x, collision.contacts [0].point.y - transform.position.y);
				Vector2 impactSpeed = new Vector2 (collision.contacts [0].relativeVelocity.x - rb.velocity.x, collision.contacts [0].relativeVelocity.y - rb.velocity.y);

				impactPoint = -impactPoint.normalized;

				if (fxHit) {
					Destroy (Instantiate (fxHit, collision.contacts [0].point, Quaternion.Euler (new Vector3 (0, 0, -1))).gameObject, 0.5f);
				}

				float magnitude = Mathf.Sqrt (impactSpeed.magnitude) * playerForce;
				if (magnitude < minMagnitude)
					magnitude = minMagnitude;

				rb.AddForce (impactPoint * magnitude);
			}
		} else if (collision.gameObject.tag == "Cow") {
			if (collision.contacts.Length > 0) {
				strikeMeter++;
				Vector2 impactPoint = new Vector2 (collision.contacts [0].point.x - transform.position.x, collision.contacts [0].point.y - transform.position.y);

				impactPoint = -impactPoint.normalized;

				rb.AddForce (impactPoint * cowForce);
			}
		} 
		else {
		}
	}

	private void StrikedState(int striked){
		switch (striked) {
		case 0:
			GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f);
			break;
		case 1:
			GetComponent<SpriteRenderer> ().color = new Color (1f, 0.9f, 0.9f);
			break;
		case 2:
			GetComponent<SpriteRenderer> ().color = new Color (1f, 0.8f, 0.8f);
			break;
		case 3:
			GetComponent<SpriteRenderer> ().color = new Color (1f, 0.7f, 0.7f);
			break;
		case 4:
			GetComponent<SpriteRenderer> ().color = new Color (1f, 0.6f, 0.6f);
			break;
		case 5:
			GetComponent<SpriteRenderer> ().color = new Color (1f, 0.5f, 0.5f);
			break;
		case 6:
			GetComponent<SpriteRenderer> ().color = new Color (1f, 0.4f, 0.4f);
			break;
		case 7:
			GetComponent<SpriteRenderer> ().color = new Color (1f, 0.3f, 0.3f);
			break;
		case 8:
			GetComponent<SpriteRenderer> ().color = new Color (1f, 0.2f, 0.2f);
			break;
		case 9:
			GetComponent<SpriteRenderer> ().color = new Color (1f, 0.1f, 0.1f);
			break;
		case 10:
			GetComponent<SpriteRenderer> ().color = new Color (1f, 0f, 0f);
			break;
		}
	}

	private void OnBecameVisible () {
		isCowVisible = true;
	}

	public void OnDestroy(){
		Destroy (Instantiate (fxDeath, transform.position, Quaternion.identity).gameObject, 1f);
	}
}
