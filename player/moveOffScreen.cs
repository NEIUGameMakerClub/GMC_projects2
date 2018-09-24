using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOffScreen : MonoBehaviour {

    public GameObject Player;
    public GameObject Camera;
    
    void Start () {
        Player = GameObject.Find("Player");
        Camera = GameObject.Find("Main Camera");
    }

    void OnTriggerStay(Collider other)
    {
        GameObject target = other.gameObject;

        if (target.name == "MovementWallNorth" || target.name == "MovementWallEast" || target.name == "MovementWallSouth" || target.name == "MovementWallWest")
        {
            if (target.name == "MovementWallNorth")
            {
                moveCamera levelScript = Camera.GetComponent<moveCamera>();
                levelScript.movingDirection = 1;
            }
            else if (target.name == "MovementWallEast")
            {
                moveCamera levelScript = Camera.GetComponent<moveCamera>();
                levelScript.movingDirection = 2;
            }
            else if (target.name == "MovementWallSouth")
            {
                moveCamera levelScript = Camera.GetComponent<moveCamera>();
                levelScript.movingDirection = 3;
            }
            else// (target.name == "MovementWallWest")
            {
                moveCamera levelScript = Camera.GetComponent<moveCamera>();
                levelScript.movingDirection = 4;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        GameObject target = other.gameObject;

        if (target.name == "MovementWallNorth" || target.name == "MovementWallEast" || target.name == "MovementWallSouth" || target.name == "MovementWallWest")
        {
            moveCamera levelScript = Camera.GetComponent<moveCamera>();
            levelScript.movingDirection = 0;
        }
    }
}
