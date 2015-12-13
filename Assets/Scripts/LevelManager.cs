using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	private ProfileViewManager PVM;
	private GameManager GM;
	private Level _currentLevel;
	private Dinosaur _currentDino;
	private GameObject _levelTransitionScreen;
	private Text _levelTransitionText;
	private int _outcome;

	// make sure the constructor is private, so it can only be instantiated here
	void Awake() {
		DontDestroyOnLoad(gameObject);
		PVM = GameObject.Find ("PhoneScreen/PVM").GetComponent<ProfileViewManager> ();
		GM = GameManager.Instance; 
		_levelTransitionScreen = GameObject.Find ("LevelTransition");
		_levelTransitionText = GameObject.Find("LevelTransition/Text").GetComponent<Text>();


		LoadLevel (Level.One);
	}

	public void LoadLevel(Level level)
	{
		//display text for beginning of level
		ShowLevelImage ();
		UpdateLevelText (level);
		Invoke ("HideLevelImage", 2f);

		//load next dinosaur profile
		_currentLevel = level;
		List<Dinosaur> dinosaurList = LevelToDinosaurs [level];
		_currentDino = dinosaurList.FirstOrDefault ();
		PVM.LoadProfileFor(_currentDino);
	}

	private void HideLevelImage()
	{
		_levelTransitionScreen.SetActive (false);
	}

	private void UpdateLevelText(Level level)
	{
		_levelTransitionText.text = "Day " + (int)level;
	}

	private void ShowLevelImage()
	{
		_levelTransitionScreen.SetActive (true);
	}

	public void LoadNextProfile()
	{
		var dinosaurPool = LevelToDinosaurs [_currentLevel];

		if (_currentDino.OrderInPool >= dinosaurPool.Count ()) {
			GM.UpdateDaysUntilStarvation (-1);
		} else {
			int nextIndex = _currentDino.OrderInPool + 1;
			Dinosaur nextDino = dinosaurPool.FirstOrDefault (x => x.OrderInPool == nextIndex);
			_currentDino = nextDino;
			PVM.LoadProfileFor (nextDino);
		}
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
			LoadLevel (_currentLevel + 1);
		}
	}

	Dictionary<Level, List<Dinosaur>> LevelToDinosaurs = new Dictionary<Level, List<Dinosaur>> () {
		
		{Level.One, new List<Dinosaur>(){
			new Dinosaur()
			{
				Name = "Charles",
				Age = "25",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 5,
				OrderInPool = 1
			},
			new Dinosaur()
			{
				Name = "Maurice",
				Age = "30",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 2,
				OrderInPool = 2
			},
			new Dinosaur()
			{
				Name = "Lisa",
				Age = "75",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 3,
				OrderInPool = 3
			},
			new Dinosaur()
			{
				Name = "Rebecca",
				Age = "28",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 4,
				OrderInPool = 4
			},
			new Dinosaur()
			{
				Name = "Monique",
				Age = "42",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 7,
				OrderInPool = 5
			}
		}},
		{Level.Two, new List<Dinosaur>(){
			new Dinosaur()
			{
				Name = "21",
				Age = "1 billion",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 5,
				OrderInPool = 1
			},
			new Dinosaur()
			{
				Name = "22",
				Age = "1 billion",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 5,
				OrderInPool = 2
			},
			new Dinosaur()
			{
				Name = "23",
				Age = "1 billion",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 5,
				OrderInPool = 3
			},
			new Dinosaur()
			{
				Name = "24",
				Age = "1 billion",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 5,
				OrderInPool = 4
			},
			new Dinosaur()
			{
				Name = "25",
				Age = "1 billion",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 5,
				OrderInPool = 5
			}
		}}
	};

	public enum Level
	{
		One = 1,
		Two = 2,
		Three = 3,
		Four = 4,
		Five = 5
	}
}
