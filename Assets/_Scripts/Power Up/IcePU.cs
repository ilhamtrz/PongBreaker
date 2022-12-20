using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePU : BasePU
{
    public float timeEffect;
    
    private float _startSpeed;
    private float _timeElapsed;

    private Paddle _enemy;
    private bool _isActive;
    
    public override bool IsActive()
    {
        return _isActive;
    }

    protected override void Start()
    {
        base.Start();
        _enemy    = manager.enemyPaddle;
        _isActive = false;
    }
    
    private void Update()
    {
        if (_isActive)
        {
            SlowingSpeed();
        }
    }

    private void Init()
    {
        _startSpeed  = _enemy.speed * 0.5f;
        _isActive    = true;
        _timeElapsed = 0f;
        
        _enemy.ChangePowerupState(PowerupState.Ice);
        _enemy.Resize(2);
    }

    protected override void PowerUpPayload()
    {
        base.PowerUpPayload();
        
        if (_enemy.powerupState != PowerupState.Nothing)
        {
            PowerUpHasExpired();
            return;
        }

        Debug.Log ("Musuh terkena effect" + gameObject.name);
        
        spriteRenderer.enabled = false;
        Invoke("MoveUp", 1f);
        
        Init();
    }

    private void MoveUp()
    {
        transform.position = new Vector3(transform.position.x, 12, 0);
        spriteRenderer.enabled = true;
    }

    private void SlowingSpeed()
    {
        if (_timeElapsed > timeEffect)
        {
            Deactivate();
            return;
        }
        
        _enemy.speed = Mathf.Lerp(_startSpeed, 0, _timeElapsed/timeEffect);
        // enemy.speed = 10;
        _timeElapsed += Time.deltaTime;
    }

    private void Deactivate()
    {
        _isActive = false;
        _enemy.ChangePowerupState(PowerupState.Nothing);
        ResetEffect();
        
        PowerUpHasExpired();
    }

    private void ResetEffect()
    {
        _enemy.speed = _startSpeed;
        _enemy.Resize(3);
    }
}
