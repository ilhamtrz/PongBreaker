using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    public PaddleControl paddleControl;
    
    [Header("Key Code")]
    public KeyCode keyDash;
    
    [Header("Status")] 
    public int size = 2;
    
    [Header("Movement")]
    public float speed;
    public float dashSpeed;
    public float coolDownDash;

    private void Start()
    {
        Resize(size);
    }

    private void Update()
    {
        SetVariables();
    }
    

    private void SetVariables()
    {
        paddleControl.keyDash      = keyDash;
        paddleControl.speed        = speed;
        paddleControl.dashSpeed    = dashSpeed;
        paddleControl.coolDownDash = coolDownDash;
    }

    private void Resize(int newSize)
    {
        paddleControl.transform.localScale =
            new Vector3(
                1,
                newSize,
                1)
            ;
    }
}
