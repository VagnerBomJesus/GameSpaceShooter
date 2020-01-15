using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    public void NewGameBt(string newGame) {
        SceneManager.LoadScene(newGame);
    }
    public void ExitGameBt() {
        Application.Quit();
    }
    public void ButtonMenu(string newGame)
    {
        SceneManager.LoadScene(newGame);
    }
    public void ButtonNewGame(string newGame)
    {
        SceneManager.LoadScene(newGame);
    }
}
