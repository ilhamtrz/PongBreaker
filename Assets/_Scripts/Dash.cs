using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [Header("Key Code")]
    public KeyCode key;

    [Header("Paddle control")] 
    public Transform paddle;
    public float dashDistance;

    [Header("Movement")] 
    public AnimationCurve forwradCurve;
    public float forwardSpeed;
    
    public AnimationCurve backCurve;
    public float backSpeed;
    
    private Vector2 _startPos, _destPos;
    private bool canDash = true;
    private bool collide = false;

    private void Update()
    {
        _startPos = paddle.position;
        _destPos = _startPos + (Vector2)transform.right * dashDistance;
        
        if (Input.GetKeyDown(key) && canDash)
        {
            canDash = false;
            StartCoroutine(DashForward());
        }
    }

    IEnumerator DashForward()
    {
        // Check if the position of the cube and sphere are approximately equal.
        while (Vector2.Distance(transform.position, _destPos) > 0.001f && !collide)
        {
            var step = forwardSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, _destPos, forwradCurve.Evaluate(step));
            yield return null;
        }

        yield return StartCoroutine(DashBack());
    }

    IEnumerator DashBack()
    {
        while (Vector2.Distance(transform.position, _startPos) > 0.001f)
        {
            var step = backSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, _startPos, backCurve.Evaluate(step));
            yield return null;
        }

        canDash = true;
        collide = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        collide = true;
    }

    private void OnDrawGizmos()
    {
        _startPos = paddle.position;
        _destPos = _startPos + (Vector2)transform.right * dashDistance;
        Gizmos.DrawSphere(_destPos, 0.1f);
    }
}
