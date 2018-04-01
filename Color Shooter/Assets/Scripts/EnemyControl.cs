using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {
	public float movementSpeed = 5f;
	public int member;
	private GameObject target = null;
	private GameObject spawn = null;

	void Start(){
		target = GameObject.FindWithTag ("Player");
		spawn = GameObject.FindWithTag ("GameController");
		member = Random.Range (1, 5);
		if (member == 1)
			GetComponent<Renderer>().material.color = Color.red;
		if (member == 2)
			GetComponent<Renderer>().material.color = Color.green;
		if (member == 3)
			GetComponent<Renderer>().material.color = Color.blue;
		if (member == 4)
			GetComponent<Renderer>().material.color = Color.yellow;
		if (member == 5)
			GetComponent<Renderer>().material.color = Color.black;

	}

	void Update(){
		float step = movementSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.transform.position, step);


	}

	public void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Enemy"){
			if(other.gameObject.GetComponent<EnemyControl>().member == member){
				Collider[] colliders = Physics.OverlapSphere(transform.position, 30f);
				foreach (Collider hit in colliders)
				{
					Rigidbody rb = hit.GetComponent<Rigidbody>();

					if (rb != null)
						rb.AddExplosionForce(500f, transform.position, 30f, 3.0F);
				}
				spawn.GetComponent<SpawnEnemy> ().current--;
				//spawn.GetComponent<SpawnEnemy> ().current--;
				Destroy (other.gameObject);
				Destroy (this);
			}
		}
	}


}
