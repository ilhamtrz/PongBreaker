using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
        
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
    public int score2;

    private void Awake()
    {
        CreateInstance();
    }

    private void Start()
    {
        _brickManager1 = brickManagerObj1.GetComponent<BrickManager>();
        _brickManager2 = brickManagerObj2.GetComponent<BrickManager>();
    }

    private void Update()
    {
        score1 = _brickManager1.Score;
        score2 = _brickManager2.Score;
    }
    
    private void CreateInstance()
    {
        Instance = this;
    }
}
