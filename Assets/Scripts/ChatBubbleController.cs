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

    void Awake()
    {
        _chatContent = new List<string>();
        _textObject = gameObject.transform.GetComponentInChildren<Text>();
        _targetedForDestruction = false;
        //_chatBackground = gameObject.transform
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

	    if (_chatContent.Count > 0)
	    {
	        _textObject.text = _chatContent.First();

	        if (Input.GetKey(KeyCode.Return))
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
	        Destroy(gameObject);
	    }
	}

    public void SetChatContent(List<string> chatSequence)
    {
        _chatContent = chatSequence;
    }


}
