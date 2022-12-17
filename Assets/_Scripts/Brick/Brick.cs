using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public float delayDestroy = 0.1f;
    
    private SpriteRenderer _spriteRenderer;
    private BrickStatus _brickStatus;
    private Sprite _startSprite;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _brickStatus    = GetComponent<BrickStatus>();
        _startSprite    = _spriteRenderer.sprite;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        StartCoroutine(DestroyObject());
    }

    private void Breaking()
    {
        _spriteRenderer.sprite = null;
        AudioManager.Instance.Play("brick");
        
        _brickStatus.UpdateScore(); 
        _brickStatus.EnqueueBrickDestroyed();
    }

    private IEnumerator DestroyObject()
    {
        Breaking();
        
        yield return new WaitForSeconds(delayDestroy);
        Destroy(gameObject);
    }
    
    private IEnumerator DisableObject()
    {
        Breaking();
        
        yield return new WaitForSeconds(delayDestroy);
        gameObject.SetActive(false);
    }
    
    public void EnableObject()
    {
        _spriteRenderer.sprite = _startSprite;
        gameObject.SetActive(true);
    }
}
