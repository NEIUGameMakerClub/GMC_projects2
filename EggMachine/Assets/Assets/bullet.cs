using UnityEngine;
using System.Collections;

public class bullet: MonoBehaviour
{

    public float duration = 3f;
    public int shotType;
    //gets rid of friendly fire


    GameObject prefab1;
    GameObject prefab2;
    GameObject prefab3;
    GameObject prefab4;
    GameObject prefaba;
    GameObject prefabb;
    GameObject prefabc;
    GameObject prefabd;
    GameObject Gun;


    void Start()
    {
        prefab1 = Resources.Load("Red Turtle") as GameObject;
        prefab2 = Resources.Load("Blue Turtle") as GameObject;
        prefab3 = Resources.Load("Yellow Turtle") as GameObject;
        prefab4 = Resources.Load("Green Turtle") as GameObject;
        prefaba = Resources.Load("Red Explosion") as GameObject;
        prefabb = Resources.Load("Blue Explosion") as GameObject;
        prefabc = Resources.Load("Yellow Explosion") as GameObject;
        prefabd = Resources.Load("Green Explosion") as GameObject;

        Gun = GameObject.Find("Gun");
        

    }

    private void Update()
    {
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            if (shotType == 0)
                Destroy(gameObject);
            else
                SpawnTurtle(shotType);
        }
    }

    //public bool HasParrentObject = false;

    void OnCollisionEnter(Collision other)
    {
        GameObject target = other.gameObject;

        Color playerScript = target.GetComponent<Color>();
        Shooting shootScript = Gun.GetComponent<Shooting>(); 
/*
        if (playerScript != null)
            playerScript.HP -= damage;
            */


        if (playerScript != null)//bullet hits other turtle
        {

            if (shotType == playerScript.charaType)//colors match
            {
                //Destroy(target);
                //activate explode.exe
                explode(shotType);

                Destroy(gameObject);
            }
            else//colors dont match
            {
                if (shotType == 0)
                {
                    shootScript.weaponSelect = playerScript.charaType;
                    Destroy(target);
                    //set parent object to playerScript.charaType
                    Destroy(gameObject);
                }
                else
                {
                    SpawnTurtle(shotType);
                }
            }
        }
        else//turtle hits wall
        {
            SpawnTurtle(shotType);
        }
    }

    public void SpawnTurtle(int a)
    {
        if (a == 1)
        {
            //spawn red turtle
            GameObject red = Instantiate(prefab1) as GameObject;
            red.transform.position = transform.position;
            Destroy(gameObject);
        }
        else if (a == 2)
        {
            //spawn blue turtle
            GameObject blue = Instantiate(prefab2) as GameObject;
            blue.transform.position = transform.position;
            Destroy(gameObject);
        }
        else if (a == 3)
        {
            //spawn yellow turtle
            GameObject yellow = Instantiate(prefab3) as GameObject;
            yellow.transform.position = transform.position;
            Destroy(gameObject);
        }

        else if (a == 4)
        {
            //spawn green turtle
            GameObject green = Instantiate(prefab4) as GameObject;
            green.transform.position = transform.position;
            Destroy(gameObject);
        }
    }

    public void explode(int a)
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

    }
}
