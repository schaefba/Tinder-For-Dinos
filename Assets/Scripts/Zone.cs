using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Zone : MonoBehaviour {

	public List<Zone> neighbors;
	private Button _button;
	private MapMovementController _mapController;

	// Use this for initialization
	void Start () {

		_mapController = GameObject.Find (PlayerInfo.PLAYER_AVATAR_ID).GetComponent<MapMovementController> ();

		_button = gameObject.GetComponent<Button> ();
		_button.onClick.AddListener (() => _mapController.EngageNode (gameObject));
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
