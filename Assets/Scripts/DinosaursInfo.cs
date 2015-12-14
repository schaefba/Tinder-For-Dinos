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
                Age = "36",
                BiographyOne = "Love to play chess.",
                BiographyTwo = "I have 3 kids who I loooooove!",
                ProfilePictureName = "Static_Assets/Stagasaurus",
                Size = 1,
                OrderInPool = 1
            },
            new Dinosaur()
            {
                Name = "John the Beast",
                Age = "16",
                BiographyOne = "I like to lift weights.",
                BiographyTwo = "I'm an alpha saur, rawr!",
                ProfilePictureName = "Static_Assets/HumanDressedUp",
                Size = 1,
                OrderInPool = 2
            },
            new Dinosaur()
            {
                Name = "Agnes",
                Age = "75",
                BiographyOne = "I like to talk slow walks and long naps.",
                BiographyTwo = "Looking for a soft cuddle buddy.",
                ProfilePictureName = "Static_Assets/Spiky",
                Size = 1,
                OrderInPool = 3
            }
        }},
        {2, new List<Dinosaur>(){
            new Dinosaur()
            {
                Name = "Good Guy Willy",
                Age = "24",
                BiographyOne = "I like donating to charities and contributing to my community.",
                BiographyTwo = "I'm always down for a Kale snack.",
                ProfilePictureName = "Static_Assets/TheGoodDinosaur",
                Size = 1,
                OrderInPool = 1
            },
            new Dinosaur()
            {
                Name = "Maurice",
                Age = "30",
                BiographyOne = "Fishing is my thing!",
                BiographyTwo = "Looking for someone to share my feelings.",
                ProfilePictureName = "Static_Assets/Tbone",
                Size = 10,
                OrderInPool = 2
            },
            new Dinosaur()
            {
                Name = "Jenny",
                Age = "25",
                BiographyOne = "Looking for someone who likes hiking and the outdoors",
                BiographyTwo = "My friends have described me as energetic, caring, genuine and funny.",
                ProfilePictureName = "Static_Assets/HikingDino",
                Size = 1,
                OrderInPool = 3
            }

        }},
        {3, new List<Dinosaur>(){
            new Dinosaur()
            {
                Name = "Ralph",
                Age = "38",
                BiographyOne = "I'm a chicken.",
                BiographyTwo = "No really, look at my wings flap!",
                ProfilePictureName = "Static_Assets/Rebecca",
                Size = 10,
                OrderInPool = 1
            },
            new Dinosaur()
            {
                Name = "Natalie",
                Age = "22",
                BiographyOne = "I am a very big and strong dinosaur.",
                BiographyTwo = "Be careful not to get too close, I might bite! Rawr! xoxo",
                ProfilePictureName = "Static_Assets/Sexy_Woman",
                Size = 1,
                OrderInPool = 2
            },
            new Dinosaur()
            {
                Name = "Vanessa",
                Age = "35",
                BiographyOne = "I'd be happy as a clam just to sit down and munch on popcorn and pizza.",
                BiographyTwo = "I put the 'Ass' in Jurassic",
                ProfilePictureName = "Static_Assets/Liposaurus",
                Size = 50,
                OrderInPool = 3
            }
        }},
        {4, new List<Dinosaur>(){
            new Dinosaur()
            {
                Name = "Red Rover",
                Age = "29",
                BiographyOne = "Likes: Frozen Yogurt (especially cherry), Dancing",
                BiographyTwo = "Looking for someone who wants a good time",
                ProfilePictureName = "Static_Assets/BloodyTRex",
                Size = 10,
                OrderInPool = 1
            },
            new Dinosaur()
            {
                Name = "Billy Bob",
                Age = "38",
                BiographyOne = "I love hanging out with my vegan friends!",
                BiographyTwo = "I'm a bit of a runner, would love someone I can chase around.",
                ProfilePictureName = "Static_Assets/BestFriends",
                Size = 10,
                OrderInPool = 2
            },
            new Dinosaur()
            {
                Name = "Earl",
                Age = "37",
                BiographyOne = "I have one son! He's the joy of my life!",
                BiographyTwo = "I'm a lumberjack and love what I do.",
                ProfilePictureName = "Static_Assets/FatherSon",
                Size = 5,
                OrderInPool = 3
            }
        }},
        {5, new List<Dinosaur>()
        {
            new Dinosaur()
            {
                Name = "Barney",
                Age = "27",
                BiographyOne = "I LOVE YOU!",
                BiographyTwo = "YOU LOVE ME!",
                ProfilePictureName = "Static_Assets/barney-love",
                Size = 5,
                OrderInPool = 1
            }
        } }

    };
}
