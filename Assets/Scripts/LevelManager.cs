using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	Dictionary<int, List<Dinosaur>> LevelToDinosaurs = new Dictionary<int, List<Dinosaur>> () {
		
		{Level.One, new List<Dinosaur>(){
			new Dinosaur()
			{
				Name = "Charles",
				Age = "25",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 5
			},
			new Dinosaur()
			{
				Name = "Maurice",
				Age = "30",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 2
			},
			new Dinosaur()
			{
				Name = "Lisa",
				Age = "75",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 3
			},
			new Dinosaur()
			{
				Name = "Rebecca",
				Age = "28",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 4
			},
			new Dinosaur()
			{
				Name = "Monique",
				Age = "42",
				BiographyOne = "asdf asdf",
				BiographyTwo = "qwer qwer",
				ProfilePicture = new SpriteRenderer(),
				Size = 7
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
