using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls : MonoBehaviour
{


    public float xSensitivity = 100.0f;
    private float rotationx = 0.0f;

    public float playerSpeed = 3;

    public float yMovement;
    public float xMovement;
    public float zMovement;

    //private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotationx = rotation.x;
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X");
        rotationx += mouseX * xSensitivity * Time.deltaTime;

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

        Quaternion localRotation = Quaternion.Euler(0.0f, rotationX, 0.0f);
        transform.rotation = localRotation;

        transform.Translate(xMovement * Time.deltaTime * playerSpeed, yMovement, zMovement * Time.deltaTime * playerSpeed);
    }
}
