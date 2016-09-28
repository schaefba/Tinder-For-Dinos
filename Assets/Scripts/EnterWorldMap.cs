using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class EnterWorldMap : MonoBehaviour {

	[SerializeField]
	List<string> _controlsForTransition = new List<string>();

	[SerializeField]
	private bool verticalEntrance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
		
	void OnTriggerStay2D(Collider2D other) {


		// TODO: Need to test this for down exits and horizontal exits

		if (other.gameObject.name == "Player") {

			if (_controlsForTransition.Count > 0) {

				bool completeOverlap = false;
				bool atEdge = false;

				Renderer playerSpriteRenderer = other.gameObject.GetComponent<Renderer> ();

				Bounds playerSpriteBounds = playerSpriteRenderer.bounds;
				Bounds entryBounds = gameObject.GetComponent<Renderer> ().bounds;
				Bounds boundingBoxBounds = GameObject.Find ("MovementBoundingBox").GetComponent<Renderer> ().bounds;

				if (verticalEntrance) {

					if (playerSpriteBounds.min.x > entryBounds.min.x && playerSpriteBounds.max.x < entryBounds.max.x) {

						completeOverlap = true;
					}

					if (playerSpriteRenderer.transform.position.y <= boundingBoxBounds.min.y + (playerSpriteBounds.size.y/2) ||
						playerSpriteRenderer.transform.position.y >= boundingBoxBounds.max.y - (playerSpriteBounds.size.y/4)) {

						atEdge = true;
					}

					// In this case its entered going up or down and we need to check width overlap, also check for at edge of top and bottom

				} else {

					// In this case its entered going left or right and we need to check height overlap, also check for at left or right edge
				}

				if (!completeOverlap || !atEdge) {

					return;
				}

				// check if at the edge for direction

				foreach (string controlName in _controlsForTransition) {

						if (Input.GetKey (controlName)) {

							SceneManager.LoadScene ("WorldMap");
						}
				}


			}
		}


	}
}
