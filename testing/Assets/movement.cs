using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	//2
	public float MoveSpeed = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//2
		Move ();
	}

	/*Code for lesson 2
	void Move (){
		float movementZ = Input.GetAxis ("Vertical") * MoveSpeed * Time.deltaTime;
		float movementX = Input.GetAxis ("Horizontal") * MoveSpeed * Time.deltaTime;

		//reffers to the thing we attach to
		transform.position += transform.forward * movementZ;
		transform.position += transform.right * movementX;

	


	}
	*/

	//Code for lesson 3
	float movementZ = Input.GetAxis ("Vertical") * MoveSpeed * Time.deltaTime;
	float movementX = Input.GetAxis ("Horizontal") * MoveSpeed * Time.deltaTime;

	Vector3 direction = new Vector3
}
