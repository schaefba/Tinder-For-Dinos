using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MapMovementController : MonoBehaviour
{

    [SerializeField] private float _speed = 1.0f;
    
    //public Zone startZone;
	public Zone currentZone; 

	private Rigidbody2D characterBody;
    
   
    private GameObject _moveToNode;
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
        characterBody = gameObject.GetComponent<Rigidbody2D>();
        Vector3 newCharacterPosition = new Vector3(currentZone.transform.position.x, currentZone.transform.position.y, -1);
        characterBody.transform.position = newCharacterPosition;
	    _moveToNode = currentZone.gameObject;

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
            if (Vector2.Distance(characterBody.transform.position, _moveToNode.transform.position) > .01f)
            {
                Vector2 newCharacterPosition = new Vector2(_moveToNode.transform.position.x, _moveToNode.transform.position.y);
                //characterBody.transform.position = Vector3.MoveTowards(characterBody.transform.position, newCharacterPosition,_speed*Time.deltaTime);
                characterBody.transform.position = Vector2.MoveTowards(characterBody.transform.position, newCharacterPosition, _speed * Time.deltaTime);

            }
            else
            {
                currentZone = _moveToNode.GetComponent<Zone>();
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
			}
		}

	    
	    
        Debug.Log("Moveeeee");
    }

	public void LoadArea(Zone zoneToLoad) {


	}
}
