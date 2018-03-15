using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour {

	public float range;
	public float force;
	public float lift;
	public float holdRange;


	private RaycastHit hit;
	private GameObject pickedUpObject = null;

	void Start () {

	}

	void Update () {

		if(Input.GetButton ("Fire1")){

			if(Physics.Raycast(transform.position, transform.forward, out hit , range)){

				if(hit.collider.gameObject.tag=="Enemy"){ //add collider reference otherwise you can't access gameObject!

					pickedUpObject = hit.collider.gameObject; 
					hit.collider.gameObject.transform.parent= transform; 
					hit.collider.gameObject.transform.position=transform.position + (transform.forward * holdRange); 
					//pickedUpObject.GetComponent<Rigidbody>().isKinematic = true;
				}
			}
		} else { //i think a regular else statement is fine
			if (pickedUpObject != null) {
				pickedUpObject.transform.parent = null; 
				pickedUpObject.GetComponent<Rigidbody> ().AddForce((transform.forward * force)+(transform.up * lift), ForceMode.VelocityChange);
				//pickedUpObject.GetComponent<Rigidbody>().isKinematic = false;
				pickedUpObject = null;
			}
		}
	}
}
