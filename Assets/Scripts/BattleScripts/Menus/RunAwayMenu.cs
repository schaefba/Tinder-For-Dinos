using UnityEngine;
using System.Collections;
using Assets.Scripts.BattleScripts.Menus;

[AddComponentMenu("Battle Scripts/Menu Items/RunAway")]
public class RunAwayMenu : Menu {

    private GameObject _mainMenu;

    // Use this for initialization
    void Start () {
        _mainMenu = GameObject.Find("Base_Menu_Items");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RunAwayAction()
    {
        Debug.Log("You ran away!");
    }
}
