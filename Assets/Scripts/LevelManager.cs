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
	private int _currentLevel;
	private Dinosaur _currentDino;
	private GameObject _levelTransitionScreen;
	private Text _levelTransitionText;
	private int _outcome;
	private static bool created = false;

	void Awake() {
		if (!created) {
			DontDestroyOnLoad (this.gameObject);
			created = true;
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
		noButton.onClick.AddListener (() => LoadNextProfile ());


		//display text for beginning of level
		ShowLevelImage ();
		UpdateLevelText (level);
		Invoke ("HideLevelImage", 2f);

		//load next dinosaur profile
		_currentLevel = level;
		List<Dinosaur> dinosaurList = DinosaursInfo.getDinosaursForLevel(level);
		_currentDino = dinosaurList.FirstOrDefault ();
		PVM.LoadProfileFor(_currentDino);
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

	public void LoadNextProfile()
	{
		var dinosaurPool = DinosaursInfo.getDinosaursForLevel(_currentLevel);

		if (_currentDino.OrderInPool >= dinosaurPool.Count ()) {
			GM.UpdateDaysUntilStarvation (-1);
		} else {
			int nextIndex = _currentDino.OrderInPool + 1;
			Dinosaur nextDino = dinosaurPool.FirstOrDefault (x => x.OrderInPool == nextIndex);
			_currentDino = nextDino;
			PVM.LoadProfileFor (nextDino);
		}
	}

    public void LoadMatch()
    {
        GameManager.Instance.CalculateOutcome(_currentDino);
    }

	public void OutcomeScreenHandler()
	{
		if (GM.DaysUntilStarvation <= 0) {
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

	public void LoadOutcomeScene()
	{
		var daysTillStarvation = GameManager.Instance.DaysUntilStarvation;
		SceneManager.LoadScene ("OutcomeView", LoadSceneMode.Single);

		//after scene is loaded - populate it with outcome text
		if (daysTillStarvation <= 0) {
			_outcome = -1;
		} else {
			_outcome = 1;
		}

		//calculate outcome
		//load specific scene based on outcome info
	}

	private void OnLevelWasLoaded(int level) {
		if (level == SceneManager.GetSceneByName ("OutcomeView").buildIndex) {
			LoadOutcomeText (_outcome);
			Button okButton = GameObject.Find ("FullCanvas/Button").GetComponent<Button> ();
			okButton.onClick.AddListener(() => OutcomeScreenHandler());
		}

		if (level == SceneManager.GetSceneByName ("AppView").buildIndex) {
			LoadLevel ((int)_currentLevel + 1);
		}
	}

	
}
