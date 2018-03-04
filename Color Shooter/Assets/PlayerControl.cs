using UnityEngine;

public class PlayerControl: MonoBehaviour
{
	public GameObject mainCamera;
	public float rotationSpeed;
	public float movementSpeed;

	public float maxUpRotation = -70;
	public float maxDownRotation = 70;
	private float rotX = 0.0f;

	void Start(){
		Vector3 rot = mainCamera.transform.localRotation.eulerAngles;
		rotX = rot.x;
	}
	void FixedUpdate()
	{
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


	}
}