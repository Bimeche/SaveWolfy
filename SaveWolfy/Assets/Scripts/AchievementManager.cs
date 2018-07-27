using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour {

	/*public GameObject achievmentPrefab;
	public Sprite[] sprites;
	public GameObject visualAchievment;
	public Dictionary<string, Achievment> achievments = new Dictionary<string, Achievment> ();
	public Sprite unlockedSprite;
	public Text textPoints;
	private static AchievementManager instance;
	private int fadeTime = 2;

	public static AchievementManager Instance {
		get {
			if (instance == null) {
				instance = GameObject.FindObjectOfType<AchievmentManager> ();
			}
			return AchievementManager.instance;
		}
	}

	// Use this for initialization
	void Start () {

			//Si besoin de delete les saves:
		//PlayerPrefs.DeleteAll();
		//PlayerPrefs.DeleteKey("Points");
		CreateAchievment ("General", "Green", "this is the description", 10, 0);

		CreateAchievment ("General", "Test Title", "this is the description", 10, 0);
		CreateAchievment ("General", "Press W", "Press W to unlock this achievment", 10, 0);
		CreateAchievment ("General", "Press S", "Press S to unlock this achievment", 10, 0);
		CreateAchievment ("General", "All Keys", "Press all keys to unlock", 10, 0, new string[]{"Press W", "Press S"}); //dependent achievment
		
	}
	
	// Update is called once per frame
	void Update () {
		//pour valider l'achievement. Il va falloir tweeker un peu.
		if (Input.GetKeyDown (KeyCode.W)) {
			EarnAchievment ("*exact name of the achievment*");
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			EarnAchievment ("*exact name of the achievment*");
		}
	}

	public void EarnAchievment(string title){
		if(achievments[title].earnAchievment()){
			//Do something awesome!
			GameObject achievment = (GameObject)Instantiate(visualAchievment);
			SetAchievmentInfo ("EarnCanvas", achievment, title); // c'est une référence par le nom
			StartCoroutine (HideAchievment (achievment));
			//for fade, change to : StartCoroutine (FadeAchievement(achievment));
			//ici qu'on unlock le skin
		}
	}

	//pour l'anim du succés: devra surement être changé
	public IEnumerator HideAchievment(GameObject achievment){
		yield return new WaitForSeconds (3);
		Destroy (achievment);
	}

	public void  CreateAchievment(string title, int spriteIndex, string[] dependencies = null){
		GameObject achievment = (GameObject)Instantiate(achievmentPrefab);
		Achievment newAchievment = new Achievment(name, spriteIndex, achievment);
		achievments.Add(title, newAchievment);
		SetAchievmentInfo (achievment, title);
		if (dependencies != null){
				foreach (string achievmentTitle in dependencies){
					Achievment dependency = achievments[achievmentTitle];
					dependency.Child = title;
					newAchievment.AddDependency(achievments[achievmentTitle]);
			}
		}
	}

	public void SetAchievmentInfo(string parent, GameObject achievment, string title){
		achievment.transform.SetParent (GameObject.Find (parent).transform);
		achievment.transform.localScale = new Vector3 (1, 1, 1);
		achievment.transform.GetChild (0).GetComponent<Text>().text = title;
		achievment.transform.GetChild (1).GetComponent<Text>().text = achievments[title].Description;
		achievment.transform.GetChild (2).GetComponent<Text>().text = achievments[title].Points.ToString();
		achievment.transform.GetChild (3).GetComponent<Image>().sprite = sprites[achievments[title].spriteIndex];
	}

	private IEnumerator FadeAchievment(GameObject achievment){
		// la disparition de l'achievment aprés qu'il ai apparu
		CanvasGroup canvasGroup = achievment.GetComponent<CanvasGroup>();
		float rate = 1.0f / fadeTime;
		int startAlpha = 0;
		int endAlpha = 1;
		float progress = 0.0f;

		for (int i = 0; i < 2; i++) {
			while (progress < 1.0) {
				canvasGroup.alpha = Mathf.Lerp (startAlpha, endAlpha, progress);

				progress += rate * Time.deltaTime;

				yield return null;
			}
			yield return new WaitForSeconds (2);
			startAlpha = 1;
			endAlpha = 0;
		}

		Destroy (achievment);
	}*/
}
