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
	private Image profilePicture;

    private static bool _created;

    private const string MATCHVIEW_PATH = "PhoneScreen/MatchView";

	public void Awake()
	{
        if (!_created)
        {
            DontDestroyOnLoad(gameObject);
            _created = true;
            //LoadLevel (1);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
	}
		
	public void LoadProfileFor(Dinosaur dino)
	{
		profileName = GameObject.Find(MATCHVIEW_PATH+"/Description/Name").GetComponent<Text>();
		age = GameObject.Find(MATCHVIEW_PATH+"/Description/Age").GetComponent<Text>();
		biographyOne = GameObject.Find(MATCHVIEW_PATH+"/Description/Bio1").GetComponent<Text>();
		biographyTwo = GameObject.Find(MATCHVIEW_PATH+"/Description/Bio2").GetComponent<Text>();
		profilePicture = GameObject.Find(MATCHVIEW_PATH+"/ProfilePic").GetComponent<Image>();

        profilePicture.sprite = Resources.Load<Sprite>(dino.ProfilePictureName);
        profileName.text = dino.Name;
		age.text = dino.Age + " Years Old";
		biographyOne.text = dino.BiographyOne;
		biographyTwo.text = dino.BiographyTwo;
	}
}