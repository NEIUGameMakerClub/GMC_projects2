using UnityEngine;
using System.Collections;

public class Alien : MonoBehaviour {

	public float MoveSpeed = 5f;
	public GameObject AlienObject;
	public GameObject Explosion;
	public AudioSource ASAlien;

	void Start () {
	
	}
	
	void Update () {
		transform.position += transform.forward * MoveSpeed * Time.deltaTime;
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Laser") {
			AlienObject.SetActive (false);
			GameObject explosion = Instantiate (Explosion, transform.position, Quaternion.identity) as GameObject;
			GetComponent<Collider> ().enabled = false;
			ASAlien.Play ();
			Destroy (gameObject, 0.5f);
		}
	}
}
