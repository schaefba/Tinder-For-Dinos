using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FriendController : MonoBehaviour {

	private List<string> initialConversation = new List<string>{"Swagggg", "Testing!"};

	// Use this for initialization
	void Start () {
	
		GameObject chatBubble = GameObject.Instantiate(Resources.Load("Prefabs/ChatBubble")) as GameObject;

		ChatBubbleController chatController = chatBubble.GetComponent<ChatBubbleController> ();
		chatController.SetChatContent(initialConversation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
