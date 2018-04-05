using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

    public float duration = 1;

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
        transform.localScale += new Vector3(0.05F, 0.05f, 0.05f);
        //increment size
        if (duration <= 0)
            Destroy(gameObject);
    }

    void OnTriggerStay(Collider other)
    {
        GameObject target = other.gameObject;

        Color playerScript = target.GetComponent<Color>();
        if (playerScript != null)
        {

            if (charaType == playerScript.charaType)
            {//found another thing
                //increment score
                Destroy(target);
                explodeMore(charaType);
            }
        }
    }

    public void explodeMore(int a)
    {
        if (a == 1)
        {
            GameObject redExplosion = Instantiate(prefaba) as GameObject;
            redExplosion.transform.position = transform.position;
        }
        else if (a == 2)
        {
            GameObject blueExplosion = Instantiate(prefabb) as GameObject;
            blueExplosion.transform.position = transform.position;
        }
        else if (a == 3)
        {
            GameObject yellowExplosion = Instantiate(prefabc) as GameObject;
            yellowExplosion.transform.position = transform.position;
        }
        else if (a == 4)
        {
            GameObject greenExplosion = Instantiate(prefabd) as GameObject;
            greenExplosion.transform.position = transform.position;
        }
        else if (a == 5)
        {
            GameObject grayExplosion = Instantiate(prefabe) as GameObject;
            grayExplosion.transform.position = transform.position;
        }
    }
}
