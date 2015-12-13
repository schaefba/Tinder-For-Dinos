using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager {

	public const int POSITIVE_STATE = 1;
	public const int NEUTRAL_STATE = 0;
	public const int NEGATIVE_STATE = -1;
	public const int INITIAL_DAYS_UNTIL_STARVE = 4;


	private int _daysUntilStarve = INITIAL_DAYS_UNTIL_STARVE;
	public int totalGameDays = 0;
	private int daysGoneBy = 0;


	public int DaysUntilStarvation { get { return _daysUntilStarve; } }

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

	public void UpdateDaysUntilStarvation(int days)
	{
		_daysUntilStarve += days;
		LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		levelManager.LoadOutcomeScene();
	}

	public void RestartGame() {
		SceneManager.LoadScene ("OutcomeView", LoadSceneMode.Single);
	}

    public void CalculateOutcome(Dinosaur currentDino)
    {
        
    }
}
