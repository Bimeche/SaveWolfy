using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowSpawner : MonoBehaviour {

	public GameObject cow;
	public Rect spawnZone;
	public float minSpawnForce = 1f;
	public float maxSpawnForce = 800f;
	public float baseSpawnTime = 3f;
	public float regularTimeReduction = 0.01f;
	public float minimalSpawnTime = 0.5f;
	public int waveCount = 0;

	ObjectPooler objectPooler;

	// Use this for initialization
	public void Start () {
		objectPooler = ObjectPooler.Instance;
		Invoke("RegularCowSpawn", baseSpawnTime);
	}

	void CowSpawn (){
		Vector2 spawnPosition;
		do
		{
			spawnPosition = new Vector2(Random.Range(spawnZone.xMin, spawnZone.xMax), Random.Range(spawnZone.yMin, spawnZone.yMax));
		}
		while (!IsSpawnPossible(spawnPosition, cow.GetComponent<CircleCollider2D>().radius));

		GameObject cowSpawned = objectPooler.SpawnFromPool ("Cow", spawnPosition, Quaternion.identity);

		Vector2 angle;
		if (spawnPosition.x < 0)
			angle = new Vector2(Random.Range(-spawnPosition.x / 3, -spawnPosition.x), -Random.Range(3f, 7f));
		else if (spawnPosition.x > 0)
			angle = new Vector2(Random.Range(-spawnPosition.x, -spawnPosition.x / 3), -Random.Range(3f, 7f));
		else
			angle = new Vector2(Random.Range(-6f, 6f), -Random.Range(3f, 7f));


		cowSpawned.GetComponent<Rigidbody2D>().AddForce(angle * Random.Range(minSpawnForce, maxSpawnForce));
	}

	void RegularCowSpawn () {
		CowSpawn ();
		float chance = Random.Range(0f, 1f);
		if (chance < 0.3f) {
			SuppCowSpawn ();
		}

		baseSpawnTime -= regularTimeReduction;
		if (baseSpawnTime < minimalSpawnTime)
			baseSpawnTime = minimalSpawnTime;
		Invoke("RegularCowSpawn", baseSpawnTime);
		if (waveCount == 10) {
			waveCount = 0;
			WaveSpawn ();
		}
		waveCount++;
	}

	void SuppCowSpawn () {
		CowSpawn ();
		float chance = Random.Range (0f, 1f);
		if (chance < 0.1f) {
			Supp2CowSpawn ();
		}
	}

	void Supp2CowSpawn () {
		CowSpawn ();
	}

	void WaveSpawn (){
		CowSpawn();
		float chance = Random.Range (0.0f, 1.0f);
			if(chance > 0.4){
				CowSpawn();
			}
			if(chance > 0.8){
				CowSpawn();
			}
	}

	bool IsSpawnPossible (Vector2 targetPosition, float checkRadius) {
		var checkResult = Physics2D.OverlapCircle(targetPosition, checkRadius);
		return checkResult == null;
	}
}