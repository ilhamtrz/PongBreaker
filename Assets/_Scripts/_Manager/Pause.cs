using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pausedMenu;
    private bool Paused;

    void Start()
    {
        Paused = false;
        pausedMenu.SetActive(false);
        Time.timeScale = 1.0f;
        Debug.Log("mulai UI Gameplay");
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (Paused == true)
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

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
