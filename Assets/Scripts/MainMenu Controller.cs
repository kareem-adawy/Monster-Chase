using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        int selectedCharacter =
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        //Parse() converts to int
        // we could import the EventSystem library but it will be a waste for one command.

        GameManager.instance.CharIndex = selectedCharacter;

        SceneManager.LoadScene("GamePlay");
    }
}
