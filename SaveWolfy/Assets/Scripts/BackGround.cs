using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {

	public GameObject groundGO;
	public GameObject leftWallGO;
	public GameObject rightWallGO;

	public Sprite baseBackGround;
	public Sprite fireBackGround;
	public Sprite iceBackGround;
	public Sprite desertBackGround;
	public Sprite jungleBackGround;

	public Sprite baseGround;
	public Sprite fireGround;
	public Sprite iceGround;
	public Sprite desertGround;
	public Sprite jungleGround;

	public Sprite baseLeftWall;
	public Sprite fireLeftWall;
	public Sprite iceLeftWall;
	public Sprite desertLeftWall;
	public Sprite jungleLeftWall;

	public Sprite baseRightWall;
	public Sprite fireRightWall;
	public Sprite iceRightWall;
	public Sprite desertRightWall;
	public Sprite jungleRightWall;


	// Use this for initialization
	void Start () {
		UpdateBackGround ();
	}

	public void ChangeBackGround(int id){
		PlayerPrefs.SetInt ("BackGroundSkin", id);
		PlayerPrefs.SetInt ("GroundSkin", id);
		PlayerPrefs.SetInt ("LeftWallSkin", id);
		PlayerPrefs.SetInt ("RightWallSkin", id);
		UpdateBackGround ();
	}

	void UpdateBackGround(){
		int backGround = PlayerPrefs.GetInt ("BackGroundSkin");
		int ground = PlayerPrefs.GetInt ("GroundSkin");
		int leftWall = PlayerPrefs.GetInt ("LeftWallSkin");
		int rightWall = PlayerPrefs.GetInt ("RightWallSkin");

		switch (backGround) {
		case 0:
			GetComponent<SpriteRenderer> ().sprite = baseBackGround;
			break;
		case 1:
			GetComponent<SpriteRenderer> ().sprite = fireBackGround;
			break;
		case 2:
			GetComponent<SpriteRenderer> ().sprite = iceBackGround;
			break;
		case 3:
			GetComponent<SpriteRenderer> ().sprite = desertBackGround;
			break;
		case 4:
			GetComponent<SpriteRenderer> ().sprite = jungleBackGround;
			break;
		default:
			PlayerPrefs.SetInt ("BackGroundSkin", 0);
			GetComponent<SpriteRenderer> ().sprite = baseBackGround;
			break;
		}
		
		switch(ground){
		case 0:
			groundGO.GetComponent<SpriteRenderer> ().sprite = baseGround;
			break;
		case 1:
			groundGO.GetComponent<SpriteRenderer> ().sprite = fireGround;
			break;
		case 2:
			groundGO.GetComponent<SpriteRenderer> ().sprite = iceGround;
			break;
		case 3:
			groundGO.GetComponent<SpriteRenderer> ().sprite = desertGround;
			break;
		case 4:
			groundGO.GetComponent<SpriteRenderer> ().sprite = jungleGround;
			break;
		default:
			PlayerPrefs.SetInt ("GroundSkin", 0);
			groundGO.GetComponent<SpriteRenderer> ().sprite = baseGround;
			break;
		}

		switch(leftWall){
		case 0:
			leftWallGO.GetComponent<SpriteRenderer> ().sprite = baseLeftWall;
			break;
		case 1:
			leftWallGO.GetComponent<SpriteRenderer> ().sprite = fireLeftWall;
			break;
		case 2:
			leftWallGO.GetComponent<SpriteRenderer> ().sprite = iceLeftWall;
			break;
		case 3:
			leftWallGO.GetComponent<SpriteRenderer> ().sprite = desertLeftWall;
			break;
		case 4:
			leftWallGO.GetComponent<SpriteRenderer> ().sprite = jungleLeftWall;
			break;
		default:
			PlayerPrefs.SetInt ("LeftWallSkin", 0);
			leftWallGO.GetComponent<SpriteRenderer> ().sprite = baseLeftWall;
			break;
		}

		switch(rightWall){
		case 0:
			rightWallGO.GetComponent<SpriteRenderer> ().sprite = baseRightWall;
			break;
		case 1:
			rightWallGO.GetComponent<SpriteRenderer> ().sprite = fireRightWall;
			break;
		case 2:
			rightWallGO.GetComponent<SpriteRenderer> ().sprite = iceRightWall;
			break;
		case 3:
			rightWallGO.GetComponent<SpriteRenderer> ().sprite = desertRightWall;
			break;
		case 4:
			rightWallGO.GetComponent<SpriteRenderer> ().sprite = jungleRightWall;
			break;
		default:
			PlayerPrefs.SetInt ("RigthWallSkin", 0);
			rightWallGO.GetComponent<SpriteRenderer> ().sprite = baseRightWall;
			break;
		}
	}
}
