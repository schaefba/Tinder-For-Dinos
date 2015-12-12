using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LevelManager : MonoBehaviour {

	private Level _currentLevel;



	public void LoadLevel(Level level)
	{
		//display text for beginning of level
		//select Dinosaur list for level
		//start at index 0 of that pool
		_currentLevel = level;
		List<Dinosaur> dinosaurList = LevelToDinosaurs [level];
		Dinosaur dino = dinosaurList.FirstOrDefault ();
		//ProfileViewManager.LoadProfileFor(dino);
	}

	public void LoadNextProfile(Dinosaur dino)
	{
		int nextIndex = dino.OrderInPool + 1;
		Dinosaur nextDino = LevelToDinosaurs [_currentLevel].FirstOrDefault (x => x.OrderInPool == nextIndex);
		LoadProfileFor (nextDino);
	}

	public void LoadOutcomeScene()
	{
		//calculate outcome
		//load specific scene based on outcome info
	}

	public void LoadProfileFor(Dinosaur dino)
	{
		//load new dino info into profileviewmanager.
	}

	Dictionary<Level, List<Dinosaur>> LevelToDinosaurs = new Dictionary<Level, List<Dinosaur>> () {
		
		{Level.One, new List<Dinosaur>(){
			new Dinosaur()
			{
				Name = "Charles",
				Age = "25",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 5,
				OrderInPool = 1
			},
			new Dinosaur()
			{
				Name = "Maurice",
				Age = "30",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 2,
				OrderInPool = 2
			},
			new Dinosaur()
			{
				Name = "Lisa",
				Age = "75",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 3,
				OrderInPool = 3
			},
			new Dinosaur()
			{
				Name = "Rebecca",
				Age = "28",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 4,
				OrderInPool = 4
			},
			new Dinosaur()
			{
				Name = "Monique",
				Age = "42",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 7,
				OrderInPool = 5
			}
		}},
		{Level.Two, new List<Dinosaur>(){
			new Dinosaur()
			{
				Name = "Jim",
				Age = "1 billion",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 5
			},
			new Dinosaur()
			{
				Name = "Jim",
				Age = "1 billion",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 5
			},
			new Dinosaur()
			{
				Name = "Jim",
				Age = "1 billion",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 5
			},
			new Dinosaur()
			{
				Name = "Jim",
				Age = "1 billion",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 5
			},
			new Dinosaur()
			{
				Name = "Jim",
				Age = "1 billion",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 5
			}
		}}
	};

	public enum Level
	{
		One = 1,
		Two = 2,
		Three = 3,
		Four = 4,
		Five = 5
	}
}
