using UnityEngine;
using System.Collections;

public class MapMovementController : MonoBehaviour {

	//public Zone startZone;
	public static Zone currentZone; 

	private Rigidbody2D characterBody;

	// Use this for initialization
	void Start () {
		//currentZone = startZone;
		currentZone = GameObject.Find("StartZone").GetComponent<Zone>();
	}
	
	// Update is called once per frame
	void Update () {

//		if (Input.GetKeyDown(KeyCode.R)) {
//			gameManager.RestartGame ();
//		}

		characterBody = gameObject.GetComponent<Rigidbody2D> ();
		characterBody.transform.position = currentZone.gameObject.transform.position;
	}

	public void moveToNode(GameObject moveToNode) {

		characterBody.transform.position = moveToNode.transform.position;
		currentZone = moveToNode.GetComponent<Zone>();
		Debug.Log ("Moveeeee");
	}
}
