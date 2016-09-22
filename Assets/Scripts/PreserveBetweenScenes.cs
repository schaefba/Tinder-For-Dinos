using UnityEngine;
using System.Collections;

public class PreserveBetweenScenes : MonoBehaviour {

    void Awake()
    {
        GameObject.DontDestroyOnLoad(gameObject);
    }

}
