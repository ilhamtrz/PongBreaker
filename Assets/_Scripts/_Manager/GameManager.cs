using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public bool timerOn = true;
    
    public int timeMatch = 99;
    
    public float timeMinus = 1;
    public float lamaMatchMinute;

    private float elapsedTime;

    private void Awake()
    {
        Instance = this;
    }

    private void OnDrawGizmos()
    {
        lamaMatchMinute = timeMatch * timeMinus * 0.01666666666f; // * 1/60
    }

    private void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        if (!timerOn) return;
        if (timeMatch <= 0) return;
            
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= timeMinus)
        {
            timeMatch--;
            elapsedTime = 0;
        }
    }
}
