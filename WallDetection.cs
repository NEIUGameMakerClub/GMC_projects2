using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetection : MonoBehaviour
{
    public GameObject Character;
    public int side;

    void OnTriggerStay(Collider other)
    {
        GameObject target = other.gameObject;

        if (Character.name == "Player")
        {
            if (target.name == "wall")
            {
                move playerScript = Character.GetComponent<move>();

                if (side == 1)
                {
                    playerScript.northFree = false;
                }
                if (side == 2)
                {
                    playerScript.eastFree = false;
                }
                if (side == 3)
                {
                    playerScript.southFree = false;
                }
                if (side == 4)
                {
                    playerScript.westFree = false;
                }
            }
        }
        else//Character.name != player (i.e. this is an enemy)
        {
            if (target.name == "wall" || target.name == "invisableFence")
            {
                wander enemyScript = Character.GetComponent<wander>();
                if (enemyScript != null)
                {
                    //Debug.Log("hitting the wall");

                    if (side == 1)
                    {
                        enemyScript.northFree = false;
                    }
                    if (side == 2)
                    {
                        enemyScript.eastFree = false;
                    }
                    if (side == 3)
                    {
                        enemyScript.southFree = false;
                    }
                    if (side == 4)
                    {
                        enemyScript.westFree = false;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject target = other.gameObject;

        if (Character.name == "Player")
        {

            if (target.name == "wall")
            {
                move playerScript = Character.GetComponent<move>();

                if (side == 1)
                {
                    playerScript.northFree = true;
                }
                if (side == 2)
                {
                    playerScript.eastFree = true;
                }
                if (side == 3)
                {
                    playerScript.southFree = true;
                }
                if (side == 4)
                {
                    playerScript.westFree = true;
                }
            }
        }
        else//Character.name != player (i.e. this is an enemy)
        {
            if (target.name == "wall" || target.name == "invisableFence")
            {
                wander enemyScript = Character.GetComponent<wander>();
                if (enemyScript != null)
                {
                    //Debug.Log("hitting the wall");

                    if (side == 1)
                    {
                        enemyScript.northFree = true;
                    }
                    if (side == 2)
                    {
                        enemyScript.eastFree = true;
                    }
                    if (side == 3)
                    {
                        enemyScript.southFree = true;
                    }
                    if (side == 4)
                    {
                        enemyScript.westFree = true;
                    }
                }
            }
        }
    }
}