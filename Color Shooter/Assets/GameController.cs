using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject player;
	public GameObject enemy;
	public float rate;
	public int max;

	private int current;
	private int score;
	private float timer;
	private Component scoreBoard;

	// Use this for initialization
	void Start () {
		player = Instantiate (player, new Vector3 (0, 1, 0),new Quaternion(0,0,0,0));
		scoreBoard = GetComponentInChildren<Text> ();
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

	public void EnemyDeath(){
		current--;
		score++;
	}
}
