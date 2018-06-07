using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowSpawner : MonoBehaviour {

	public GameObject cow;
	public Rect spawnZone;
	public float minSpawnForce = 1f;
	public float maxSpawnForce = 1000f;
	public float baseSpawnTime = 3f;
	public float regularTimeReduction = 0.01f;
	public float minimalSpawnTime = 0.5f;

	private GameManager gMan;

	// Use this for initialization
	void Start () {
		gMan = FindObjectOfType<GameManager>();
		Invoke("RegularCowSpawn", baseSpawnTime);
		Debug.Log(spawnZone.xMin + "  " + spawnZone.xMax + "  " + spawnZone.yMin + "  " + spawnZone.yMax);
	}

	void RegularCowSpawn () {
		Vector2 spawnPosition = new Vector2(Random.Range(spawnZone.xMin,spawnZone.xMax), Random.Range(spawnZone.yMin, spawnZone.yMax));

		if(!IsSpawnPossible(spawnPosition, cow.GetComponent<CircleCollider2D>().radius))
		{
			Debug.Log("cow collided at spawn, not spawned");
			baseSpawnTime -= regularTimeReduction;
			if (baseSpawnTime < minimalSpawnTime)
				baseSpawnTime = minimalSpawnTime;
			Invoke("RegularCowSpawn", baseSpawnTime);
			return;
		}

		GameObject cowSpawned = Instantiate(cow, spawnPosition, Quaternion.identity);

		Vector2 angle;
		if (spawnPosition.x < 0)
			angle = new Vector2(Random.Range(-spawnPosition.x / 3, -spawnPosition.x), -Random.Range(3f, 7f));
		else if (spawnPosition.x > 0)
			angle = new Vector2(Random.Range(-spawnPosition.x, -spawnPosition.x / 3), -Random.Range(3f, 7f));
		else
			angle = new Vector2(Random.Range(-6f, 6f), -Random.Range(3f, 7f));


		cowSpawned.GetComponent<Rigidbody2D>().AddForce(angle * Random.Range(minSpawnForce, maxSpawnForce));
		gMan.cowsSpawned.Add(cowSpawned.transform);
		baseSpawnTime -= regularTimeReduction;
		if (baseSpawnTime < minimalSpawnTime)
			baseSpawnTime = minimalSpawnTime;
		Invoke("RegularCowSpawn", baseSpawnTime);
	}

	bool IsSpawnPossible (Vector2 targetPosition, float checkRadius) {
		var checkResult = Physics2D.OverlapCircle(targetPosition, checkRadius);
		return checkResult == null;
	}
}