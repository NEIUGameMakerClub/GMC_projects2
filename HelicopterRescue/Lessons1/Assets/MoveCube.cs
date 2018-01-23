using UnityEngine;
using System.Collections;

public class MoveCube : MonoBehaviour {


	public float MoveSpeed = 5.0f;
	public float RotationSpeed = 3.0f;
	public bool isNotDestroyed = false;

	void Start () {
	
	}
	
	void Update () {

		if (isNotDestroyed) {
			//float movementVertical = Input.GetAxis ("Vertical") * MoveSpeed * Time.deltaTime; 
			//transform.position += transform.up * movementVertical;

			float movementHorizontal = Input.GetAxis ("Horizontal") * MoveSpeed * Time.deltaTime;
			transform.position += transform.right * movementHorizontal;

			float rotateHorizontal = Input.GetAxis ("Mouse X") * RotationSpeed * Time.deltaTime;
			transform.Rotate (0, rotateHorizontal, 0);

			float movementForward = Input.GetAxis ("Mouse Y") * MoveSpeed * Time.deltaTime;
			transform.position += transform.forward * movementForward;

			Debug.Log (Time.deltaTime);
		} else {
			transform.position += transform.up * -1;
		}
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Water") {
			isNotDestroyed = false;
		}
	}
}
