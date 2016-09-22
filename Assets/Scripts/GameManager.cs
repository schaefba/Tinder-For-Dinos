﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager {

    // Game change states
    public const int DEFEATED_OTHER = 1;
    public const int NO_MATCH_FOR_DAY = 0;
    public const int GOT_DEFEATED = -1;
    public const int GOT_EATEN = -2;
    public const int STARVED = -3;

    // Initial states
    //public const int INITIAL_DAYS_UNTIL_STARVE = 4;


	//private int _daysUntilStarve = INITIAL_DAYS_UNTIL_STARVE;
//	public int TotalGameDays;
//    public int DaysGoneBy { get; set; }
//	public int NumOfDates { get; set; }
    private int _size = 5;
    public bool NewGame = true;


	//public int DaysUntilStarvation { get { return _daysUntilStarve; } }

	private static GameManager instance;

	// make sure the constructor is private, so it can only be instantiated here
	private GameManager() {
	}

	public static GameManager Instance {
		get {
			if(instance==null) {
				instance = new GameManager();
			}

			return instance;
		}
	}

//	public void UpdateDaysUntilStarvation(int days)
//	{
//		_daysUntilStarve += days;
//		LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
//		levelManager.LoadOutcomeSceneForEndOfDay();
//	}

	public void RestartGame()
	{
	    GameObject levelManager = GameObject.Find("LevelManager");//.gameObject;
	    LevelManager levelManagerScript = levelManager.GetComponent<LevelManager>();
	    levelManagerScript.SetCreated(false);
	    GameObject.DestroyImmediate(levelManager);

	    ResetGameManager();
        SceneManager.LoadScene ("WorldMap", LoadSceneMode.Single);
	}

	public void GameOver() {

		RestartGame ();
	}


    private void ResetGameManager()
    {
//        _daysUntilStarve = INITIAL_DAYS_UNTIL_STARVE;
//        DaysGoneBy = 0;
//		NumOfDates = 0;
        _size = 5;
        NewGame = true;
    }

    public int CalculateOutcome(Dinosaur currentDino)
    {
        if (currentDino.Size > _size)
        {
            return GOT_EATEN;
        }
        if (currentDino.Size < _size)
        {
            return DEFEATED_OTHER;
        }
		return DEFEATED_OTHER;
    }
}
