using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour {
    
    [SerializeField]
    private float _playerSpeed;

    private float _minX;
    private float _maxX;
    private float _minY;
    private float _maxY;

    private float _spriteSizeX;
    private float _spriteSizeY;

    // Use this for initialization
	void Start ()
	{
	    Renderer spriteRenderer = gameObject.GetComponent<Renderer>();
	    _spriteSizeX = spriteRenderer.bounds.size.x;
	    _spriteSizeY = spriteRenderer.bounds.size.y;

	    GameObject boundingBox = GameObject.Find("MovementBoundingBox");

	    if (boundingBox != null)
	    {
	        Renderer bbMesh = boundingBox.GetComponent<Renderer>();
	        Bounds bbBounds = bbMesh.bounds;
	        _minY = bbBounds.min.y;
	        _maxY = bbBounds.max.y;
	        _minX = bbBounds.min.x;
	        _maxX = bbBounds.max.x;
	    }
	}

    // Update is called once per frame
	void Update () {

        //transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * _playerSpeed * Time.deltaTime;
        //transform.Translate(Input.GetAxis("Horizontal") * _playerSpeed * Time.deltaTime, Input.GetAxis("Vertical") * _playerSpeed * Time.deltaTime, 0);

        if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, _playerSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -_playerSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
        {
            transform.Translate(-_playerSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
        {
            transform.Translate(_playerSpeed * Time.deltaTime, 0, 0);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _minX+_spriteSizeX/2, _maxX-_spriteSizeX/2), Mathf.Clamp(transform.position.y,  _minY+_spriteSizeY/2, _maxY+_spriteSizeY/4), transform.position.z);
	}
}
