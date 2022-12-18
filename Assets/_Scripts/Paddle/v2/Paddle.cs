using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [Header("References")]
    public PaddleControl paddleControl;
    public ParticleSystem terbakar;
    
    [Header("Key Code")]
    public KeyCode keyDash;
    
    [Header("Status")] 
    public int size = 2;
    public PowerupState powerupState;
    public bool isTerbakar;
    
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
        paddleControl.powerupState = powerupState;
        
        isTerbakar = paddleControl.isTerbakar;
    }

    public void Resize(int newSize)
    {
        float old = paddleControl.transform.localScale.y;
        StartCoroutine(LinearResize(old, newSize));
    }

    IEnumerator LinearResize(float old, float newSize)
    {
        var timeElapsed = 0f;
        var timeAnimation = 1f;
        var t = 0f;
        while (timeElapsed < timeAnimation)
        {
            t = timeElapsed / timeAnimation;
            paddleControl.transform.localScale =
                new Vector3(
                    paddleControl.transform.localScale.x,
                    Mathf.Lerp(old, newSize, t),
                    1);
            timeElapsed += Time.deltaTime;
            
            yield return null;
        }
        
        paddleControl.transform.localScale =
            new Vector3(
                paddleControl.transform.localScale.x,
                newSize,
                1);
        yield return null;
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
