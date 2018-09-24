using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {


    public int health;
    public int maxhealth = 3;
    public float invincibilityFrames;

	public bool paused = false;
	public bool movement = true;
	public float xMovement;
	public float zMovement;
	public float playerspeed = 7.0f;
	public int direction = 3;
	public float attackTime;

    public bool northFree = true;
    public bool eastFree = true;
    public bool southFree = true;
    public bool westFree = true;

    Vector3 pos;

    public int xScreen;
    public int yScreen;
    public bool newScreen = false;

    public GameObject currentScreen;
    GameObject prefab1;//sword

	void Start () 
	{
        health = maxhealth;
        xScreen = 1;
        yScreen = 1;
        currentScreen = GameObject.Find("1,1");
        prefab1 = Resources.Load ("spear") as GameObject;
	}

	// Update is called once per frame
	void Update () {
		bool rightHeld = Input.GetButton ("right");
		bool leftHeld = Input.GetButton ("left");
		bool upHeld = Input.GetButton ("up");
		bool downHeld = Input.GetButton ("down");
		bool z = Input.GetButtonDown ("z");

        if (health <= 0)
            Debug.Log("Game Over");
        if (invincibilityFrames > 0)
            invincibilityFrames -= Time.deltaTime;


		if (paused == false) {

            if (movement)
            {

                if (z)
                {
                    movement = false;
                    attackTime = .25f;
                    GameObject spear = Instantiate(prefab1) as GameObject;
                    spear.transform.position = transform.position + new Vector3(0, -.5f, 0); // try to add the directional bit /*+ Camera.main.transform.forward * 2*/;

                }
                if ((upHeld || downHeld) && transform.position.x % .5f != 0)
                {
                    pos = transform.position;
                    if (transform.position.x % .5f <= .25)//round down
                        pos = pos - new Vector3((transform.position.x % .5f), 0, 0);
                    else// if (transform.position.x % .5f > .25)//round up
                        pos = pos + new Vector3((.5f - transform.position.x % .5f), 0, 0);
                    transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * playerspeed);
                }

                if ((rightHeld || leftHeld) && transform.position.z % .5 != 0)
                {
                    pos = transform.position;
                    if (transform.position.z % .5f <= .25)//round down
                        pos = pos - new Vector3(0, 0, (transform.position.z % .5f));
                    else// if (transform.position.z % .5f > .25)//round up
                        pos = pos + new Vector3(0, 0, (.5f - transform.position.z % .5f));
                    transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * playerspeed);
                }

                if (upHeld && !downHeld && northFree && transform.position.x % .5f == 0)
                {
                    zMovement = 1.0f;
                    direction = 1;
                }
                else if (downHeld && !upHeld && southFree && transform.position.x % .5f == 0)
                {
                    zMovement = -1.0f;
                    direction = 3;
                }
                else
                    zMovement = 0.0f;

                if (rightHeld && !upHeld && !downHeld && !leftHeld && eastFree && transform.position.z % .5 == 0)
                {
                    xMovement = 1.0f;
                    direction = 2;
                }
                else if (leftHeld && !upHeld && !downHeld && !rightHeld && westFree && transform.position.z % .5 == 0)
                {
                    xMovement = -1.0f;
                    direction = 4;
                }
                else
                xMovement = 0.0f;


                if (upHeld && !downHeld)
                    direction = 1;
                else if (downHeld && !upHeld)
                    direction = 3;
                else if (rightHeld && !upHeld && !downHeld && !leftHeld)
                    direction = 2;
                else if (leftHeld && !upHeld && !downHeld && !rightHeld)
                    direction = 4;

			} else {//currently attacking
				xMovement = 0.0f;
				zMovement = 0.0f;
				attackTime = attackTime - Time.deltaTime;
				if (attackTime < 0)
					movement = true;
			}
            
			Vector3 speed = new Vector3 (xMovement * playerspeed, 0, zMovement * playerspeed);
			transform.Translate (speed * Time.deltaTime);


            if (newScreen)
            {
                if (xScreen == 1)
                {
                    if (yScreen == 1)
                        currentScreen = GameObject.Find("1,1");
                    if (yScreen == 2)
                        currentScreen = GameObject.Find("1,2");
                    if (yScreen == 3)
                        currentScreen = GameObject.Find("1,3");
                }
                else if (xScreen == 2)
                {
                    if (yScreen == 1)
                        currentScreen = GameObject.Find("2,1");
                    if (yScreen == 2)
                        currentScreen = GameObject.Find("2,2");
                    if (yScreen == 3)
                        currentScreen = GameObject.Find("2,3");
                }
                else if (xScreen == 3)
                {
                    if (yScreen == 1)
                        currentScreen = GameObject.Find("3,1");
                    if (yScreen == 2)
                        currentScreen = GameObject.Find("3,2");
                    if (yScreen == 3)
                        currentScreen = GameObject.Find("3,3");
                }

                spawnEnemiesInRoom levelScript = currentScreen.GetComponent<spawnEnemiesInRoom>();
                if (!levelScript.roomFinnished)
                    levelScript.Spawn();
                newScreen = false;
            }

		}
	}
}