using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	private ProfileViewManager PVM;
	private GameManager GM;
//	private int _currentLevel;
	private Dinosaur _currentDino;
	private GameObject _levelTransitionScreen;
	private Text _levelTransitionText;
	private int _outcome;
	private static bool _created = false;

	void Awake() {
		if (!_created) {
			DontDestroyOnLoad (this.gameObject);
			_created = true;
			LoadLevel (1);
		} else {
			DestroyImmediate(this.gameObject);
		}
	}

	public void LoadLevel(int level)
	{
		PVM = GameObject.Find ("PVM").GetComponent<ProfileViewManager> (); //EventSystem.current.GetComponent<ProfileViewManager> (); //GameObject.Find ("EventSystem").GetComponent<ProfileViewManager> ();
		GM = GameManager.Instance;

        _levelTransitionScreen = GameObject.Find ("LevelTransition");
		_levelTransitionText = GameObject.Find("LevelTransition/Text").GetComponent<Text>();

        Button noButton = GameObject.Find ("PhoneScreen/NoButton").GetComponent<Button> ();
	    Button yesButton = GameObject.Find("PhoneScreen/YesButton").GetComponent<Button>();
        
        noButton.onClick.AddListener (() => NextProfileHandler ());
        yesButton.onClick.AddListener(() => MatchHandler());

		//display text for beginning of level
		ShowLevelImage ();
		UpdateLevelText (level);
		Invoke ("HideLevelImage", 2f);

		UpdateGameStatusText ();

		//load next dinosaur profile
		GM.DaysGoneBy = level;
		List<Dinosaur> dinosaurList = DinosaursInfo.getDinosaursForLevel(level);
		_currentDino = dinosaurList.FirstOrDefault ();
		PVM.LoadProfileFor(_currentDino);
	}

	private void UpdateGameStatusText()
	{
		var foodText = GameObject.Find("GameStatus/CurrentFood").GetComponent<Text>();
		var daysSurvived = GameObject.Find("GameStatus/DaysSurvived").GetComponent<Text>();
		//var numDates = GameObject.Find("GameStatus/NumDates").GetComponent<Text>();

		foodText.text = "Current Food: " + GM.DaysUntilStarvation.ToString();
		daysSurvived.text = "Days Survived: " + GM.DaysGoneBy.ToString();
		//numDates.text = DinosaursInfo.getDinosaursForLevel.FirstOrDefault(x => x
	}

    public void SetCreated(bool created)
    {
        _created = created;
    }

	private void HideLevelImage()
	{
		_levelTransitionScreen.SetActive (false);
	}

	private void UpdateLevelText(int level)
	{
		_levelTransitionText.text = "Day " + level;
	}

	private void ShowLevelImage()
	{
		_levelTransitionScreen.SetActive (true);
	}

	public void NextProfileHandler()
	{
		var dinosaurPool = DinosaursInfo.getDinosaursForLevel(GM.DaysGoneBy);
	    GM.NewGame = false;
		if (_currentDino.OrderInPool >= dinosaurPool.Count ()) {
			GM.UpdateDaysUntilStarvation (-1);
		} else {
			int nextIndex = _currentDino.OrderInPool + 1;
			Dinosaur nextDino = dinosaurPool.FirstOrDefault (x => x.OrderInPool == nextIndex);
			_currentDino = nextDino;
			PVM.LoadProfileFor (nextDino);
		}
	}

    public void MatchHandler()
    {
        _outcome = GM.CalculateOutcome(_currentDino);
        LoadOutcomeSceneForMatch();
    }

    public void OutcomeScreenHandler()
	{
		if ((GM.DaysUntilStarvation <= 0) || (_outcome == GameManager.GOT_EATEN)) {
			GM.RestartGame ();
		} else {
			SceneManager.LoadScene ("AppView");
		}
	}

	void LoadOutcomeText(int status){
		string outcomeString = OutcomeStrings.getRandomOutcomeText (status);
		Text outcomeText = GameObject.Find("FullCanvas/SummaryText").GetComponent<Text>();
		outcomeText.text = outcomeString;
	}

    public void LoadOutcomeSceneForMatch()
    {
        SceneManager.LoadScene("OutcomeView", LoadSceneMode.Single);

        //calculate outcome
        //load specific scene based on outcome info
    }

    public void LoadOutcomeSceneForEndOfDay()
	{
		var daysTillStarvation = GameManager.Instance.DaysUntilStarvation;
		SceneManager.LoadScene ("OutcomeView", LoadSceneMode.Single);

		//after scene is loaded - populate it with outcome text
		if (daysTillStarvation <= 0) {
			_outcome = GameManager.STARVED;
		} else {
			_outcome = GameManager.NO_MATCH_FOR_DAY;
		}

		//calculate outcome
		//load specific scene based on outcome info
	}

	private void OnLevelWasLoaded(int level) {
		if (level == SceneManager.GetSceneByName ("OutcomeView").buildIndex) {
			LoadOutcomeText (_outcome);
		    LoadStatusText(_outcome);
			Button okButton = GameObject.Find ("FullCanvas/Button").GetComponent<Button> ();
			okButton.onClick.AddListener(() => OutcomeScreenHandler());
		}

		if (level == SceneManager.GetSceneByName ("AppView").buildIndex && !GM.NewGame) {
			LoadLevel ((int)GM.DaysGoneBy + 1);
		}
	}

    private void LoadStatusText(int outcome)
    {
        string statusString = OutcomeStrings.getStatusChangeText(outcome);
        Text statusText = GameObject.Find("FullCanvas/StateChangeText").GetComponent<Text>();
        statusText.text = statusString;
    }
}
