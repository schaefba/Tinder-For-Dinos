using System;
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
    private string _currentZoneName;

    private const string NO_BUTTON_PATH = "PhoneScreen/MatchView/NoButton";
    private const string YES_BUTTON_PATH = "PhoneScreen/MatchView/YesButton";

	void Awake() {
		if (!_created) {
			DontDestroyOnLoad (this.gameObject);
			_created = true;
			//LoadLevel (1);
		} else {
			DestroyImmediate(this.gameObject);
		}
	}

    public void setCurrentZone(Zone zone)
    {
        _currentZoneName = zone.gameObject.name;
    }

	public void LoadProfileViewForCurrentZone() {

	    if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("AppView"))
	    {
            PVM = GameObject.Find("PVM").GetComponent<ProfileViewManager>(); //EventSystem.current.GetComponent<ProfileViewManager> (); //GameObject.Find ("EventSystem").GetComponent<ProfileViewManager> ();
            //GM = GameManager.Instance;

            _levelTransitionScreen = GameObject.Find("LevelTransition");
            _levelTransitionText = GameObject.Find("LevelTransition/Text").GetComponent<Text>();

            Button noButton = GameObject.Find(NO_BUTTON_PATH).GetComponent<Button>();
            Button yesButton = GameObject.Find(YES_BUTTON_PATH).GetComponent<Button>();

            noButton.onClick.AddListener(() => NextProfileHandler());
            yesButton.onClick.AddListener(() => MatchHandler());

            //display text for beginning of level
            ShowLevelImage();
            UpdateZoneText(_currentZoneName);
            Invoke("HideLevelImage", 2f);

            UpdateGameStatusText();

            //load next dinosaur profile
            //GM.DaysGoneBy = level;
            List<Dinosaur> dinosaurList = new List<Dinosaur>();

            //		if (GM.DaysGoneBy > DinosaursInfo.GetLevelCount())
            //		{
            //			dinosaurList = DinosaursInfo.getDinosaursForLevel(DinosaursInfo.GetLevelCount());
            //		}
            //		else
            //		{
            //			dinosaurList = DinosaursInfo.getDinosaursForLevel(level);
            //		}
            dinosaurList = DinosaursInfo.getDinosaursForZoneName(_currentZoneName);

            _currentDino = dinosaurList.FirstOrDefault();
            PVM.LoadProfileFor(_currentDino);
	    }
		
	}

	public void LoadLevel(int level)
	{
		PVM = GameObject.Find ("PVM").GetComponent<ProfileViewManager> (); //EventSystem.current.GetComponent<ProfileViewManager> (); //GameObject.Find ("EventSystem").GetComponent<ProfileViewManager> ();
		GM = GameManager.Instance;

        _levelTransitionScreen = GameObject.Find ("LevelTransition");
		_levelTransitionText = GameObject.Find("LevelTransition/Text").GetComponent<Text>();

        Button noButton = GameObject.Find (NO_BUTTON_PATH).GetComponent<Button> ();
	    Button yesButton = GameObject.Find(YES_BUTTON_PATH).GetComponent<Button>();
        
        noButton.onClick.AddListener (() => NextProfileHandler ());
        yesButton.onClick.AddListener(() => MatchHandler());

		//display text for beginning of level
		ShowLevelImage ();
		UpdateLevelText (level);
		Invoke ("HideLevelImage", 2f);

		UpdateGameStatusText ();

		//load next dinosaur profile
		GM.DaysGoneBy = level;
	    List<Dinosaur> dinosaurList = new List<Dinosaur>();

        if (GM.DaysGoneBy > DinosaursInfo.GetLevelCount())
	    {
	        dinosaurList = DinosaursInfo.getDinosaursForLevel(DinosaursInfo.GetLevelCount());
	    }
	    else
	    {
            dinosaurList = DinosaursInfo.getDinosaursForLevel(level);
        }
        
		_currentDino = dinosaurList.FirstOrDefault ();
		PVM.LoadProfileFor(_currentDino);
	}

	private void UpdateGameStatusText()
	{
		var foodText = GameObject.Find("GameStatus/CurrentFood").GetComponent<Text>();
		var daysSurvived = GameObject.Find("GameStatus/DaysSurvived").GetComponent<Text>();
		var numDates = GameObject.Find("GameStatus/NumDates").GetComponent<Text>();

		//foodText.text = "Current Food: " + GM.DaysUntilStarvation.ToString();
		//daysSurvived.text = "Days Survived: " + GM.DaysGoneBy.ToString();
		//numDates.text = "Number of Dates: " + GM.NumOfDates.ToString ();
	}

    public void SetCreated(bool created)
    {
        _created = created;
    }

	private void HideLevelImage()
	{
		_levelTransitionScreen.SetActive (false);
	}

	private void UpdateZoneText(string zoneName) {
		_levelTransitionText.text = "Day " + zoneName;
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
	    int levelKey;
        if (GM.DaysGoneBy > DinosaursInfo.GetLevelCount())
        {
            levelKey = DinosaursInfo.GetLevelCount();
        }
	    else
        {
            levelKey = GM.DaysGoneBy;

        }
        var dinosaurPool = DinosaursInfo.getDinosaursForLevel(levelKey);
	    GM.NewGame = false;
		if (_currentDino.OrderInPool >= dinosaurPool.Count ) {
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
        GM.NewGame = false;
        _outcome = GM.CalculateOutcome(_currentDino);
		GM.NumOfDates++;
        if (GM.DaysGoneBy >= DinosaursInfo.GetLevelCount())
        {
            LoadEndingScene();
        }
        else
        {
            LoadOutcomeSceneForMatch();
        }
        
    }

    private void LoadEndingScene()
    {
        SceneManager.LoadScene("FindingLoveView");
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
	}

	private void OnLevelWasLoaded(int level) {
		if (level == SceneManager.GetSceneByName ("OutcomeView").buildIndex) {
			LoadOutcomeText (_outcome);
		    LoadStatusText(_outcome);


			Animator dino1Anim = GameObject.Find ("Dino1").GetComponent<Animator> ();
			Animator dino2Anim = GameObject.Find ("Dino2").GetComponent<Animator> ();
			SpriteRenderer dino1Sprite = GameObject.Find ("Dino1").GetComponent<SpriteRenderer> ();
			SpriteRenderer dino2Sprite = GameObject.Find ("Dino2").GetComponent<SpriteRenderer> ();
			Button okButton = GameObject.Find ("FullCanvas/Button").GetComponent<Button> ();


			dino1Sprite.enabled = true;
			dino2Sprite.enabled = true;

			if (_outcome == GameManager.ATE_OTHER) {
				dino1Anim.SetTrigger ("Attacking");
				dino2Sprite.flipX = true;
			} else if (_outcome == GameManager.GOT_EATEN) {
				dino2Anim.SetTrigger ("Attacking");
				dino1Sprite.flipX = false;
			} else if (_outcome == GameManager.FAILED_DUE_TO_TIE) {
				dino1Sprite.flipX = false;
				dino2Sprite.flipX = true;
			} else if (_outcome == GameManager.STARVED) {
				dino1Sprite.transform.Rotate (Vector3.forward * 90);
				dino1Anim.enabled = false;
				dino2Sprite.enabled = false;
			} else {
				dino1Sprite.enabled = false;
				dino2Sprite.enabled = false;
			}

		    if (_outcome == GameManager.STARVED || _outcome == GameManager.GOT_EATEN)
		    {
		        okButton.GetComponentInChildren<Text>().text = "Restart";
		    }
		    else
		    {
                okButton.GetComponentInChildren<Text>().text = "Ok";
            }
			okButton.onClick.AddListener(() => OutcomeScreenHandler());
		}

		/*if (level == SceneManager.GetSceneByName ("AppView").buildIndex && !GM.NewGame) {
			LoadLevel ((int)GM.DaysGoneBy + 1);
		}*/
	}

    private void LoadStatusText(int outcome)
    {
        string statusString = OutcomeStrings.getStatusChangeText(outcome);
        Text statusText = GameObject.Find("FullCanvas/StateChangeText").GetComponent<Text>();
        statusText.text = statusString;
    }
}
