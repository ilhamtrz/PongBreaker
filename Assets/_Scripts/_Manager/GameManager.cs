using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public bool timerOn    = true;
    public int timeMatch   = 99;
    public float timeMinus = 1;
    
    [SerializeField] private float lamaMatchMinute;

    private float _elapsedTime;

    private void Awake()
    {
        CreateInstance();
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
            
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= timeMinus)
        {
            timeMatch--;
            _elapsedTime = 0;
        }
    }
    
    private void CreateInstance()
    {
        Instance = this;
    }
}
