using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float MoveSpeed = 5f;
	public Transform Cannon; 
	public Rigidbody LaserBeam;
	public AudioSource ASLaser;

	void Start () {
		ASLaser = GetComponent<AudioSource> ();
	}
	
	void Update () {

		Move ();
		Shoot ();
	}

	void Move(){
		float movement = Input.GetAxis ("Horizontal") * MoveSpeed * Time.deltaTime;
		float posX = Mathf.Clamp (transform.position.x, -2, 2);

		transform.position += transform.right * movement; 
		//transform.position = new Vector3 (posX, transform.position.y, transform.position.z);
	}

	void Shoot(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			Rigidbody beam = Instantiate (LaserBeam, Cannon.position, Cannon.rotation) as Rigidbody;
			beam.AddForce (beam.transform.forward * 100f);
			ASLaser.Play ();
		}
	}
}
