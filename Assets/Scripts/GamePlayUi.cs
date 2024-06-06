using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GamePlayUi : MonoBehaviour
{

    public void RestartGame()
    {
        //SceneManager.LoadScene("GamePLay");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }  

    public void HomeButton()
    {
        SceneManager.LoadScene("Menu");
    }
  
}
