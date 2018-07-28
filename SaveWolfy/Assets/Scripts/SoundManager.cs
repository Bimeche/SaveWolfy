﻿using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioSource efxSource;
	public AudioSource efxSource2;
	public AudioSource efxSource3;
	public AudioSource musicSource;
	public static SoundManager instance = null;

	public float lowPitchRange = .95f;
	public float highPitchRange = 1.05f;

	private void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
	}

	public void PlaySingle(AudioClip clip) {
		efxSource.clip = clip;
		efxSource.Play();
	}

	public void PauseMusic (bool pause) {
		if (pause)
			musicSource.Pause();
		else
			musicSource.UnPause();
	}

	public void RandomizeSfx (params AudioClip[] clips) {
		int randomIndex = Random.Range (0, clips.Length);

		float randomPitch = Random.Range (lowPitchRange, highPitchRange);
		if (efxSource)
		{
			efxSource.pitch = randomPitch;

			efxSource.clip = clips [randomIndex];

			efxSource.Play ();
		}
	}

	public void RandomizeSfx2 (params AudioClip[] clips) {
		int randomIndex = Random.Range (0, clips.Length);

		float randomPitch = Random.Range (lowPitchRange, highPitchRange);
		if (efxSource2)
		{
			efxSource2.pitch = randomPitch;

			efxSource2.clip = clips [randomIndex];

			efxSource2.Play ();
		}
	}

	public void RandomizeSfx3 (params AudioClip[] clips) {
		int randomIndex = Random.Range (0, clips.Length);

		float randomPitch = Random.Range (lowPitchRange, highPitchRange);
		if (efxSource3)
		{
			efxSource3.pitch = randomPitch;

			efxSource3.clip = clips [randomIndex];

			efxSource3.Play ();
		}
	}
}
