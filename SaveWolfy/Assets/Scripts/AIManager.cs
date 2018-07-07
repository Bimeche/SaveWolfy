using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour {
	protected Rigidbody2D rb;
	public float playerForce = 100;
	public float cowForce = 100;
	public float maxMagnitude = 30;
	public float minMagnitude = 50f;
	public GameManager gMan;
	protected Animator anim;
	protected bool panic = false;
}
