using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Player")]
    //
    public GameObject player1;
    public GameObject player2;

    [Header("BrickManager")]
    //
    public GameObject brickManagerObj1;
    public GameObject brickManagerObj2;

    private BrickManager _brickManager1;
    private BrickManager _brickManager2;

    [Header("Score")]
    //
    public int score1;
    public TextMeshProUGUI scoreUI1;

    [Space(20f)]
    public int score2;
    public TextMeshProUGUI scoreUI2;

    private void Start()
    {
        _brickManager1 = brickManagerObj1.GetComponent<BrickManager>();
        _brickManager2 = brickManagerObj2.GetComponent<BrickManager>();
    }

    private void Update()
    {
        score1 = _brickManager1.Score;
        score2 = _brickManager2.Score;

        scoreUI1.text = (score1 > 9) ? score1.ToString() : "0" + score1;
        scoreUI2.text = (score2 > 9) ? score2.ToString() : "0" + score2;
    }
}
