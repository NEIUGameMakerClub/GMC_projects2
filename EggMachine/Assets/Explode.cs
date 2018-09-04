using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

    public float duration = .5f;
    public int charaType;
    // 1 = red
    // 2 = blue
    // 3 = yellow
    // 4 = green

    GameObject prefaba;
    GameObject prefabb;
    GameObject prefabc;
    GameObject prefabd;
    GameObject prefabe;

    void Start() {
        prefaba = Resources.Load("Red Explosion") as GameObject;
        prefabb = Resources.Load("Blue Explosion") as GameObject;
        prefabc = Resources.Load("Yellow Explosion") as GameObject;
        prefabd = Resources.Load("Green Explosion") as GameObject;
        prefabe = Resources.Load("Gray Explosion") as GameObject;
    }

    void Update() {
        duration -= Time.deltaTime;
        //transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
        
        if (duration <= 0)
            Destroy(gameObject);
    }

    void OnTriggerStay(Collider other)
    {
        GameObject target = other.gameObject;

        stupidColors playerScript = target.GetComponent<stupidColors>();

        if (playerScript != null)
        {

            if (charaType == playerScript.charaType)
            {//found another thing
                //increment score
                
                if (charaType == 1)
                {
                    GameObject redExplosion = Instantiate(prefaba) as GameObject;
                    redExplosion.transform.position = target.transform.position;
                }
                else if (charaType == 2)
                {
                    GameObject blueExplosion = Instantiate(prefabb) as GameObject;
                    blueExplosion.transform.position = target.transform.position;
                }
                else if (charaType == 3)
                {
                    GameObject yellowExplosion = Instantiate(prefabc) as GameObject;
                    yellowExplosion.transform.position = target.transform.position;
                }
                else if (charaType == 4)
                {
                    GameObject greenExplosion = Instantiate(prefabd) as GameObject;
                    greenExplosion.transform.position = target.transform.position;
                }
                else if (charaType == 5)
                {
                    GameObject grayExplosion = Instantiate(prefabe) as GameObject;
                    grayExplosion.transform.position = target.transform.position;
                }
            }
        }
    }
}
