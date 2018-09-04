using UnityEngine;
using System.Collections;

public class spinningpickup : MonoBehaviour 
{
	void Start () {
		transform.eulerAngles = new Vector3(
			transform.eulerAngles.x + Random.Range(-20.0F, 20.0F) ,
			transform.eulerAngles.y + Random.Range(-20.0F, 20.0F) ,
			transform.eulerAngles.z + Random.Range(-20.0F, 20.0F)
			);
		
	}
	
	public float speed = 100;
	
	void Update () 
	{
		transform.Rotate (Vector3.up, speed * Time.deltaTime);
		transform.Rotate (Vector3.left, speed * Time.deltaTime / 8);


		
	}
}