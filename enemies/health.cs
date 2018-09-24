using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour {

	public int HP;

    public int xScreen;
    public int yScreen;

    public GameObject Player;
    public GameObject Room;
    
    private void Start()
    {
        Player = GameObject.Find("Player");
        //Debug.Log(xScreen + " " + yScreen);
    }

    
    void Update () {

        move playerScript = Player.GetComponent<move>();
        spawnEnemiesInRoom levelScript = Room.GetComponent<spawnEnemiesInRoom>();

        if (HP <= 0) {
            if (levelScript.enemiesLeft == 1)
                levelScript.roomFinnished = true;
            //there is more then 1 enemy left.
            levelScript.enemiesLeft--;
            Destroy (gameObject);
		}

        if ((playerScript.xScreen != xScreen || playerScript.yScreen != yScreen) && (xScreen != 0 && yScreen != 0))
        {
            Destroy(gameObject);
        }
	}
}
