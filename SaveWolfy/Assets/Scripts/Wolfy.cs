﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolfy : AIManager
{
	public GameObject player;
	[HideInInspector]
	public bool isWolfVisible;
	public float wolfForce;

	public AudioClip WolfHit1;
	public AudioClip WolfHit2;
	public AudioClip WolfHit3;
	public AudioClip WolfPanic1;
	public AudioClip WolfPanic2;
	public AudioClip WolfPanic3;
	public AudioClip AttackHit1;
	public AudioClip AttackHit2;
	public AudioClip AttackHit3;
	public AudioClip AttackHit4;
	public AudioClip AttackHit5;
	public AudioClip AttackHit6;
	public AudioClip WolfDeath;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}



	// Update is called once per frame
	void FixedUpdate () {
		anim.SetBool ("Striked", false);
		anim.SetFloat ("Altitude", transform.position.y);
		if (transform.position.y >= -2 && panic == false)
		{
			panic = true;
			SoundManager.instance.RandomizeSfx (WolfPanic1, WolfPanic2, WolfPanic3);
		}
		if (transform.position.y < -2)
		{
			panic = false;
		}

		if (rb.velocity.magnitude > maxMagnitude)
		{
			rb.velocity = rb.velocity / (rb.velocity.magnitude / maxMagnitude);
		}
	}

	private void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Player")
		{
			SoundManager.instance.RandomizeSfx (WolfHit1, WolfHit2, WolfHit3, WolfHit1, WolfHit2, WolfHit3, AttackHit1, AttackHit2, AttackHit3, AttackHit4, AttackHit5, AttackHit6);
			Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>(), true);
			Invoke("EnableCollisions", 0.2f);
			anim.SetBool("Striked", true);
			if (collision.contacts.Length > 0)
			{
				Vector2 impactPoint = new Vector2(collision.contacts[0].point.x - transform.position.x, collision.contacts[0].point.y - transform.position.y);
				Vector2 impactSpeed = new Vector2(collision.contacts[0].relativeVelocity.x - rb.velocity.x, collision.contacts[0].relativeVelocity.y - rb.velocity.y);

				impactPoint = -impactPoint.normalized;
				float magnitude = Mathf.Sqrt(impactSpeed.magnitude) * playerForce;
				if (magnitude < minMagnitude)
					magnitude = minMagnitude;
				rb.AddForce(impactPoint * magnitude);
			}
		}
		else if (collision.gameObject.tag == "Cow")
		{
			SoundManager.instance.RandomizeSfx (WolfHit1, WolfHit2, WolfHit3, WolfHit1, WolfHit2, WolfHit3, AttackHit1, AttackHit2, AttackHit3, AttackHit4, AttackHit5, AttackHit6);
			anim.SetBool("Striked", true);
			if (collision.contacts.Length > 0)
			{

				Vector2 impactPoint = new Vector2(collision.contacts[0].point.x - transform.position.x, collision.contacts[0].point.y - transform.position.y);

				impactPoint = -impactPoint.normalized;

				rb.AddForce(impactPoint * wolfForce);
				collision.gameObject.GetComponent<Rigidbody2D>().AddForce(impactPoint * cowForce);
			}
		}
	}

	void EnableCollisions () {
		Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>(), false);
	}

	private void OnBecameVisible () {
		isWolfVisible = true;
	}

	void OnDestroy(){
		SoundManager.instance.RandomizeSfx (WolfDeath, WolfDeath);
	}
}
