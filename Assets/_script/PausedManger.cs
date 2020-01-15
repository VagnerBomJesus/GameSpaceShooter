using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PausedManger : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenuUI;

    [SerializeField] private bool emPause;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            emPause = !emPause;
          
        }
        if (emPause) {
            AtivarMenu();
        }
        else {
            DesativarMenu();
        }
    }
    void AtivarMenu() {
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
    }
    public void DesativarMenu() {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
        emPause = false;
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
