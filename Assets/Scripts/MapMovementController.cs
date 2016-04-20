using UnityEngine;
using System.Collections;

public class MapMovementController : MonoBehaviour {

	//public Zone startZone;
	public Zone currentZone; 

	private Rigidbody2D characterBody;
   
    private GameObject _moveToNode;

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

	public void moveToNode(GameObject moveToNode)
	{
	    Zone moveToZone = moveToNode.GetComponent<Zone>();

	    if (currentZone.neighbors.Contains(moveToZone))
	    {
            _moveToNode = moveToNode;
	    }
	    
        Debug.Log("Moveeeee");
    }
}
