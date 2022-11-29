using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public GameObject trailObj;
    private TrailRenderer trail;
    
    public float speedUp = 0;
    public float trailWidthStart = 0.01f;
    public float trailWidthUp = 0.01f;

    private Rigidbody2D _rb;
    private Vector2 velocityStart;

    private bool resetVelocity = true;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        trail = trailObj.GetComponent<TrailRenderer>();
        trail.time = trailWidthStart;
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
            trail.time += trailWidthUp;
        }

        if (col.collider.CompareTag("Brick"))
        {
            _rb.velocity = velocityStart;
            trail.time = trailWidthStart;
            resetVelocity = true;
        }
    }
}
