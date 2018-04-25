using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class counter : MonoBehaviour {

    public int red;
    public int blue;
    public int yellow;
    public int green;
    public int wave;
    public int points;
    public int turtles;
    public bool spawning;


    // Use this for initialization
    void Start () {
        red = 0;
        blue = 0;
        yellow = 0;
        green = 0;
        wave = 1;
        points = 0;
        spawning = true;
        turtles = 9;
    }
	
	// Update is called once per frame
	void Update () {
		if ((red <= 0)&&(blue <= 0)&&(green <= 0)&&(yellow <= 0)&&(spawning  == false))
        {
            wave = wave + 1;
            spawning = true;

            if (wave % 2 == 1)
                turtles = 9 * (wave);
            else//odd number wave
                turtles = 9 * wave + 4;
            //1 = 1
            //2 = 1.5
            //3 = 2
            //4 = 2.5
            //5 = 3
        }
        if (spawning == true && turtles <= 0)
        {
            spawning = false;
        }

	}
}
