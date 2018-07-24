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

	public Sprite baseGround;
	public Sprite fireGround;
	public Sprite iceGround;
	public Sprite desertGround;

	public Sprite baseLeftWall;
	public Sprite fireLeftWall;
	public Sprite iceLeftWall;
	public Sprite desertLeftWall;

	public Sprite baseRightWall;
	public Sprite fireRightWall;
	public Sprite iceRightWall;
	public Sprite desertRightWall;

	public GameObject playerSprite0;
	public GameObject playerSprite1;
	public GameObject playerSprite2;
	public GameObject playerSprite3;
	public GameObject playerSprite4;



	// Use this for initialization
	void Start () {
		UpdateBackGround ();
		UpdateCursorSkin ();
	}

	public void ChangeBackGround(int id){
		PlayerPrefs.SetInt ("BackGroundSkin", id);
		PlayerPrefs.SetInt ("GroundSkin", id);
		PlayerPrefs.SetInt ("LeftWallSkin", id);
		PlayerPrefs.SetInt ("RightWallSkin", id);
		UpdateBackGround ();
	}

	public void ChangeCursorSkin(int id){
		PlayerPrefs.SetInt ("CursorSkin", id);
		UpdateCursorSkin ();
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
		default:
			PlayerPrefs.SetInt ("RigthWallSkin", 0);
			rightWallGO.GetComponent<SpriteRenderer> ().sprite = baseRightWall;
			break;
		}
	}

	void UpdateCursorSkin(){
		int cursorSkin = PlayerPrefs.GetInt ("CursorSkin");

		switch (cursorSkin) {
		case 0:
			playerSprite0.SetActive (true);
			playerSprite1.SetActive (false);
			playerSprite2.SetActive (false);
			playerSprite3.SetActive(false);
			playerSprite4.SetActive(false);
			break;
		case 1:
			playerSprite0.SetActive(false);
			playerSprite1.SetActive (true);
			playerSprite2.SetActive (false);
			playerSprite3.SetActive (false);
			playerSprite4.SetActive (false);
			break;
		case 2:
			playerSprite0.SetActive (false);
			playerSprite1.SetActive (false);
			playerSprite2.SetActive (true);
			playerSprite3.SetActive (false);
			playerSprite4.SetActive (false);
			break;
		case 3:
			playerSprite0.SetActive (false);
			playerSprite1.SetActive (false);
			playerSprite2.SetActive (false);
			playerSprite3.SetActive (true);
			playerSprite4.SetActive (false);
			break;
		case 4:
			playerSprite0.SetActive (false);
			playerSprite1.SetActive (false);
			playerSprite2.SetActive (false);
			playerSprite3.SetActive (false);
			playerSprite4.SetActive (true);
			break;
		default:
			PlayerPrefs.SetInt ("CursorSkin", 0);
			playerSprite0.SetActive (true);
			playerSprite1.SetActive (false);
			playerSprite2.SetActive (false);
			playerSprite3.SetActive (false);
			playerSprite4.SetActive (false);
			break;
		}
	}
}
