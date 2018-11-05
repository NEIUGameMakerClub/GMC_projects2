using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public BoardManager boardScript;
    private int level = 3;
    public static GameManager instance = null;
    public int playerFoodPoints = 100;
    [HideInInspector] public bool playersTurn = true;

    void Awake() {

        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    public void GameOver()
    {
        boardScript.SetupScene(level);
    }

    void InitGame()
    {
        boardScript.SetupScene(level);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
