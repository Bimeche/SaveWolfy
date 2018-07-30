using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	Camera cam;
	public ParticleSystem playerTrail;
	public ParticleSystem playerEffect;
	public ParticleSystem playerTrailSuppEffect;

	void Enable () {
		cam = Camera.main;

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
			
			//PC
			Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
			transform.position = newPosition;

			//mobile
			/*if (Input.touchCount > 0)
			{
				Touch touch = Input.GetTouch(0);

			switch(touch.phase){
				case TouchPhase.Began:
					// Get movement of the finger since last frame
					Vector2 newPosition = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);

					// Move object across XY plane
					transform.position = newPosition;
					playerEffect.Play();
					playerTrail.Play();
					playerTrailSuppEffect.Play();
					GetComponent<Rigidbody2D> ().simulated = true;
				break;
			
				case TouchPhase.Moved:
				// Get movement of the finger since last frame
				Vector2 movePosition = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);

				// Move object across XY plane
				transform.position = movePosition;

				break;

				case TouchPhase.Ended:
					playerEffect.Stop ();
					playerTrail.Stop ();
					playerTrailSuppEffect.Stop ();
					playerEffect.Clear ();
					playerTrail.Clear ();
					playerTrailSuppEffect.Clear ();
					GetComponent<Rigidbody2D> ().simulated = false;
				break;
				}
			}*/

			yield return null;
		}
	}
}