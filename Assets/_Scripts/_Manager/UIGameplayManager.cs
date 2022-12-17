using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameplayManager : MonoBehaviour
{
    public TextMeshProUGUI timerUI;
    public TextMeshProUGUI scoreUI1;
    public TextMeshProUGUI scoreUI2;

    private GameManager _gameManager;
    private ScoreManager _scoreManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _scoreManager = ScoreManager.Instance;
    }

    private void Update()
    {
        timerUI.text = _gameManager.timeMatch.ToString();

        var score1 = _scoreManager.score1;
        var score2 = _scoreManager.score2;
        scoreUI1.text = (score1 > 9) ? score1.ToString() : "0" + score1;
        scoreUI2.text = (score2 > 9) ? score2.ToString() : "0" + score2;
    }
}       
