using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour {
	protected Rigidbody2D rb;
	public float playerForce = 100;
	public float cowForce = 100;
	public float maxMagnitude = 30;
	public float minMagnitude = 50f;
	public int comboCount = 0;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

	public void SetCombo(){
		comboCount++;
		Debug.Log (comboCount);
	}

	public void ResetCombo(){
		Debug.Log ("reset combo");
		comboCount = 0;
	}
}
