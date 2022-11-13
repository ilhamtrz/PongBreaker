using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool timerOn = true;
    
    public TextMeshProUGUI timerUI;
    public int timeMatch = 99;
    
    public float timeMinus = 1;
    public float lamaMatchMinute;

    private float elapsedTime;

    private void OnDrawGizmos()
    {
        lamaMatchMinute = timeMatch * timeMinus * 0.01666666666f;
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
        timerUI.text = timeMatch.ToString();
    }
}
