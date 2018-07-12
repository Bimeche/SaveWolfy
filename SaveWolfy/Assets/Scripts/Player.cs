using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	Camera cam;
	[SerializeField] private ParticleSystem footTrailPrefab;

	void Enable () {
		cam = Camera.main;
		footTrailPrefab.Play();
	}

	// Use this for initialization
	void Start () {
		cam = Camera.main;
	}

	private Coroutine m_updateCoroutine;
	private void OnEnable () {
		cam = Camera.main;
		m_updateCoroutine = StartCoroutine(UpdatePosition());
	}
	private void OnDisable () {
		if (m_updateCoroutine != null)
		{
			StopCoroutine(m_updateCoroutine);
			m_updateCoroutine = null;
		}
	}

	private IEnumerator UpdatePosition () {
		while (true)
		{
			Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
			Debug.Log(newPosition);
			transform.position = newPosition;
			//Instantiate(footTrailPrefab, transform);
			yield return null;
		}
	}
}