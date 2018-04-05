using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float ySensitivity = 100.0f;
    public float clampAngle = 80.0f;
    public float xSensitivity = 100.0f;


    private float rotX = 0.0f;
    private float rotY = 0.0f; // rotation around the up/y axis

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotX = rot.x;
        rotY = rot.y;
    }

    void Update()
    {
        float mouseY = -Input.GetAxis("Mouse Y");
        rotY += mouseY * ySensitivity * Time.deltaTime;

        float mouseX = Input.GetAxis("Mouse X");
        rotX += mouseX * xSensitivity * Time.deltaTime;

        rotY = Mathf.Clamp(rotY, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotY, rotX, 0.0f);
        transform.rotation = localRotation;
    }
}
