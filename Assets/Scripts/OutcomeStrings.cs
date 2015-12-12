using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OutcomeStrings : MonoBehaviour {

	public const int POSITIVE_STATE = 1;
	public const int NEUTRAL_STATE = 0;
	public const int NEGATIVE_STATE = -1;


	protected Dictionary<int, string> statusChanges = new Dictionary<int, string>(){ 
		{POSITIVE_STATE, "+1 food"}, 
		{NEUTRAL_STATE, "-1 food"}, 
		{NEGATIVE_STATE,"Game over."}
	};
		
	protected static List<string> positiveOutcomeChanges = new List<string> { "Om nom nom, that's a tasty meal.", "Positive 2" };

	protected static List<string> neutralOutcomeChanges = new List<string> { "Looks like you couldn't get that one down.", "You were the same size? How surprising" };

	protected static List<string> negativeOutcomeChanges = new List<string> { "Everything looks smaller on the internet.", "Negative 2" };

	public string getStatusChangeText(int status){

		return statusChanges[status];
	}

	public static string getRandomOutcomeText(int status){

		switch (status) {
			case POSITIVE_STATE:
				return positiveOutcomeChanges [Random.Range (0, positiveOutcomeChanges.Count)];
			case NEUTRAL_STATE:
				return neutralOutcomeChanges[Random.Range(0,neutralOutcomeChanges.Count)];
			case NEGATIVE_STATE:
				return negativeOutcomeChanges [Random.Range (0, negativeOutcomeChanges.Count)];
			default:
				throw new UnityException ("Incorrect status.");
		}
	}

}
