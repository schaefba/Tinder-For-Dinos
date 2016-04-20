using Assets.Scripts.BattleScripts.Menus;
using UnityEngine;

[AddComponentMenu("Battle Scripts/Menu Items/Attack")]
public class AttackMenu : Menu {

    private GameObject _mainMenu;
    private GameObject _attackSubMenu;

    // Use this for initialization
    void Start () {
        _mainMenu = GameObject.Find("Base_Menu_Items");
        _attackSubMenu = GameObject.Find("Attack_SubMenu");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OpenAttackSubMenu()
    {
        _mainMenu.SetActive(false);
        _attackSubMenu.SetActive(true);
    }

    public void BasicAttack()
    {
        Debug.Log("Basic Attack!");
    }

    public void SpecialAttack()
    {
        Debug.Log("Special Attack!");
    }

    public void Cancel()
    {
        _mainMenu.SetActive(true);
        _attackSubMenu.SetActive(false);
    }
}
