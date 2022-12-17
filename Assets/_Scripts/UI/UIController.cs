using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credit;
    public GameObject gameMode;
    public GameObject pausedMenu;
    public GameManager gameManager;
    public GameObject gameOver;
    private bool Paused;

void Start()
    {
        Paused = false;
        pausedMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            if(Paused == true)
            {
                pausedMenu.SetActive(false);
                Time.timeScale = 1.0f;
                Paused = false;
            }
            else
            {
                pausedMenu.SetActive(true);
                Time.timeScale = 0f;
                Paused = true;
            }
        }

        if(gameManager.timeMatch <= 0)
        {
            Time.timeScale = 0f;
            gameOver.SetActive(true);
        }
    }

    public void PlayGame()
    {
        gameMode.SetActive(true);
    }
    public void singleMode()
    {
        SceneManager.LoadScene("UjiCoba_Adam");
    }
    public void multiMode()
    {
        SceneManager.LoadScene("UjiCoba_multiplayer");
    }
    public void OpenAuthor()
    {
        Debug.Log(" Sebelumnya Created by Ilham Triza Kurniawan");
    }

    public void OpenCredit()
    {
        mainMenu.SetActive(false);
        credit.SetActive(true);
    }
    public void BackToMenu()
    {
        mainMenu.SetActive(true);
        credit.SetActive(false);
        gameMode.SetActive(false);
    }
    public void OpenPaused()
    {
        pausedMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void BackToGameplay()
    {
        pausedMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
