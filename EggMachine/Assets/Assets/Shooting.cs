using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {


    public int weaponSelect = 0;

    public float shotSpeed = 20f;


    

    public float reloadTime = 5f;

    GameObject prefab0;
    
    GameObject prefab1;
    GameObject prefab2;
    GameObject prefab3;
    GameObject prefab4;
    


    // Use this for initialization
    void Start () {
        prefab0 = Resources.Load("Empty") as GameObject;
        
        prefab1 = Resources.Load("red") as GameObject;
        prefab2 = Resources.Load("blue") as GameObject;
        prefab3 = Resources.Load("yellow") as GameObject;
        prefab4 = Resources.Load("green") as GameObject;
        
    }

    // Update is called once per frame
    void Update() {

        //testing
        bool change1 = Input.GetButtonDown("1");
        bool change2 = Input.GetButtonDown("2");


        if (change1)
            weaponSelect = (weaponSelect - 1) % 5;
        if (change2)
        {
            weaponSelect = (weaponSelect + 1);
            if (weaponSelect == -1)
                weaponSelect = 4;
        }


        reloadTime += Time.deltaTime;


        if (Input.GetMouseButtonDown(0))
        {

            //empty
            if ((weaponSelect == 0) && (reloadTime >= 2))
            {

                GameObject Empty = Instantiate(prefab0) as GameObject;
                Empty.transform.position = transform.position + Camera.main.transform.forward * 2;
                Rigidbody rb = Empty.GetComponent<Rigidbody>();
                rb.velocity = transform.up * shotSpeed;// need to add the 90 degrees;
            }


            //red
            if (weaponSelect == 1)
            {
                GameObject red = Instantiate(prefab1) as GameObject;
                red.transform.position = transform.position + Camera.main.transform.forward * 2;
                Rigidbody rb = red.GetComponent<Rigidbody>();
                rb.velocity = transform.up * shotSpeed;
                weaponSelect = 0;
                reloadTime = 0;
            }


            //blue
            if (weaponSelect == 2)
            {
                GameObject blue = Instantiate(prefab2) as GameObject;
                blue.transform.position = transform.position + Camera.main.transform.forward * 2;
                Rigidbody rb = blue.GetComponent<Rigidbody>();
                rb.velocity = transform.up * shotSpeed;
                weaponSelect = 0;
                reloadTime = 0;
            }


            //yellow
            if (weaponSelect == 3)
            {
                GameObject yellow = Instantiate(prefab3) as GameObject;
                yellow.transform.position = transform.position + Camera.main.transform.forward * 2;
                Rigidbody rb = yellow.GetComponent<Rigidbody>();
                rb.velocity = transform.up * shotSpeed;
                weaponSelect = 0;
                reloadTime = 0;
            }


            //green
            if (weaponSelect == 4)
            {
                GameObject green = Instantiate(prefab4) as GameObject;
                green.transform.position = transform.position + Camera.main.transform.forward * 2;
                Rigidbody rb = green.GetComponent<Rigidbody>();
                rb.velocity = transform.up * shotSpeed;
                weaponSelect = 0;
                reloadTime = 0;
            }

    
        }

    }
}
