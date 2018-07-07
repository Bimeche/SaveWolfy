using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {

	public Sprite baseBackGround;
	public Sprite testBackGround;

	// Use this for initialization
	void Start () {
		UpdateBackGround ();
	}

	public void ChangeBackGround(int id){
		PlayerPrefs.SetInt ("BackGroundSkin", id);
		UpdateBackGround ();
	}

	void UpdateBackGround(){
		int choice = PlayerPrefs.GetInt ("BackGroundSkin");
		switch(choice){
		case 0:
			GetComponent<SpriteRenderer> ().sprite = baseBackGround;
			break;
		case 1:
			GetComponent<SpriteRenderer> ().sprite = testBackGround;
			break;
		default:
			PlayerPrefs.SetInt ("BackGroundSkin", 0);
			GetComponent<SpriteRenderer> ().sprite = baseBackGround;
			break;
		}
	}
}
