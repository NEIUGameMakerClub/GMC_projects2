using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePlayer : MonoBehaviour {

    public int damage;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            move playerScript = other.GetComponent<move>();
            if (playerScript.invincibilityFrames <= 0)
            {
                playerScript.health -= damage;
                playerScript.invincibilityFrames = 1f;
            }
        }
    }

}
