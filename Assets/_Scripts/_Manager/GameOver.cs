using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameManager gm;
    public ScoreManager sm;
    public GameObject gameOverPanel;
    public GameObject win1Panel;
    public GameObject win2Panel;
    public GameObject drawPanel;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    private void Update()
    {
        if(gm.timeMatch <= 0)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
            if (sm.score1 > sm.score2)
            {
                win1Panel.SetActive(true);
            }
            if (sm.score1 < sm.score2)
            {
                win2Panel.SetActive(true);
            }
            if (sm.score1 == sm.score2)
            {
                drawPanel.SetActive(true);
            }
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
