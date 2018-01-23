using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public Transform[] SpawnPoints;
	public float timer = 0.0f;
	public GameObject Alien;
	public float SpawnTime = 3.0f;

	void Start () {
	
	}
	
	void Update () {
		timer += Time.fixedDeltaTime;
		if (timer > SpawnTime) {
			int rand = Random.Range (0, SpawnPoints.Length);
			GameObject explosion = Instantiate (Alien, SpawnPoints[rand].position, SpawnPoints[rand].rotation) as GameObject;
			timer = 0f;
		}
	}
}
