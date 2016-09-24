using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthTextController : MonoBehaviour {

	// TODO: Look to refactor this to be a generic text controller and then used dependency injection to get the right object from the game model to call and get the appropriate value to display

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		PlayerHealth playerHealth = GameObject.Find (PlayerInfo.PLAYER_AVATAR_ID).GetComponent<PlayerHealth> ();
		gameObject.GetComponent<Text> ().text = "Health: " + playerHealth.GetHealthValue ();
	}
}
