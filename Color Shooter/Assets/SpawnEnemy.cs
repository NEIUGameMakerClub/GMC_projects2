using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour {

	public GameObject enemy;
	public float rate;
	public int max;
	public int current;
	public int score;
	private float timer;
	private GameObject scoreBoard;

	// Use this for initialization
	void Start () {
		scoreBoard = GameObject.FindWithTag ("ScoreBoard");
		current = 0;
		score = 0;
		timer = rate;
		Cursor.visible = false;
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
	void FixedUpdate(){
		scoreBoard.GetComponent<Text> ().text = score.ToString ();
	}
}
