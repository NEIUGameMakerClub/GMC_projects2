using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stupidColors : MonoBehaviour {

    public int charaType;
    // 1 = red
    // 2 = blue
    // 3 = yellow
    // 4 = green


    public GameObject walls = null;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        GameObject target = other.gameObject;

        Explode playerScript = target.GetComponent<Explode>();

        walls = GameObject.Find("Plane");
        counter wallScript = walls.GetComponent<counter>();

        if (playerScript != null)
        {

            if (charaType == playerScript.charaType)
            {//found another thing
             //increment score

                if (charaType == 1)
                {
                    wallScript.red--;
                }
                else if (charaType == 2)
                {
                    wallScript.blue--;
                }
                else if (charaType == 3)
                {
                    wallScript.yellow--;
                }
                else if (charaType == 4)
                {
                    wallScript.green--;
                }
                /*
                else if (charaType == 5)
                {
                    GameObject grayExplosion = Instantiate(prefabe) as GameObject;
                    grayExplosion.transform.position = target.transform.position;
                }*/
                Destroy(gameObject);
            }
        }
    }
}
