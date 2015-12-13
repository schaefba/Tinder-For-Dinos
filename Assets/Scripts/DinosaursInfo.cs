using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DinosaursInfo {

    public static List<Dinosaur> getDinosaursForLevel(int level)
    {
        return _levelToDinosaurs[level];
    }

    private static Dictionary<int, List<Dinosaur>> _levelToDinosaurs = new Dictionary<int, List<Dinosaur>>() {

        {1, new List<Dinosaur>(){
            new Dinosaur()
            {
                Name = "Charles",
                Age = "25",
                BiographyOne = "asdf asdf",
                BiographyTwo = "qwer qwer",
                ProfilePictureName = "Static_Assets/Cerasinops",
                Size = 5,
                OrderInPool = 1
            },
            new Dinosaur()
            {
                Name = "Maurice",
                Age = "30",
                BiographyOne = "asdf asdf",
                BiographyTwo = "qwer qwer",
                ProfilePictureName = "Static_Assets/Cerasinops",
                Size = 2,
                OrderInPool = 2
            },
            new Dinosaur()
            {
                Name = "Lisa",
                Age = "75",
                BiographyOne = "asdf asdf",
                BiographyTwo = "qwer qwer",
                ProfilePictureName = "Static_Assets/Cerasinops",
                Size = 3,
                OrderInPool = 3
            }
        }},
        {2, new List<Dinosaur>(){
            new Dinosaur()
            {
                Name = "21",
                Age = "1 billion",
                BiographyOne = "asdf asdf",
                BiographyTwo = "qwer qwer",
                ProfilePictureName = "Static_Assets/Cerasinops",
                Size = 5,
                OrderInPool = 1
            },
            new Dinosaur()
            {
                Name = "22",
                Age = "1 billion",
                BiographyOne = "asdf asdf",
                BiographyTwo = "qwer qwer",
                ProfilePictureName = "Static_Assets/Cerasinops",
                Size = 5,
                OrderInPool = 2
            },
            new Dinosaur()
            {
                Name = "23",
                Age = "1 billion",
                BiographyOne = "asdf asdf",
                BiographyTwo = "qwer qwer",
                ProfilePictureName = "Static_Assets/Cerasinops",
                Size = 5,
                OrderInPool = 3
            }
        }},
        {3, new List<Dinosaur>(){
            new Dinosaur()
            {
                Name = "Rebecca",
                Age = "38",
                BiographyOne = "asdf asdf",
                BiographyTwo = "qwer qwer",
                ProfilePictureName = "Static_Assets/Cerasinops",
                Size = 4,
                OrderInPool = 1
            },
            new Dinosaur()
            {
                Name = "Monique",
                Age = "42",
                BiographyOne = "asdf asdf",
                BiographyTwo = "qwer qwer",
                ProfilePictureName = "Static_Assets/Cerasinops",
                Size = 7,
                OrderInPool = 2
            },
            new Dinosaur()
            {
                Name = "33",
                Age = "1 billion",
                BiographyOne = "asdf asdf",
                BiographyTwo = "qwer qwer",
                ProfilePictureName = "Static_Assets/Cerasinops",
                Size = 5,
                OrderInPool = 3
            },
        }},
        {4, new List<Dinosaur>(){
            new Dinosaur()
            {
                Name = "41",
                Age = "1 billion",
                BiographyOne = "asdf asdf",
                BiographyTwo = "qwer qwer",
                ProfilePictureName = "Static_Assets/Cerasinops",
                Size = 5,
                OrderInPool = 1
            },
            new Dinosaur()
            {
                Name = "42",
                Age = "1 billion",
                BiographyOne = "asdf asdf",
                BiographyTwo = "qwer qwer",
                ProfilePictureName = "Static_Assets/Cerasinops",
                Size = 5,
                OrderInPool = 2
            },
            new Dinosaur()
            {
                Name = "43",
                Age = "1 billion",
                BiographyOne = "asdf asdf",
                BiographyTwo = "qwer qwer",
                ProfilePictureName = "Static_Assets/Cerasinops",
                Size = 5,
                OrderInPool = 3
            }
        }}

    };
}
