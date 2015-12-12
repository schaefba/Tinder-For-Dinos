using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ProfileViewManager : MonoBehaviour {

	private GameObject profilePicture;
	private GameObject profileName;
	private GameObject age;
	private GameObject biographyOne;
	private GameObject biographyTwo;
	private GameObject size;

	void Start () {
		profileName = GameObject.Find("PhoneScreen/Description/Name");
		age = GameObject.Find("PhoneScreen/Description/Age");
		biographyOne = GameObject.Find("PhoneScreen/Description/Bio1");
		biographyTwo = GameObject.Find("PhoneScreen/Description/Bio2");
		profilePicture = GameObject.Find("PhoneScreen/ProfilePic");
	}

	public void LoadProfileFor(Dinosaur dino)
	{
		profilePicture.GetComponent<SpriteRenderer>().sprite = dino.ProfilePicture.sprite;
		profileName.GetComponent<Text>().text = dino.Name;
		age.GetComponent<Text>().text = dino.Age;
		biographyOne.GetComponent<Text>().text = dino.BiographyOne;
		biographyTwo.GetComponent<Text>().text = dino.BiographyTwo;
	}
}