using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StoryEndButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ProceedEnding() {

		SceneManager.LoadScene ("EndStateView", LoadSceneMode.Single);
	}
}
