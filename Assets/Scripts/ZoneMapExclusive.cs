using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ZoneMappable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        if (SceneManager.GetActiveScene().name.Contains("Zone"))
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
	}
}
