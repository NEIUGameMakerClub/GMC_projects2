using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

	public float playerSpeed = 3;

	public float yMovement;
	public float xMovement;
	public float zMovement;



	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{


		//bool spaceHeld = Input.GetButton("Space");
		bool rightHeld = Input.GetButton("right");
		bool leftHeld = Input.GetButton("left");
		bool upHeld = Input.GetButton("up");
		bool downHeld = Input.GetButton("down");




		if (rightHeld)
		{
			if (leftHeld)
				xMovement = 0.0f;
			else
				xMovement = 1.0f;
		}
		else
		{
			if (leftHeld)
				xMovement = -1.0f;
			else
				xMovement = 0.0f;
		}

		if (downHeld)
		{
			if (upHeld)
				zMovement = 0.0f;
			else
				zMovement = -1.0f;
		}
		else
		{
			if (upHeld)
				zMovement = 1.0f;
			else
				zMovement = 0.0f;
		}


		transform.Translate(xMovement * Time.deltaTime * playerSpeed, yMovement, zMovement * Time.deltaTime * playerSpeed);

	}
}
