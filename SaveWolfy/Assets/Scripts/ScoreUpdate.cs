using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdate : MonoBehaviour {

	private Animator anim;

	void Start(){
		anim = GetComponent<Animator>();
	}

	public void Initialize(int score){
		GetComponent<TextMesh>().text = score.ToString();
	}

	public void UpdateScore(int score){
		GetComponent<TextMesh>().text = score.ToString();
		GameData.Score = score;
		anim.SetTrigger ("Update");
	}
}
