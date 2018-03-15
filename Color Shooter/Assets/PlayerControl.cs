using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerControl: MonoBehaviour
{
	public GameObject mainCamera;
	public float rotationSpeed;
	public float movementSpeed;
	public float jumpHeight;
	public float immunityTimer;

	public float maxUpRotation = -70;
	public float maxDownRotation = 70;

	private float timer;
	private bool immunity = false;
	private float rotX = 0.0f;
	private Rigidbody rb;
	private List<GameObject> hearts = new List<GameObject>();
	private int life = 5;
	private GameObject end;

	void Start(){
		Vector3 rot = mainCamera.transform.localRotation.eulerAngles;
		rb = GetComponent<Rigidbody> ();
		GameObject[] temp = FindObjectsOfType<GameObject> ();
		foreach (GameObject heart in temp) {
			if (heart.CompareTag ("Heart")) {
				hearts.Add (heart);
			}
		}
		rotX = rot.x;
	}
	void FixedUpdate()
	{
		if(Input.GetButtonDown("Jump") && transform.position.y <= 2f){
			rb.AddForce (0,jumpHeight,0,ForceMode.Impulse);
		}
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
		float h = rotationSpeed * Input.GetAxis("Mouse X");
		float v = rotationSpeed * -Input.GetAxis("Mouse Y");

		rotX += v;

		rotX = Mathf.Clamp(rotX, maxUpRotation, maxDownRotation);

		Quaternion newRotation = Quaternion.Euler(rotX, 0.0f, 0.0f);
		mainCamera.transform.localRotation = newRotation;
		transform.Rotate(0, h, 0);
		transform.Translate(x, 0, z);
		if (immunity && timer < 0){
			immunity = false;
		}else{
			timer -= Time.deltaTime;
		}


	}

	public void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Enemy"){
			Collider[] colliders = Physics.OverlapSphere(transform.position, 30f);
			foreach (Collider hit in colliders)
			{
				if(hit.tag == "Enemy"){
					Rigidbody rb = hit.GetComponent<Rigidbody>();

					if (rb != null) {
						rb.AddExplosionForce (550f, transform.position, 30f, 1.5F);
					}
				}
			}
			if (life == 0) {
				GameObject music = GameObject.Find ("GameMusic");
				music.SetActive (false);
				transform.GetChild (0).GetChild (0).GetChild (0).transform.Translate (0, -300, 0);
				GetComponentInChildren<Text> ().fontSize = 44;
				Time.timeScale = 0;

			} else {
				if (!immunity) {
					life--;
					Destroy (hearts [life]);
					immunity = true;
					timer = immunityTimer;
				}
			}
		}
	}
}