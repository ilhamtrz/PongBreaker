using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePU : BasePU
{
    public float timeEffect;
    
    private bool _isActive;
    private float _timeElapsed;
    private bool _disable;
    
    private Paddle _enemy;
    
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
            FireEffect();
        }
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
        
        transform.position = new Vector3(transform.position.x, 12, 0);
        
        Init();
    }
    
    private void Init()
    {
        _isActive    = true;
        _disable     = true;
        _timeElapsed = 0f;
        _enemy.ChangePowerupState(PowerupState.Fire);
    }
    
    private void FireEffect()
    {
        if (_timeElapsed > timeEffect)
        {
            Deactivate();
            return;
        }
        
        if (_enemy.isTerbakar && _disable)
        {
            _enemy.terbakar.Play();
            Invoke("DisableObject", 1f);
            _disable = false;
        }
        
        _timeElapsed += Time.deltaTime;
    }

    private void DisableObject()
    {
        _enemy.gameObject.SetActive(false);
    }
    
    private void Deactivate()
    {
        ResetEffect();
        
        _isActive = false;
        _enemy.ChangePowerupState(PowerupState.Nothing);

        PowerUpHasExpired();
    }
    
    private void ResetEffect()
    {
        _enemy.gameObject.SetActive(true);
        _enemy.paddleControl.isTerbakar = false;
    }
}
