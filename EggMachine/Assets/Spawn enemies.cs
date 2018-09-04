using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnenemies : MonoBehaviour {

    GameObject prefab1;
    GameObject prefab2;
    GameObject prefab3;
    GameObject prefab4;

    int a;//turtle color randomizer
    float timer = 2f;

    // Use this for initialization
    void Start () {
        prefab1 = Resources.Load("Red Turtle") as GameObject;
        prefab2 = Resources.Load("Blue Turtle") as GameObject;
        prefab3 = Resources.Load("Yellow Turtle") as GameObject;
        prefab4 = Resources.Load("Green Turtle") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {

            a = Random.Range(1, 4);
            timer = 1f;
            if (a == 1)
            {
                //spawn red turtle
                GameObject red = Instantiate(prefab1) as GameObject;
                //red.transform.position = transform.position;
            }
            else if (a == 2)
            {
                //spawn blue turtle
                GameObject blue = Instantiate(prefab2) as GameObject;
                //blue.transform.position = transform.position;
            }
            else if (a == 3)
            {
                //spawn yellow turtle
                GameObject yellow = Instantiate(prefab3) as GameObject;
                //yellow.transform.position = transform.position;
            }

            else if (a == 4)
            {
                //spawn green turtle
                GameObject green = Instantiate(prefab4) as GameObject;
                //green.transform.position = transform.position;
            }
        }
    }
}
