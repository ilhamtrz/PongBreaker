using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credit;
    public GameObject gameMode;

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
        SceneManager.LoadScene("UjiCoba_Dimas");
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

    public void ExitGame()
    {
        Application.Quit();
    }
    
}
