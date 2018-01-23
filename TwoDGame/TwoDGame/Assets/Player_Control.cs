using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player_Control : MonoBehaviour {

	public float Health;
	public Slider HealthBar;
	public float ReduceSpeed = 1.0f;

	public float RunSpeed = 10f;
	public float JumpSpeed = 10f;
	public float gravity = 9.8f;

	public Transform Character;
	public Animation CharacterAnim;

	private CharacterController controller;

	public bool isDead = false;

	public bool ReadyToBeHit = true;

	void Start () {
		controller = GetComponent<CharacterController> ();

		CharacterAnim ["idle01"].weight = 2;
		CharacterAnim ["run02"].weight = 2;
		CharacterAnim ["death03"].weight = 1;
	}
	
	void Update () {

		HealthBar.value = Health;
		Health -= Time.deltaTime * ReduceSpeed;
		if (!isDead) {
			Move ();
		} else {
			CharacterAnim.Play ("death03");
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {

		if (hit.collider.tag == "Hazard") {
			if (ReadyToBeHit) {
				StartCoroutine (WaitToBeHit ());

				Health -= 60;

				if (Health <= 0) {
					Die ();
				}
			}
		}

		if (hit.collider.tag == "Enemy") {
			hit.collider.gameObject.SendMessage ("Die");
		}

		if (hit.collider.tag == "PowerUp") {
			if (Health < 100) {
				Health += 20;

				if (Health > 100)
					Health = 100;

				hit.collider.gameObject.SetActive (false);
			}
		}
	}

	IEnumerator WaitToBeHit(){
		ReadyToBeHit = false;
		yield return new WaitForSeconds (2f);
		ReadyToBeHit = true;
	}

	void Die(){
		isDead = true;
		CharacterAnim.Stop ("idle01");
		CharacterAnim.Stop ("run02");
		CharacterAnim.Play ("death03");
		Debug.Log ("Zombie Died");
	}

	void Move(){
		float movement = Input.GetAxis ("Horizontal") * RunSpeed;

		if (controller.isGrounded) {
			JumpSpeed = 0;
			if (Input.GetKeyDown (KeyCode.Space)) {
				JumpSpeed = 10;
			}
		} 

		JumpSpeed -= gravity * Time.deltaTime;

		Vector3 characterMovement = new Vector3 (movement, JumpSpeed, 0f);
		controller.Move (characterMovement * Time.deltaTime);

		if (controller.velocity.x > 0) {
			Character.LookAt (new Vector3 (Character.position.x + 3, Character.position.y, Character.position.z));
			CharacterAnim.Play ("run02");

		} else if (controller.velocity.x == 0) {
			CharacterAnim.Play ("idle01");
		}
		else if (controller.velocity.x < 0) {
			Character.LookAt ( new Vector3(Character.position.x - 3, Character.position.y, Character.position.z));
			CharacterAnim.Play ("run02");

		}
	}
}
