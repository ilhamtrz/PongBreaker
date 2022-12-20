using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash2 : MonoBehaviour
{
    [Header("Key Code")]
    public KeyCode key;

    [Header("Paddle control")]
    public float dashDistance;

    [Header("Movement")] 
    public AnimationCurve forwradCurve;
    public float forwardSpeed;
    
    public AnimationCurve backCurve;
    public float backSpeed;
    public bool collide = false;

    private Vector2 _startPos, _destPos;
    private Vector3 _startScale;
    private bool canDash = true;

    public bool dash = false;
    private Rigidbody2D rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _startPos = transform.position;
        _destPos = _startPos + (Vector2)transform.right * dashDistance;
    }

    private void Update()
    {
        

        if (Input.GetKeyDown(key) && canDash)
        {
            _startPos = transform.position;
            _destPos = _startPos + (Vector2)transform.right * dashDistance;
            
            canDash = false;
            StartCoroutine(DashForward());
        }
    }

    private void FixedUpdate()
    {
        if (dash)
        {
            rb.AddForce(transform.right * 2f);
        }
    }

    IEnumerator DashForward()
    {
        // Check if the position of the cube and sphere are approximately equal.
        while (Vector2.Distance(transform.position, _destPos) > 0.001f && !collide)
        {
            dash = true;
            // Paddle
            // var step = forwardSpeed * Time.deltaTime;
            // sprite.position = Vector2.MoveTowards(sprite.position, _destPos, forwradCurve.Evaluate(step));

            yield return null;
        }
        yield return StartCoroutine(DashBack());
    }

    IEnumerator DashBack()
    {
        while (Vector2.Distance(_startPos, _destPos) > 0.001f)
        {
            dash = false;
            var step = backSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(_destPos, _startPos, backCurve.Evaluate(step));

            yield return null;
        }

        canDash = true;
        collide = false;
        
    }

    private void OnDrawGizmos()
    {
        _startPos = transform.position;
        _destPos = _startPos + (Vector2)transform.right * dashDistance;
        
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_destPos, 0.1f);
    }
    
}
