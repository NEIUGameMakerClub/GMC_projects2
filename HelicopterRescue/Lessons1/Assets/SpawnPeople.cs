using UnityEngine;
using System.Collections;

public class SpawnPeople : MonoBehaviour {

	public float timer = 0.0f;
	public float SpawnTime = 10.0f;
	public GameObject Person;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.fixedDeltaTime;

		if (timer > SpawnTime) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-8, 8), 0f, Random.Range (-8, 8));
			GameObject person = Instantiate (Person, spawnPosition, Quaternion.identity) as GameObject;
			timer = 0.0f;
		}
	}
}
