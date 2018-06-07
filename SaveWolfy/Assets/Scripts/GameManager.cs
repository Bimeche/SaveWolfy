using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public RectTransform pausePanel;
	public RectTransform pauseButtonPanel;
	public RectTransform currentScorePanel;
	public RectTransform endGamePanel;
	public Text scoreText;
	public Text bestScore;
	public Text finalScore;
	public Text scoreToBeat;
	private int playerScore = 0;
	private float scoreUpdate = 0.2f;
	[HideInInspector]
	public List<Transform> cowsSpawned;
	private bool paused = false;
	int comboCount = 0;
	private bool gameEnded;


	// Use this for initialization
	void Start () {
		Cursor.visible = true;
		Time.timeScale = 1f;
		gameEnded = false;
		cowsSpawned = new List<Transform>();
		pausePanel.GetComponent<CanvasGroup>().alpha = 0;
		pausePanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
		endGamePanel.GetComponent<CanvasGroup>().alpha = 0;
		endGamePanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P))
			PauseGame();
	}

	public void DestroyCow (GameObject go, int strikeMeter) {
		cowsSpawned.Remove(go.transform);
		comboCount++;
		playerScore += 5;
		playerScore += strikeMeter;
		playerScore += comboCount;
		Destroy(go);
		Debug.Log(playerScore);
		scoreText.text = "Score : " + playerScore;
		Debug.Log(comboCount);
	}

	public void ResetCombo () {
		comboCount = 0;
		Debug.Log ("Reset combo");
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
		Transform toDestroy;
		for(int i = cowsSpawned.Count - 1; i >= 0; i--)
		{
			toDestroy = cowsSpawned[i];
			cowsSpawned.RemoveAt(i);
			Destroy(toDestroy.gameObject);
		}

		endGamePanel.GetComponent<CanvasGroup>().alpha = 1;
		endGamePanel.GetComponent<CanvasGroup>().blocksRaycasts = true;

		//pauseButtonPanel.GetComponent<CanvasGroup>().alpha = 0;
		//pauseButtonPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

		currentScorePanel.GetComponent<CanvasGroup>().alpha = 0;
		currentScorePanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

		finalScore.text = "" + playerScore;
	}
}