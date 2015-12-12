using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LevelManager : MonoBehaviour {

	private ProfileViewManager PVM;
	private Level _currentLevel;
	private Dinosaur _currentDino;
	private GameObject _levelTransitionScreen;
	private Text _levelTransitionText;

	// make sure the constructor is private, so it can only be instantiated here
	void Awake() {
		PVM = ProfileViewManager.Instance;
		_levelTransitionScreen = GameObject.Find ("LevelTransition");
		_levelTransitionText = GameObject.Find("LevelTransition/Text").GetComponent<Text>();
		LoadLevel (Level.One);
	}

	public void LoadLevel(Level level)
	{
		//display text for beginning of level
		ShowLevelImage ();
		UpdateLevelText (level);
		Invoke ("HideLevelImage", 4f);

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
			LoadLevel (_currentLevel + 1);
		} else {
			int nextIndex = _currentDino.OrderInPool + 1;
			Dinosaur nextDino = dinosaurPool.FirstOrDefault (x => x.OrderInPool == nextIndex);
			_currentDino = nextDino;
			PVM.LoadProfileFor (nextDino);
		}
	}

	public void LoadOutcomeScene()
	{
		//calculate outcome
		//load specific scene based on outcome info
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
