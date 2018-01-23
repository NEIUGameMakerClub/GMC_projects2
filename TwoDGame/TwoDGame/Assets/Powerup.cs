using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	public Transform PowerUpMesh;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		PowerUpMesh.Rotate (0, 2, 0);
	}
}
