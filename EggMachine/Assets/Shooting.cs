using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {


    public int weaponSelect = 0;

    public float shotSpeed = 20f;




    public float reloadTime = .5f;

    GameObject prefab0;
    
    GameObject prefab1;
    GameObject prefab2;
    GameObject prefab3;
    GameObject prefab4;

    Renderer m_Renderer;

    // Use this for initialization
    void Start () {
        prefab0 = Resources.Load("Empty") as GameObject;
        
        prefab1 = Resources.Load("red") as GameObject;
        prefab2 = Resources.Load("blue") as GameObject;
        prefab3 = Resources.Load("yellow") as GameObject;
        prefab4 = Resources.Load("green") as GameObject;

        m_Renderer = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update() {

        //testing
        bool change1 = Input.GetButtonDown("1");
        bool change2 = Input.GetButtonDown("2");

        if (weaponSelect == 0)
            m_Renderer.material.color = Color.white;
        if (weaponSelect == 1)
            m_Renderer.material.color = Color.red;
        if (weaponSelect == 2)
            m_Renderer.material.color = Color.blue;
        if (weaponSelect == 3)
            m_Renderer.material.color = Color.yellow;
        if (weaponSelect == 4)
            m_Renderer.material.color = Color.green;

        if (change1)
        {
            if (weaponSelect == 0)
                weaponSelect = 4;
            else
                weaponSelect = (weaponSelect - 1);
        }
        if (change2)
        {
            if (weaponSelect == 4)
                weaponSelect = 0;
            else
                weaponSelect = (weaponSelect + 1);
        }


        reloadTime += Time.deltaTime;


        if (Input.GetMouseButtonDown(0))
        {

            //empty
            if ((weaponSelect == 0) && (reloadTime >= .5))
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
