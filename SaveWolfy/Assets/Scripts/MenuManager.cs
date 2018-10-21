using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;

public class MenuManager : MonoBehaviour {
	
	public float aspectWidth = 16.0f;
	public float aspectHeight = 9.0f;
	public RectTransform mainMenuPanel;
	public RectTransform skinPanel;
	public RectTransform highScorePanel;

	public RectTransform changeSkinButton0;
	public RectTransform changeSkinButton1;
	public RectTransform changeSkinButton2;
	public RectTransform changeSkinButton3;
	int skinScrollingState;

	public RectTransform changeCursorButton0;
	public RectTransform changeCursorButton1;
	public RectTransform changeCursorButton2;
	public RectTransform changeCursorButton3;
	public RectTransform changeCursorButton4;
	int cursorScrollingState;

	public GameObject changeSkinText1;
	public GameObject changeSkinText2;
	public GameObject changeSkinText3;
	public GameObject changeCursorText1;
	public GameObject changeCursorText2;
	public GameObject changeCursorText3;
	public GameObject changeCursorText4;

	public GameObject highScoreText;

	public AudioClip buttonClic;



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
		Cursor.visible = false;
		Time.timeScale = 1f;
		SoundManager.instance.PauseMusic(false);
		adaptScreenRatio();
		GameData.ResetValues();
		CheckData ();
		SetHighscore ();
		//GooglePlay Services Initialize

	}

	public void OpenSkinMenu(){
		SoundManager.instance.RandomizeSfx (buttonClic, buttonClic);
		mainMenuPanel.GetComponent<CanvasGroup>().alpha = 0;
		mainMenuPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

		skinPanel.GetComponent<CanvasGroup>().alpha = 1;
		skinPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	public void OpenMainMenu(){
		SoundManager.instance.RandomizeSfx (buttonClic, buttonClic);
		skinPanel.GetComponent<CanvasGroup>().alpha = 0;
		skinPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

		highScorePanel.GetComponent<CanvasGroup>().alpha = 0;
		highScorePanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

		mainMenuPanel.GetComponent<CanvasGroup>().alpha = 1;
		mainMenuPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	public void OpenHighScoreMenu(){
		SoundManager.instance.RandomizeSfx (buttonClic, buttonClic);
        Social.localUser.Authenticate((bool success) =>
        {
        });
        if (Social.localUser.authenticated)
        {
            Social.ShowLeaderboardUI();
        }
            mainMenuPanel.GetComponent<CanvasGroup>().alpha = 0;
            mainMenuPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

            highScorePanel.GetComponent<CanvasGroup>().alpha = 1;
            highScorePanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

	public void SkinScrollRigth(){
		SoundManager.instance.RandomizeSfx (buttonClic, buttonClic);
		if (skinScrollingState < 3) {
			skinScrollingState = skinScrollingState + 1;
		}
		else {
			skinScrollingState = 0;
		}

		switch (skinScrollingState) {
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

	public void SkinScrollLeft(){
		SoundManager.instance.RandomizeSfx (buttonClic, buttonClic);
		if (skinScrollingState > 0) {
			skinScrollingState = skinScrollingState - 1;
		} else {
			skinScrollingState = 3;
		}

		switch (skinScrollingState) {
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

	public void CursorScrollRigth(){
		SoundManager.instance.RandomizeSfx (buttonClic, buttonClic);
		if (cursorScrollingState < 4) {
			cursorScrollingState = cursorScrollingState + 1;
		}
		else {
			cursorScrollingState = 0;
		}

		switch (cursorScrollingState) {
		case 0:
			changeCursorButton4.GetComponent<CanvasGroup> ().alpha = 0;
			changeCursorButton4.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeCursorButton0.GetComponent<CanvasGroup> ().alpha = 1;
			changeCursorButton0.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;

		case 1:
			changeCursorButton0.GetComponent<CanvasGroup> ().alpha = 0;
			changeCursorButton0.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeCursorButton1.GetComponent<CanvasGroup> ().alpha = 1;
			changeCursorButton1.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;

		case 2:
			changeCursorButton1.GetComponent<CanvasGroup> ().alpha = 0;
			changeCursorButton1.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeCursorButton2.GetComponent<CanvasGroup> ().alpha = 1;
			changeCursorButton2.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;

		case 3:
			changeCursorButton2.GetComponent<CanvasGroup> ().alpha = 0;
			changeCursorButton2.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeCursorButton3.GetComponent<CanvasGroup> ().alpha = 1;
			changeCursorButton3.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;
		case 4:
			changeCursorButton3.GetComponent<CanvasGroup> ().alpha = 0;
			changeCursorButton3.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeCursorButton4.GetComponent<CanvasGroup> ().alpha = 1;
			changeCursorButton4.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;
		default:
			break;
		}
	}

	public void CursorScrollLeft(){
		SoundManager.instance.RandomizeSfx (buttonClic, buttonClic);
		if (cursorScrollingState > 0) {
			cursorScrollingState = cursorScrollingState - 1;
		} else {
			cursorScrollingState = 4;
		}

		switch (cursorScrollingState) {
		case 0:
			changeCursorButton1.GetComponent<CanvasGroup> ().alpha = 0;
			changeCursorButton1.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeCursorButton0.GetComponent<CanvasGroup> ().alpha = 1;
			changeCursorButton0.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;

		case 1:
			changeCursorButton2.GetComponent<CanvasGroup> ().alpha = 0;
			changeCursorButton2.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeCursorButton1.GetComponent<CanvasGroup> ().alpha = 1;
			changeCursorButton1.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;

		case 2:
			changeCursorButton3.GetComponent<CanvasGroup> ().alpha = 0;
			changeCursorButton3.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeCursorButton2.GetComponent<CanvasGroup> ().alpha = 1;
			changeCursorButton2.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;

		case 3:
			changeCursorButton4.GetComponent<CanvasGroup> ().alpha = 0;
			changeCursorButton4.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeCursorButton3.GetComponent<CanvasGroup> ().alpha = 1;
			changeCursorButton3.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;
		case 4:
			changeCursorButton0.GetComponent<CanvasGroup> ().alpha = 0;
			changeCursorButton0.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			changeCursorButton4.GetComponent<CanvasGroup> ().alpha = 1;
			changeCursorButton4.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			break;
		default:
			break;
		}
	}

	void CheckData(){
		int groundSkin1 = PlayerPrefs.GetInt ("Fire");
		int groundSkin2 = PlayerPrefs.GetInt ("Ice");
		int groundSkin3 = PlayerPrefs.GetInt ("Desert");
		int cursorSkin1 = PlayerPrefs.GetInt ("Green");
		int cursorSkin2 = PlayerPrefs.GetInt ("Purple");
		int cursorSkin3 = PlayerPrefs.GetInt ("Yellow");
		int cursorSkin4 = PlayerPrefs.GetInt ("Red");

		if (groundSkin1 == 1) {
			changeSkinButton1.GetComponent<Button> ().interactable = true;
			changeSkinText1.SetActive (false);
		}

		if (groundSkin2 == 1) {
			changeSkinButton2.GetComponent<Button> ().interactable = true;
			changeSkinText2.SetActive (false);
		}

		if (groundSkin3 == 1) {
			changeSkinButton3.GetComponent<Button> ().interactable = true;
			changeSkinText3.SetActive (false);
		}

		if (cursorSkin1 == 1) {
			changeCursorButton1.GetComponent<Button> ().interactable = true;
			changeCursorText1.SetActive (false);
		}

		if (cursorSkin2 == 1) {
			changeCursorButton2.GetComponent<Button> ().interactable = true;
			changeCursorText2.SetActive (false);
		}

		if (cursorSkin3 == 1) {
			changeCursorButton3.GetComponent<Button> ().interactable = true;
			changeCursorText3.SetActive (false);
		}

		if (cursorSkin4 == 1) {
			changeCursorButton4.GetComponent<Button> ().interactable = true;
			changeCursorText4.SetActive (false);
		}
	}

	public void SetHighscore(){
		highScoreText.GetComponent<Text>().text = ((int)PlayerPrefs.GetFloat ("Highscore")).ToString();
	}

    //Achievements
    public void OnAchievementClick()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowAchievementsUI();
        }
    }
}