using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class ChatBubbleController : MonoBehaviour
{

    private List<string> _chatContent;

    private Text _textObject;
    //private Image _chatBackground;
    private bool _targetedForDestruction;

	private IChatable chatter;

    void Awake()
    {
		
        _chatContent = new List<string>();
        
        _targetedForDestruction = false;
        //_chatBackground = gameObject.transform
    }


	// Use this for initialization 
	void Start () {
	    
		transform.SetParent (GameObject.Find ("Canvas").transform, false);
		_textObject = gameObject.transform.GetComponentInChildren<Text>();
		gameObject.SetActive (false);
		gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {

	    if (_chatContent.Count > 0)
	    {
	        _textObject.text = _chatContent.First();

	        if (Input.GetKeyDown(KeyCode.Return))
	        {
	            _chatContent.RemoveAt(0);
	        } 
	    }
	    else
	    {
	        _targetedForDestruction = true;
	    }

	    if (_targetedForDestruction)
	    {
			chatter.finishConversation ();
			Destroy(gameObject);
	    }
	}

	public void SetChatContent(List<string> chatSequence, IChatable chatter)
    {

		this.chatter = chatter;
        _chatContent = chatSequence;
    }


}
