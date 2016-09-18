using UnityEngine;
using System.Collections;

public class MapMovementController : MonoBehaviour {

	//public Zone startZone;
	public Zone currentZone; 

	private Rigidbody2D characterBody;
   
    private GameObject _moveToNode;
	private static bool _created = false;

	void Awake() {
		if (!_created) {
			DontDestroyOnLoad (this.gameObject);
			_created = true;
			//LoadLevel (1);
		} else {
			DestroyImmediate(this.gameObject);
		}
	}

    // Use this for initialization
	void Start () {
		//currentZone = startZone;
		currentZone = GameObject.Find("StartZone").GetComponent<Zone>();
        characterBody = gameObject.GetComponent<Rigidbody2D>();
        Vector3 newCharacterPosition = new Vector3(currentZone.transform.position.x, currentZone.transform.position.y, currentZone.transform.position.z - 1);
        characterBody.transform.position = newCharacterPosition;
	    _moveToNode = currentZone.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

//		if (Input.GetKeyDown(KeyCode.R)) {
//			gameManager.RestartGame ();
//		}

        if (Vector2.Distance(characterBody.transform.position, _moveToNode.transform.position) > .01f)
	    {
	        Vector3 newCharacterPosition = new Vector3(_moveToNode.transform.position.x, _moveToNode.transform.position.y,-1);
	        characterBody.transform.position = Vector3.MoveTowards(characterBody.transform.position, newCharacterPosition,5f*Time.deltaTime);
	        
	    }
	    else
	    {
            currentZone = _moveToNode.GetComponent<Zone>();
	    }
        
	    

	}

	public void EngageNode(GameObject moveToNode)
	{
	    Zone moveToZone = moveToNode.GetComponent<Zone>();

		if (moveToZone == currentZone) { 

			LevelManager levelManager = gameObject.GetComponent<LevelManager> ();
			Debug.Log("Same node");
			levelManager.LoadProfileViewForZone (moveToZone);
			//Debug.Log("Same node");

		} else {

			if (currentZone.neighbors.Contains(moveToZone))
			{
				_moveToNode = moveToNode;
			}
		}

	    
	    
        Debug.Log("Moveeeee");
    }

	public void LoadArea(Zone zoneToLoad) {


	}
}
