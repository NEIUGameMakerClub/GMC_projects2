using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour {

	public float range = 40f;
	public float force = 2000f;
	public float holdrange;

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

					//Makes the grabbed object transparent
					//had to change shader to legacy Transparent/Diffuse
					var grabcolor = hit.collider.gameObject.GetComponent<Renderer>().material.color;
					var newColor = new Color(grabcolor.r, grabcolor.g, grabcolor.b, 0.5f);
					hit.collider.gameObject.GetComponent<Renderer>().material.color = newColor;

					hit.collider.gameObject.transform.position= transform.position + (transform.forward*holdrange) + (transform.up*holdrange); 
					//pickedUpObject.GetComponent<Rigidbody>().isKinematic = true;
				}
			}
		} else { //i think a regular else statement is fine
			if (pickedUpObject != null) {
				//horrible hack i have no idea how assignment works
				var origColor = pickedUpObject.GetComponent<Renderer> ().material.color;
				pickedUpObject.GetComponent<Renderer> ().material.color = new Color(origColor.r, origColor.g, origColor.b, 1);

				pickedUpObject.transform.parent = null; 
				pickedUpObject.GetComponent<Rigidbody> ().AddForce(transform.forward * force, ForceMode.VelocityChange);
				//pickedUpObject.GetComponent<Rigidbody>().isKinematic = false;
				pickedUpObject = null;
			}
		}
	}
}
