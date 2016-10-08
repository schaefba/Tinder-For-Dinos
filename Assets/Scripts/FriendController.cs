using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FriendController : MonoBehaviour, IChatable {

	private List<string> initialConversation = new List<string>{
		"Hey - I know the break-up has been hard.", 
		"But you need to get back out there.",
		"Why don't you use Lzrd?", 
		"I've found some nice dinos to date -", 
		"And also to eat. It's the best."
	};

	private GameObject player;

	//private bool isInitialConversation;
	private bool isChatting;

	void Awake () {

		//isInitialConversation = true;
		isChatting = true;
	}

	// Use this for initialization
	void Start () {
	
		GameObject chatBubble = GameObject.Instantiate(Resources.Load("Prefabs/ChatBubble")) as GameObject;

		ChatBubbleController chatController = chatBubble.GetComponent<ChatBubbleController> ();
		chatController.SetChatContent(initialConversation, this);

		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if (!isChatting) {

			if (Vector2.Distance (player.transform.position, gameObject.transform.position) <= 1) {

				if (Input.GetKeyDown (KeyCode.E)) {

					isChatting = true;
					GameObject chatBubble = GameObject.Instantiate(Resources.Load("Prefabs/ChatBubble")) as GameObject;

					ChatBubbleController chatController = chatBubble.GetComponent<ChatBubbleController> ();
					chatController.SetChatContent(GetResponseForState(), this);
				}
			}
		}
	}



	public void finishConversation() {

		isChatting = false;
	}

	private List<string> GetResponseForState() {

		// Implement a more complicated method that takes into consideration the state of the game to then determine what to say
		return new List<string>{"Hey, are you getting out there and m(eat)ing some nice single dinos? **wink** **wink**"};
	}
}
