using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DinosaursInfo {

    public static List<Dinosaur> getDinosaursForLevel(int level)
    {
        return _levelToDinosaurs[level];
    }

    public static int GetLevelCount()
    {
        return _levelToDinosaurs.Count;
    }

    private static Dictionary<int, List<Dinosaur>> _levelToDinosaurs = new Dictionary<int, List<Dinosaur>>() {

        {1, new List<Dinosaur>(){
            new Dinosaur()
            {
                Name = "Charles",
                Age = "25",
                BiographyOne = "Love to play chess and snack on babies",
                BiographyTwo = "I have 3 kids!",
                ProfilePictureName = "Static_Assets/Raptor",
                Size = 5,
                OrderInPool = 1
            },
            new Dinosaur()
            {
                Name = "Maurice",
                Age = "30",
                BiographyOne = "Fishing is my thing!",
                BiographyTwo = "Looking for a good time!",
                ProfilePictureName = "Static_Assets/Tbone",
                Size = 2,
                OrderInPool = 2
            },
            new Dinosaur()
            {
                Name = "Lisa",
                Age = "75",
                BiographyOne = "I NEED A MAN IN MY LIFE!",
                BiographyTwo = "WANT ME...PLEASE!",
                ProfilePictureName = "Static_Assets/Spiky",
                Size = 8,
                OrderInPool = 3
            }
        }},
        {2, new List<Dinosaur>(){
            new Dinosaur()
            {
                Name = "Good Guy Willy",
                Age = "3",
                BiographyOne = "I like donating to charities!",
                BiographyTwo = "I love vegetables",
                ProfilePictureName = "Static_Assets/TheGoodDinosaur",
                Size = 5,
                OrderInPool = 1
            },
            new Dinosaur()
            {
				Name = "John the Beast",
                Age = "14",
                BiographyOne = "I like to lift!",
                BiographyTwo = "I'm an alpha saur!",
                ProfilePictureName = "Static_Assets/HumanDressedUp",
                Size = 5,
                OrderInPool = 2
            },
            new Dinosaur()
            {
                Name = "Vanessa",
                Age = "293",
                BiographyOne = "Popcorn and pizza are my favorite things!",
                BiographyTwo = "I put the 'Ass' in 'Jurassic'",
                ProfilePictureName = "Static_Assets/Liposaurus",
                Size = 5,
                OrderInPool = 3
            }
        }},
        {3, new List<Dinosaur>(){
            new Dinosaur()
            {
                Name = "Rebecca",
                Age = "38",
                BiographyOne = "I'm a chicken!",
                BiographyTwo = "Bawk Bawk!!!",
                ProfilePictureName = "Static_Assets/Rebecca",
                Size = 4,
                OrderInPool = 1
            },
            new Dinosaur()
            {
                Name = "Monique",
                Age = "42",
                BiographyOne = "Love to dance",
                BiographyTwo = "Looking for a hot bod!",
                ProfilePictureName = "Static_Assets/Sexy_Woman",
                Size = 7,
                OrderInPool = 2
            },
            new Dinosaur()
            {
                Name = "Lisa",
                Age = "25",
                BiographyOne = "Looking for someone who likes hiking and the outdoors",
                BiographyTwo = "Yoga and my dog are my two loves!",
                ProfilePictureName = "Static_Assets/Lisa",
                Size = 5,
                OrderInPool = 3
            },
        }},
        {4, new List<Dinosaur>(){
            new Dinosaur()
            {
                Name = "41",
                Age = "1 billion",
                BiographyOne = "Likes: Frozen Yogurt, Dancing",
                BiographyTwo = "Looking for someone who wants a good time",
                ProfilePictureName = "Static_Assets/BloodyTRex",
                Size = 5,
                OrderInPool = 1
            },
            new Dinosaur()
            {
                Name = "Billy Bob",
                Age = "956",
                BiographyOne = "I love hanging out with my vegan friends!",
                BiographyTwo = "I like going on long runs!",
                ProfilePictureName = "Static_Assets/BestFriends",
                Size = 5,
                OrderInPool = 2
            },
            new Dinosaur()
            {
                Name = "Dan",
                Age = "37",
                BiographyOne = "I have one son! He's the joy of my life!",
                BiographyTwo = "I'm a lumberjack on the side.",
                ProfilePictureName = "Static_Assets/FatherSon",
                Size = 5,
                OrderInPool = 3
            }
        }},
        {5, new List<Dinosaur>()
        {
            new Dinosaur()
            {
                Name = "Pat",
                Age = "27",
                BiographyOne = "Likes: Frozen Yogurt, Dancing",
                BiographyTwo = "Looking for someone who wants a good time",
                ProfilePictureName = "Static_Assets/barney-love",
                Size = 5,
                OrderInPool = 1
            }
        } }

    };
}
