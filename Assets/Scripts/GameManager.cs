using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager {

	public const int POSITIVE_STATE = 1;
	public const int NEUTRAL_STATE = 0;
	public const int NEGATIVE_STATE = -1;
	public const int INITIAL_DAYS_UNTIL_STARVE = 5;


	public int daysUntilStarve = INITIAL_DAYS_UNTIL_STARVE;
	public int totalGameDays = 0;

	private int daysGoneBy = 0;


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

	void LoadOutcomeText(int status){
		string outcomeString = OutcomeStrings.getRandomOutcomeText (status);
		Text outcomeText = GameObject.Find ("Canvas/SummaryText").GetComponent<Text>();
		outcomeText.text = outcomeString;
	}

	public void RestartGame() {
		SceneManager.LoadScene ("MenuScene", LoadSceneMode.Single);
	}
}
