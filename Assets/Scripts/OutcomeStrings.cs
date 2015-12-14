using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OutcomeStrings : MonoBehaviour {

	protected static Dictionary<int, string> statusChanges = new Dictionary<int, string>(){ 
		{GameManager.ATE_OTHER, "+1 day"}, 
		{GameManager.NO_MATCH_FOR_DAY, "-1 day"},
        {GameManager.FAILED_DUE_TO_TIE, "-1 day" },
		{GameManager.GOT_EATEN,"Game over."},
        {GameManager.STARVED, "Game over." }
	};
		
	protected static List<string> ateOtherOutcomeStrings = new List<string> { "Om nom nom, that's a tasty meal.", "Mm mm, delicious dino delight." };

	protected static List<string> sameSizeStrings = new List<string> { "Looks like you were the same size and you couldn't get that one down.", "You were the same size? How surprising." };

	protected static List<string> gotEatenOutcomeStrings = new List<string> { "Bad news - the bigger dinosaur ate you.", "Everything looks smaller on the internet.", "That dinosaur was quite a bit bigger than you. Naturally, he consumed you for a tasty snack." };

	public static string getStatusChangeText(int status){

		return statusChanges[status];
	}

	public static string getRandomOutcomeText(int status){

		switch (status) {
            case GameManager.ATE_OTHER:
				return ateOtherOutcomeStrings [Random.Range (0, ateOtherOutcomeStrings.Count)];
            case GameManager.NO_MATCH_FOR_DAY:
		        return "No more singles in your area.";
            case GameManager.FAILED_DUE_TO_TIE:
                return sameSizeStrings[Random.Range(0, sameSizeStrings.Count)];
            case GameManager.GOT_EATEN:
				return gotEatenOutcomeStrings [Random.Range (0, gotEatenOutcomeStrings.Count)];
            case GameManager.STARVED:
		        return "You've starved and died.";
			default:
				throw new UnityException ("Incorrect status.");
		}
	}

}
