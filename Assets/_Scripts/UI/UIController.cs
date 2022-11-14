using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credit;
    public GameObject pausedMenu;
    public void PlayGame()
    {
        SceneManager.LoadScene("UjiCoba_Adam");
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
    }
        public void OpenPaused()
    {
        pausedMenu.SetActive(true);
    }
    public void BackToGameplay()
    {
        pausedMenu.SetActive(false);
    }
    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
