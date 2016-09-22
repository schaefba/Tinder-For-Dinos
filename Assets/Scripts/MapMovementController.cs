using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MapMovementController : MonoBehaviour
{

    [SerializeField] private float _speed = 1.0f;
    
    //public Zone startZone;
	public Zone currentZone; 
	private string _currentZoneName;

	private Rigidbody2D characterBody;
    
   
    private GameObject _moveToNode;
	private string _moveToNodeName;
	private static bool _created = false;
    private LevelManager _levelManager;

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
		_currentZoneName = currentZone.name;
        characterBody = gameObject.GetComponent<Rigidbody2D>();
        Vector3 newCharacterPosition = new Vector3(currentZone.transform.position.x, currentZone.transform.position.y, -1);
        characterBody.transform.position = newCharacterPosition;
	    _moveToNode = currentZone.gameObject;
		_moveToNodeName = _moveToNode.name;

        _levelManager = gameObject.GetComponent<LevelManager>();

        SceneManager.sceneLoaded += delegate { _levelManager.LoadProfileViewForCurrentZone(); };
	}
	
	// Update is called once per frame
	void Update () {

//		if (Input.GetKeyDown(KeyCode.R)) {
//			gameManager.RestartGame ();
//		}
	    if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("WorldMap"))
	    {

			_moveToNode = GetNodeForName (_moveToNodeName);
			currentZone = GetNodeForName (_currentZoneName).GetComponent<Zone>();

            if (Vector2.Distance(characterBody.transform.position, _moveToNode.transform.position) > .01f)
            {
                Vector2 newCharacterPosition = new Vector2(_moveToNode.transform.position.x, _moveToNode.transform.position.y);
                //characterBody.transform.position = Vector3.MoveTowards(characterBody.transform.position, newCharacterPosition,_speed*Time.deltaTime);
                characterBody.transform.position = Vector2.MoveTowards(characterBody.transform.position, newCharacterPosition, _speed * Time.deltaTime);

            }
            else
            {
                currentZone = _moveToNode.GetComponent<Zone>();
				_currentZoneName = currentZone.name;
            }
	    }
        
	}

	public void EngageNode(GameObject moveToNode)
	{
	    Zone moveToZone = moveToNode.GetComponent<Zone>();

		if (moveToZone == currentZone) { 

			
			Debug.Log("Same node");
            _levelManager.setCurrentZone(currentZone);
            SceneManager.LoadScene("AppView");
            
		    //Debug.Log("Same node");

		} else {

			if (currentZone.neighbors.Contains(moveToZone))
			{
				_moveToNode = moveToNode;
				_moveToNodeName = _moveToNode.name;
			}
		}

	    
	    
        Debug.Log("Moveeeee");
    }

	public GameObject GetNodeForName(string nodeName) {

		return GameObject.Find (nodeName);
	}

	public void LoadArea(Zone zoneToLoad) {


	}
}
