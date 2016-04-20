using UnityEngine;
using System.Collections;
using Assets.Scripts.BattleScripts.Menus;

[AddComponentMenu("Battle Scripts/Menu Items/Converse")]
public class ConverseMenu : Menu {

    private GameObject _mainMenu;
    private GameObject _converseSubMenu;

    // Use this for initialization
    void Start () {
        _mainMenu = GameObject.Find("Base_Menu_Items");
        _converseSubMenu = GameObject.Find("Converse_SubMenu");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OpenConverseSubMenu()
    {
        _mainMenu.SetActive(false);
        _converseSubMenu.SetActive(true);
    }

    public void Flirt()
    {
        Debug.Log("Flirting!");
    }

    public void Persuade()
    {
        Debug.Log("Persuading!");
    }

    public void Cancel()
    {
        _mainMenu.SetActive(true);
        _converseSubMenu.SetActive(false);
    }
}
