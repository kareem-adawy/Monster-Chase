using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public GameObject[] characters;


    public static GameManager instance;

    private int _charIndex;
    public int CharIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }

    private void Awake()
    {
        if (instance == null) // this called the Singleton Pattern
                              // Allows to create one copy (instance) of
                              // gameobject (GameManager) in order to
                              //use it in different scenes.
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // to force the GameManager to continue in the next scene

        } else
        {
            Destroy(gameObject); // the instance of GameManager
                                 // so there will be only one copy of the object

        }
    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void Ondisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GamePlay")
        {
            Instantiate(characters[CharIndex]);
        }
    }
}
