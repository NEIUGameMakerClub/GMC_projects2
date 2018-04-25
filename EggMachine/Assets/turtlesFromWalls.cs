using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtlesFromWalls : MonoBehaviour
{


    public GameObject walls = null;

    GameObject prefab1;
    GameObject prefab2;
    GameObject prefab3;
    GameObject prefab4;
    int color;
    float waveTime = 1f;


    // Use this for initialization
    void Start()
    {
        prefab1 = Resources.Load("Red Turtle") as GameObject;
        prefab2 = Resources.Load("Blue Turtle") as GameObject;
        prefab3 = Resources.Load("Yellow Turtle") as GameObject;
        prefab4 = Resources.Load("Green Turtle") as GameObject;

        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        walls = GameObject.Find("Plane");
        counter playerScript = walls.GetComponent<counter>();

        if (playerScript.spawning)
        {
        */
            waveTime -= Time.deltaTime;
            if (waveTime <= 0)
            {
                waveTime = 10f;
                color = getRandomValue();
                if (color == 1)
                {
                    //spawn red turtle
                    GameObject red = Instantiate(prefab1) as GameObject;
                    red.transform.position = transform.position;
                    //playerScript.turtles--;
                    //playerScript.red++;
                }
                else if (color == 2)
                {
                    //spawn blue turtle
                    GameObject blue = Instantiate(prefab2) as GameObject;
                    blue.transform.position = transform.position;
                    //playerScript.turtles--;
                    //playerScript.blue++;
                }
                else if (color == 3)
                {
                    //spawn yellow turtle
                    GameObject yellow = Instantiate(prefab3) as GameObject;
                    yellow.transform.position = transform.position;
                    //playerScript.turtles--;
                    //playerScript.yellow++;
                }

                else if (color == 4)
                {
                    //spawn green turtle
                    GameObject green = Instantiate(prefab4) as GameObject;
                    green.transform.position = transform.position;
                    //playerScript.turtles--;
                    //playerScript.green++;
                }
            }
        //}
    }

    int getRandomValue()
    {
        return Random.Range(1, 5);
    }
}
