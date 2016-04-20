using UnityEngine;
using System.Collections;
using Assets.Scripts.BattleScripts.Menus;

[AddComponentMenu("Battle Scripts/Menu Items/UseItem")]
public class UseItemMenu : Menu {

    private GameObject _mainMenu;
    private GameObject _useItemMenu;

	// Use this for initialization
	void Start () {
        _mainMenu = GameObject.Find("Base_Menu_Items");
        _useItemMenu = GameObject.Find("UseItem_SubMenu");
}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OpenItemSubMenu()
    {
        _mainMenu.SetActive(false);
        _useItemMenu.SetActive(true);
    }

    public void LoadInventoryOptions()
    {

    }

    public void Cancel()
    {
        _mainMenu.SetActive(true);
        _useItemMenu.SetActive(false);
    }
}
