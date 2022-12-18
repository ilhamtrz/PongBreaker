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
    public PowerupState powerupState;
    
    [Header("Movement")]
    public float speed;
    public float dashSpeed;
    public float coolDownDash;

    private float _startSpeed;
    
    private void Start()
    {
        Init();
    }

    private void Update()
    {
        SetVariables();
    }

    private void Init()
    {
        Resize(size);
        ChangePowerupState(PowerupState.Nothing);
        _startSpeed = speed;
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
                paddleControl.transform.localScale.x,
                newSize,
                1)
            ;
    }

    public void ChangePowerupState(PowerupState value)
    {
        powerupState = value;
    }
}

public enum PowerupState
{
    Nothing,
    Ice,
    Fire
}
