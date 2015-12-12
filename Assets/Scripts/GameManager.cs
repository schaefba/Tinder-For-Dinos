using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public const int POSITIVE_STATE = 1;
	public const int NEUTRAL_STATE = 0;
	public const int NEGATIVE_STATE = -1;

	// Use this for initialization
	void Start () {

		LoadOutcomeText (POSITIVE_STATE);
	}
	
	// Update is called once per frame
	void Update () {


	}

	void LoadOutcomeText(int status){
		string outcomeString = OutcomeStrings.getRandomOutcomeText (status);
		Text outcomeText = GameObject.Find ("Canvas/SummaryText").GetComponent<Text>();
		outcomeText.text = outcomeString;
	}
}
