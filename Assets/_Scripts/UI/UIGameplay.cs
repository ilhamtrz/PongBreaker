using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameplay : MonoBehaviour
{
    public GameObject pausedMenu;
    public GameManager gameManager;
    public ScoreManager scoreManager;
    public GameObject gameOver;
    public GameObject winner1;
    public GameObject winner2;
    public GameObject draw;
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
            gameOver.SetActive(true);
            Time.timeScale = 0f;
            if(scoreManager.score1 > scoreManager.score2){
                winner1.SetActive(true);
            }
            if(scoreManager.score1 < scoreManager.score2){
                winner2.SetActive(true);
            }
        }
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
