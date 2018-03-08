using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {


    public GameObject target = null;
    public float homingSpeed = 3f;

    // Use this for initialization
    void Start () {
        target = GameObject.Find("Player");
	}
	

        void Update() { 

            
                transform.LookAt(target.transform);
                Rigidbody rb = gameObject.GetComponent<Rigidbody>();
                rb.velocity = transform.forward * homingSpeed;
            
        }

}
