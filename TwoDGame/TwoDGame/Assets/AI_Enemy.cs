using UnityEngine;
using System.Collections;

public class AI_Enemy : MonoBehaviour {

	public Transform[] WayPoints;
	public Transform currentWp;
	public int wpIndex = 0;
	public float distance = 0.0f;
	public float MoveSpeed = 5.0f;

	public GameObject Blood;
	public GameObject Brains;

	public bool isDead = false;
	public Animation EnemyAnim;
	public GameObject Axe;

	void Start () {
		currentWp = WayPoints [0];
	}
	
	void Update () {
		if (!isDead) {
			distance = Vector3.Distance (transform.position, WayPoints [wpIndex].position);
			if (distance < 1) {
				wpIndex++;
				if (wpIndex < WayPoints.Length) {
					currentWp = WayPoints [wpIndex];
				} else {
					wpIndex = 0;
					currentWp = WayPoints [wpIndex];
				}
			}

			transform.LookAt (WayPoints [wpIndex]);
			transform.position += transform.forward * MoveSpeed * Time.deltaTime;
		}
		//transform.Translate ((WayPoints [wpIndex].position - transform.position).normalized * MoveSpeed * Time.deltaTime);
	}

	void Die(){
		isDead = true;
		Axe.SetActive (false);
		GetComponent<Collider> ().enabled = false;
		//EnemyAnim.Play ("death03");
		GameObject blood = Instantiate (Blood, transform.position, Quaternion.identity) as GameObject;
		GameObject brain = Instantiate (Brains, transform.position, Quaternion.identity) as GameObject;

		EnemyAnim.gameObject.SetActive(false);
	}
}
