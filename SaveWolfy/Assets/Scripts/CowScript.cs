using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowScript : AIManager {
	[HideInInspector] public bool isCowVisible;
	public int strikeMeter = 0;
	public bool comboTouch = false;
	private Animator anim;
	public AudioClip cowHit1;
	public AudioClip cowHit2;
	public AudioClip cowHit3;
	public AudioClip Idle;
	public AudioClip cowPanic1;
	public AudioClip cowPanic2;
	public AudioClip cowPanic3;
	public AudioClip cowBounce1;
	public AudioClip cowBounce2;
	public AudioClip cowBounce3;
	public AudioClip AttackHit1;
	public AudioClip AttackHit2;
	public AudioClip AttackHit3;
	public AudioClip AttackHit4;
	public AudioClip AttackHit5;
	public AudioClip AttackHit6;
	public AudioClip cowDeath1;
	public AudioClip cowDeath2;
	public AudioClip cowDeath3;
	public AudioClip cowDeath4;
	public AudioClip cowDeath5;
	public Transform fxDeath;
	public Transform fxHit;
	bool panic = false;
	private Vector3 fxPosition;

	public GameObject CowFireFx;

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
		if (transform.position.y >= -1 && panic==false) {
			panic = true;
			SoundManager.instance.RandomizeSfx (cowPanic1, cowPanic2, cowPanic3);
		}
		if (transform.position.y < -1) {
			panic = false;
		}
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
					SoundManager.instance.RandomizeSfx (cowHit1, cowHit2, cowHit3, AttackHit1, AttackHit2, AttackHit3, AttackHit4, AttackHit5, AttackHit6);
				}

				float magnitude = Mathf.Sqrt (impactSpeed.magnitude) * playerForce;
				if (magnitude < minMagnitude)
					magnitude = minMagnitude;

				rb.AddForce (impactPoint * magnitude);
			}
		} else if (collision.gameObject.tag == "Cow") {
			SoundManager.instance.RandomizeSfx (cowBounce1, cowBounce2, cowBounce3);
			if (collision.contacts.Length > 0) {
				strikeMeter++;
				Vector2 impactPoint = new Vector2 (collision.contacts [0].point.x - transform.position.x, collision.contacts [0].point.y - transform.position.y);

				impactPoint = -impactPoint.normalized;

				rb.AddForce (impactPoint * cowForce);
			}
		} 
		else {
			SoundManager.instance.RandomizeSfx (cowBounce1, cowBounce2, cowBounce3);
		}
	}

	private void StrikedState(int striked){
		switch (striked) {
		case 0:
			GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f);
			CowFireFx.transform.localScale = new Vector2(0f,0f);
			break;
		case 1:
			GetComponent<SpriteRenderer> ().color = new Color (1f, 0.9f, 0.9f);
			CowFireFx.transform.localScale = new Vector2(0.5f,0.5f);
			break;
		case 2:
			GetComponent<SpriteRenderer> ().color = new Color (1f, 0.8f, 0.8f);
			CowFireFx.transform.localScale = new Vector2(1f,1f);
			break;
		case 3:
			GetComponent<SpriteRenderer> ().color = new Color (1f, 0.7f, 0.7f);
			CowFireFx.transform.localScale = new Vector2(1.5f,1.5f);
			break;
		case 4:
			GetComponent<SpriteRenderer> ().color = new Color (1f, 0.6f, 0.6f);
			CowFireFx.transform.localScale = new Vector2(2f,2f);
			break;
		case 5:
			GetComponent<SpriteRenderer> ().color = new Color (1f, 0.5f, 0.5f);
			CowFireFx.transform.localScale = new Vector2(2.5f,2.5f);
			break;
		case 6:
			GetComponent<SpriteRenderer> ().color = new Color (1f, 0.4f, 0.4f);
			CowFireFx.transform.localScale = new Vector2(3f,3f);
			break;
		case 7:
			GetComponent<SpriteRenderer> ().color = new Color (1f, 0.3f, 0.3f);
			CowFireFx.transform.localScale = new Vector2(3.5f,3.5f);
			break;
		case 8:
			GetComponent<SpriteRenderer> ().color = new Color (1f, 0.2f, 0.2f);
			CowFireFx.transform.localScale = new Vector2(4f,4f);
			break;
		case 9:
			GetComponent<SpriteRenderer> ().color = new Color (1f, 0.1f, 0.1f);
			CowFireFx.transform.localScale = new Vector2(4.5f,4.5f);
			break;
		case 10:
			GetComponent<SpriteRenderer> ().color = new Color (1f, 0f, 0f);
			CowFireFx.transform.localScale = new Vector2(5f,5f);
			break;
		}
	}

	private void OnBecameVisible () {
		isCowVisible = true;
	}

	public void OnDestroy(){
		Vector3 v3Screen = Camera.main.WorldToViewportPoint(transform.position);
			v3Screen.x = Mathf.Clamp (v3Screen.x, -0.01f, 1.01f);
			v3Screen.y = Mathf.Clamp (v3Screen.y, -0.01f, 1.01f);
			fxPosition = Camera.main.ViewportToWorldPoint (v3Screen);

		SoundManager.instance.RandomizeSfx (cowDeath1, cowDeath2, cowDeath3, cowDeath4, cowDeath5);
		Destroy (Instantiate (fxDeath, fxPosition, Quaternion.identity).gameObject, 1f);
	}
}
