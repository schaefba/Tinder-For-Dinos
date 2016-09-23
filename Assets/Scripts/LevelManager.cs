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

	private List<Dinosaur> _dinosaurList;

    private const string NO_BUTTON_PATH = "PhoneScreen/MatchView/NoButton";
    private const string YES_BUTTON_PATH = "PhoneScreen/MatchView/YesButton";

	public GameObject player;
	private PlayerInfo _playerInfo;
	private PlayerHealth _playerHealth;

	void Awake() {
		if (!_created) {
			DontDestroyOnLoad (this.gameObject);
			_created = true;
			//LoadLevel (1);
		} else {
			DestroyImmediate(this.gameObject);
		}
	}

	void Start() {

		_playerInfo = player.GetComponent<PlayerInfo> ();
		_playerHealth = player.GetComponent<PlayerHealth> ();
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
            //_dinosaurList = new List<Dinosaur>();

            //		if (GM.DaysGoneBy > DinosaursInfo.GetLevelCount())
            //		{
            //			dinosaurList = DinosaursInfo.getDinosaursForLevel(DinosaursInfo.GetLevelCount());
            //		}
            //		else
            //		{
            //			dinosaurList = DinosaursInfo.getDinosaursForLevel(level);
            //		}
			_dinosaurList = new List<Dinosaur>(DinosaursInfo.getDinosaursForZoneName(_currentZoneName));
            _currentDino = _dinosaurList.FirstOrDefault();

			_dinosaurList.Remove (_currentDino);

            PVM.LoadProfileFor(_currentDino);
	    }
		
	}

//	public void LoadLevel(int level)
//	{
//		PVM = GameObject.Find ("PVM").GetComponent<ProfileViewManager> (); //EventSystem.current.GetComponent<ProfileViewManager> (); //GameObject.Find ("EventSystem").GetComponent<ProfileViewManager> ();
//		GM = GameManager.Instance;
//
//        _levelTransitionScreen = GameObject.Find ("LevelTransition");
//		_levelTransitionText = GameObject.Find("LevelTransition/Text").GetComponent<Text>();
//
//        Button noButton = GameObject.Find (NO_BUTTON_PATH).GetComponent<Button> ();
//	    Button yesButton = GameObject.Find(YES_BUTTON_PATH).GetComponent<Button>();
//        
//        noButton.onClick.AddListener (() => NextProfileHandler ());
//        yesButton.onClick.AddListener(() => MatchHandler());
//
//		//display text for beginning of level
//		ShowLevelImage ();
//		UpdateLevelText (level);
//		Invoke ("HideLevelImage", 2f);
//
//		UpdateGameStatusText ();
//
//		//load next dinosaur profile
//		//GM.DaysGoneBy = level;
//		_dinosaurList = new List<Dinosaur>();
//
////        if (GM.DaysGoneBy > DinosaursInfo.GetLevelCount())
////	    {
////	        dinosaurList = DinosaursInfo.getDinosaursForLevel(DinosaursInfo.GetLevelCount());
////	    }
////	    else
////	    {
////            dinosaurList = DinosaursInfo.getDinosaursForLevel(level);
////        }
//        
//		_currentDino = _dinosaurList.FirstOrDefault ();
//		PVM.LoadProfileFor(_currentDino);
//	}

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

		if (_dinosaurList.Count == 0) {

			// End of level handling
		} else {

			_currentDino = _dinosaurList.FirstOrDefault();
			_dinosaurList.Remove (_currentDino);
			//_currentDino = nextDino;
			PVM.LoadProfileFor (_currentDino);
		}
			
	}

    public void MatchHandler()
    {
		if (_currentDino.Size > _playerInfo.GetSize ()) {

			_playerHealth.DecreaseHealthBy (10);
			_outcome = GameManager.GOT_DEFEATED;
			// lose
		} else {

			_playerHealth.IncreaseHealthBy (10); 
			_outcome = GameManager.DEFEATED_OTHER;
			// win
		}

		LoadOutcomeSceneForMatch ();

//        GM.NewGame = false;
//        _outcome = GM.CalculateOutcome(_currentDino);
//
//
//       	LoadOutcomeSceneForMatch();
        
    }

    private void LoadEndingScene()
    {
        SceneManager.LoadScene("FindingLoveView");
    }

    public void OutcomeScreenHandler()
	{

		SceneManager.LoadScene ("WorldMap");
//		if ((GM.DaysUntilStarvation <= 0) || (_outcome == GameManager.GOT_EATEN)) {
//			GM.RestartGame ();
//		} else {
//			SceneManager.LoadScene ("AppView");
//		}
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
		//var daysTillStarvation = GameManager.Instance.DaysUntilStarvation;
		SceneManager.LoadScene ("OutcomeView", LoadSceneMode.Single);

		//after scene is loaded - populate it with outcome text
//		if (daysTillStarvation <= 0) {
//			_outcome = GameManager.STARVED;
//		} else {
//			_outcome = GameManager.NO_MATCH_FOR_DAY;
//		}
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

			if (_outcome == GameManager.DEFEATED_OTHER) {
				dino1Anim.SetTrigger ("Attacking");
				dino2Sprite.flipX = true;
			} else if (_outcome == GameManager.GOT_EATEN) {
				dino2Anim.SetTrigger ("Attacking");
				dino1Sprite.flipX = false;
//			} else if (_outcome == GameManager.FAILED_DUE_TO_TIE) {
//				dino1Sprite.flipX = false;
//				dino2Sprite.flipX = true;
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
