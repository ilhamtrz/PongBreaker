using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public float speedUp = 0;

    private Rigidbody2D _rb;
    private Vector2 velocityStart;

    private bool resetVelocity = true;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (resetVelocity)
        {
            velocityStart = _rb.velocity;
            resetVelocity = false;
        }
        
        if (col.collider.CompareTag("Paddle"))
        {
            _rb.velocity *= 1 + speedUp;
        }

        if (col.collider.CompareTag("Brick"))
        {
            _rb.velocity = velocityStart;
            resetVelocity = true;
        }
    }
}
