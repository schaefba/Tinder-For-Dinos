using UnityEngine;
using System.Collections;

public class Restarter : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		GameManager gameManager = GameManager.Instance;

		if (Input.GetKeyDown(KeyCode.R)) {
			gameManager.RestartGame ();
		}
	

	}
}
