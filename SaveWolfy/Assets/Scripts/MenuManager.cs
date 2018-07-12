using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
	
	public float aspectWidth = 16.0f;
	public float aspectHeight = 9.0f;
	public RectTransform mainMenuPanel;
	public RectTransform skinPanel;

	public RectTransform changeSkinButton0;
	public RectTransform changeSkinButton1;
	public RectTransform changeSkinButton2;
	public RectTransform changeSkinButton3;
	int scrollingState;


	void adaptScreenRatio () {

		// set the desired aspect ratio (the values in this example are
		// hard-coded for 16:9, but you could make them into public
		// variables instead so you can set them at design time)
		float targetAspect = aspectWidth / aspectHeight;

		// determine the game window's current aspect ratio
		float windowAspect = (float)Screen.width / Screen.height;

		// current viewport height should be scaled by this amount
		float scaleHeight = windowAspect / targetAspect;


		// if scaled height is less than current height, add letterbox
		if (scaleHeight < 1.0f)
		{
			Rect rect = Camera.main.rect;

			rect.width = 1.0f;
			rect.height = scaleHeight;
			rect.x = 0;
			rect.y = (1.0f - scaleHeight) / 2.0f;

			Camera.main.rect = rect;
		}
		else // add pillarbox
		{
			float scaleWidth = 1.0f / scaleHeight;

			Rect rect = Camera.main.rect;

			rect.width = scaleWidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scaleWidth) / 2.0f;
			rect.y = 0;

			Camera.main.rect = rect;
		}
	}
	// Use this for initialization
	void Start () {
		Cursor.visible = true;
		Time.timeScale = 1f;
		SoundManager.instance.PauseMusic(false);
		adaptScreenRatio();
	}

	public void OpenSkinMenu(){
		mainMenuPanel.GetComponent<CanvasGroup>().alpha = 0;
		mainMenuPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

		skinPanel.GetComponent<CanvasGroup>().alpha = 1;
		skinPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	public void OpenMainMenu(){
		skinPanel.GetComponent<CanvasGroup>().alpha = 0;
		skinPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

		mainMenuPanel.GetComponent<CanvasGroup>().alpha = 1;
		mainMenuPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	public void ScrollRigth(){
		if (scrollingState < 3) {
			scrollingState = scrollingState + 1;
		}
		else {
			scrollingState = 0;
		}

		switch (scrollingState) {
		case 0:
			changeSkinButton3.GetComponent<CanvasGroup> ().alpha = 0;
			changeSkinButton3.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeSkinButton0.GetComponent<CanvasGroup> ().alpha = 1;
			changeSkinButton0.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;

		case 1:
			changeSkinButton0.GetComponent<CanvasGroup> ().alpha = 0;
			changeSkinButton0.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeSkinButton1.GetComponent<CanvasGroup> ().alpha = 1;
			changeSkinButton1.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;

		case 2:
			changeSkinButton1.GetComponent<CanvasGroup> ().alpha = 0;
			changeSkinButton1.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeSkinButton2.GetComponent<CanvasGroup> ().alpha = 1;
			changeSkinButton2.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;

		case 3:
			changeSkinButton2.GetComponent<CanvasGroup> ().alpha = 0;
			changeSkinButton2.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeSkinButton3.GetComponent<CanvasGroup> ().alpha = 1;
			changeSkinButton3.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;
		default:
			break;
		}
	}

	public void ScrollLeft(){
		if (scrollingState > 0) {
			scrollingState = scrollingState - 1;
		} else {
			scrollingState = 3;
		}

		switch (scrollingState) {
		case 0:
			changeSkinButton1.GetComponent<CanvasGroup> ().alpha = 0;
			changeSkinButton1.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeSkinButton0.GetComponent<CanvasGroup> ().alpha = 1;
			changeSkinButton0.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;

		case 1:
			changeSkinButton2.GetComponent<CanvasGroup> ().alpha = 0;
			changeSkinButton2.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeSkinButton1.GetComponent<CanvasGroup> ().alpha = 1;
			changeSkinButton1.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;

		case 2:
			changeSkinButton3.GetComponent<CanvasGroup> ().alpha = 0;
			changeSkinButton3.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeSkinButton2.GetComponent<CanvasGroup> ().alpha = 1;
			changeSkinButton2.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;

		case 3:
			changeSkinButton0.GetComponent<CanvasGroup> ().alpha = 0;
			changeSkinButton0.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeSkinButton3.GetComponent<CanvasGroup> ().alpha = 1;
			changeSkinButton3.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;
		default:
			break;
		}
	}
}