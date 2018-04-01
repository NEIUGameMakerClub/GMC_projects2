using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

	public GameObject enemy;
	public float rate;
	public int max;
	public int current;
	private float timer;

	// Use this for initialization
	void Start () {
		current = 0;
		timer = rate;
	}
	
	// Update is called once per frame
	void Update () {
		timer = timer - Time.deltaTime;
		if(timer <= 0 && current < max){
			Instantiate (enemy, new Vector3(Random.Range (-80, 81), 10, Random.Range (-80, 81)), new Quaternion(0,0,0,0));
			timer = rate;
			current++;
		}
	}
}
