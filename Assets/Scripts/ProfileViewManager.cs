using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ProfileViewManager {

	// make sure the constructor is private, so it can only be instantiated here
	private ProfileViewManager() {
	}

	private static ProfileViewManager instance;

	public static ProfileViewManager Instance {
		get {
			if(instance==null) {
				instance = new ProfileViewManager();
			}

			return instance;
		}
	}

	private Text profileName = GameObject.Find("PhoneScreen/Description/Name").GetComponent<Text>();
	private Text age = GameObject.Find("PhoneScreen/Description/Age").GetComponent<Text>();
	private Text biographyOne = GameObject.Find("PhoneScreen/Description/Bio1").GetComponent<Text>();
	private Text biographyTwo = GameObject.Find("PhoneScreen/Description/Bio2").GetComponent<Text>();
	private SpriteRenderer profilePicture = GameObject.Find("PhoneScreen/ProfilePic").GetComponent<SpriteRenderer>();

	public void LoadProfileFor(Dinosaur dino)
	{
		profilePicture.sprite = dino.ProfilePicture.sprite;
		profileName.text = dino.Name;
		age.text = dino.Age;
		biographyOne.text = dino.BiographyOne;
		biographyTwo.text = dino.BiographyTwo;
	}
}