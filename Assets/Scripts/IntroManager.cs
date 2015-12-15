using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{

    private static int _currentIntroScene = 0;

    private List<string> sceneList = new List<string>()
    {
        "IntroView",
        "InstructionView",
        "Instruction2View"
    };

	// Use this for initialization
	void Awake () {
        _currentIntroScene = 0;
        DontDestroyOnLoad(gameObject);
	    Button nextButton = GameObject.Find("Canvas/NextButton").GetComponent<Button>();
        nextButton.onClick.AddListener(() => ProceedIntroductionHandlerFirst());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnLevelWasLoaded(int level)
    {
        if (level == SceneManager.GetSceneByName("IntroView").buildIndex || level == SceneManager.GetSceneByName("InstructionView").buildIndex || level == SceneManager.GetSceneByName("Instruction2View").buildIndex)
        {
            GameObject nextButtonGameObject = GameObject.Find("Canvas/NextButton");
            if (nextButtonGameObject != null)
            {
                Button nextButton = nextButtonGameObject.GetComponent<Button>();
                nextButton.onClick.AddListener(() => ProceedIntroductionHandlerFirst());
            }

            GameObject nextButtonTwoGameObject = GameObject.Find("Canvas/NextButtonTwo");
            if (nextButtonTwoGameObject != null)
            {
                Button nextButtonTwo = nextButtonTwoGameObject.GetComponent<Button>();
                nextButtonTwo.onClick.AddListener(() => ProceedIntroductionHandlerSecond());
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

    public void ProceedIntroductionHandlerFirst()
    {
        _currentIntroScene++;
        SceneManager.LoadScene("InstructionView");
        
    }

    public void ProceedIntroductionHandlerSecond()
    {
        _currentIntroScene++;
        SceneManager.LoadScene("Instruction2View");

    }


}
