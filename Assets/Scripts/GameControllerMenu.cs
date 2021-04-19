using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerMenu : MonoBehaviour
{
    public void BtnClickNewGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void BtnTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void BtnCredits()
    {
        
    }

    public void BtnExit()
    {
        Application.Quit();
    }
}
