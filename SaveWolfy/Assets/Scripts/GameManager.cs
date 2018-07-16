using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public GameObject player;
	public RectTransform pausePanel;
	public RectTransform pauseButtonPanel;
	public RectTransform endGamePanel;
	public GameObject score;
	public Text bestScore;
	public Text finalScore;
	public Text scoreToBeat;
	private int playerScore = 0;
	private bool paused = false;
	private bool gameEnded;
	public float aspectWidth = 16.0f;
	public float aspectHeight = 9.0f;
	public ObjectPooler objectPooler;

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
		Time.timeScale = 1f;
		gameEnded = false;
		SoundManager.instance.PauseMusic(false);
		adaptScreenRatio();
		pausePanel.GetComponent<CanvasGroup>().alpha = 0;
		pausePanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
		endGamePanel.GetComponent<CanvasGroup>().alpha = 0;
		endGamePanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

		score.GetComponent<ScoreUpdate> ().Initialize(playerScore);
	}

	// Update is called once per frame
	void Update () {
		Debug.Log ("Haaaa");
		if (Input.GetKeyDown(KeyCode.I) && Application.isEditor)
		{
			playerScore += 200;
			score.GetComponent<ScoreUpdate>().UpdateScore(playerScore);
		}
		if (Input.GetKeyDown(KeyCode.P))
			PauseGame();
		if (Input.GetKeyDown(KeyCode.Escape))
			PauseGame();
	}

	public void DestroyCow (GameObject go, int strikeMeter) {
		playerScore += 1;
		playerScore += strikeMeter;
		objectPooler.DespawnToPool(go);

		score.GetComponent<ScoreUpdate> ().UpdateScore(playerScore);
	}

	public void PauseGame () {
		if (gameEnded)
			return;
		if (!paused)
		{
			paused = true;
			Time.timeScale = 0f;
			pausePanel.GetComponent<CanvasGroup>().alpha = 1;
			pausePanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
		}
		else
		{
			paused = false;
			Time.timeScale = 1f;
			pausePanel.GetComponent<CanvasGroup>().alpha = 0;
			pausePanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
		}

	}

	public void EndGame(GameObject go) {
		Time.timeScale = 0;
		gameEnded = true;
		Destroy(go);

		endGamePanel.GetComponent<CanvasGroup>().alpha = 1;
		endGamePanel.GetComponent<CanvasGroup>().blocksRaycasts = true;

		pauseButtonPanel.GetComponent<CanvasGroup>().alpha = 0;
		pauseButtonPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

		finalScore.text = "" + playerScore;
		if (playerScore > PlayerPrefs.GetFloat("Highscore"))
		{
			PlayerPrefs.SetFloat ("Highscore", playerScore);
			bestScore.CrossFadeAlpha(1f, 0f, true);
			scoreToBeat.CrossFadeAlpha(0f, 0f, true);
		}
		else
		{
			scoreToBeat.text = "Highscore : " + ((int)PlayerPrefs.GetFloat ("Highscore")).ToString();
			bestScore.CrossFadeAlpha(0f, 0f, true);
			scoreToBeat.CrossFadeAlpha(1f, 0f, true);
		}
	}
}