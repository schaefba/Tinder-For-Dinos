using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ProfileViewManager : MonoBehaviour {

	private Text profileName;
	private Text age;
	private Text biographyOne;
	private Text biographyTwo;
	private SpriteRenderer profilePicture;

	public void Awake()
	{
		profileName = GameObject.Find("PhoneScreen/Description/Name").GetComponent<Text>();
		age = GameObject.Find("PhoneScreen/Description/Age").GetComponent<Text>();
		biographyOne = GameObject.Find("PhoneScreen/Description/Bio1").GetComponent<Text>();
		biographyTwo = GameObject.Find("PhoneScreen/Description/Bio2").GetComponent<Text>();
		profilePicture = GameObject.Find("PhoneScreen/ProfilePic").GetComponent<SpriteRenderer>();
	}
		
	public void LoadProfileFor(Dinosaur dino)
	{
		//profilePicture.sprite = dino.ProfilePicture.sprite;
		profileName.text = dino.Name;
		age.text = dino.Age;
		biographyOne.text = dino.BiographyOne;
		biographyTwo.text = dino.BiographyTwo;
	}
}