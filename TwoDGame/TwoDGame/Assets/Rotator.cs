using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public float RotateSpeed = 3f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0f, RotateSpeed, 0f);
	}
}
