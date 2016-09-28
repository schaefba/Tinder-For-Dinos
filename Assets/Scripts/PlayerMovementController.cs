using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour {
    
    [SerializeField]
    private float _playerSpeed;

    // Use this for initialization
	void Start () {
	
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

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -3.65f, 6.723f), Mathf.Clamp(transform.position.y,  -1.0f, 3.5f));
	}
}
