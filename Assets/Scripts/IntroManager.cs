using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{

    private int _currentIntroScene = 0;

    private List<string> sceneList = new List<string>()
    {
        "IntroView",
        "InstructionView"
    };

	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(gameObject);
	    Button nextButton = GameObject.Find("Canvas/NextButton").GetComponent<Button>();
        nextButton.onClick.AddListener(() => ProceedIntroductionHandler());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnLevelWasLoaded(int level)
    {
        if (level == SceneManager.GetSceneByName(sceneList[_currentIntroScene]).buildIndex)
        {
            GameObject nextButtonGameObject = GameObject.Find("Canvas/NextButton");
            if (nextButtonGameObject != null)
            {
                Button nextButton = nextButtonGameObject.GetComponent<Button>();
                nextButton.onClick.AddListener(() => ProceedIntroductionHandler());
            }

            GameObject startGameButtonGameObject = GameObject.Find("Canvas/StartGameButton");
            if (startGameButtonGameObject != null)
            {
                Button startButton = startGameButtonGameObject.GetComponent<Button>();
                startButton.onClick.AddListener(() => StartGameHandler());
            }
        }
    }

    public void StartGameHandler()
    {
        SceneManager.LoadScene("AppView");
        DestroyImmediate(gameObject);
    }

    public void ProceedIntroductionHandler()
    {
        _currentIntroScene++;
        SceneManager.LoadScene(sceneList[_currentIntroScene]);
        
    }

   
}
