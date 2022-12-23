using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public static UIController Instance;
    public GameObject mainMenu;
    public GameObject credit;
    public GameObject gameMode;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayGame()
    {
        Invoke("SelectMode", 0.1f);
        gameMode.SetActive(true);
    }

    void SelectMode()
    {
        SelectedButtonGlobal.Current.globalUIState = UIState.SelectMode;
    }
    
    public void singleMode()
    {
        SceneManager.LoadScene("Singleplayer");
    }
    
    public void multiMode()
    {
        SceneManager.LoadScene("Multiplayer");
    }
    public void OpenAuthor()
    {
        Debug.Log(" Sebelumnya Created by Ilham Triza Kurniawan");
    }

    public void OpenCredit()
    {
        SelectedButtonGlobal.Current.globalUIState = UIState.Credit;
        mainMenu.SetActive(false);
        credit.SetActive(true);
    }
    public void BackToMenu()
    {
        mainMenu.SetActive(true);
        credit.SetActive(false);
        gameMode.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
}
