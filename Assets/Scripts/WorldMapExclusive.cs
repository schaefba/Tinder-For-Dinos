using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WorldMapExclusive : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (SceneManager.GetActiveScene().name == "WorldMap")
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
	}
}
