using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	[SerializeField]
	private int _health = 100;

	public void IncreaseHealthBy(int healthInc) {

		_health = Mathf.Min (100, _health + healthInc);
	}

	public void DecreaseHealthBy(int healthDec) {

		_health = Mathf.Max (0, _health - healthDec);
	}
		
	public int GetHealthValue() {
		return _health;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (_health <= 0) {

			GameManager.Instance.GameOver();
			// Send end game signal to appropriate manager
		}
	}
}
