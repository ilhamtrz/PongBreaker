using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public KeyCode key;

    public float speed, dashDistance;
    public Transform paddle;
    
    private Vector2 _startPos, _destPos;
    public bool canDash;
    public bool collide = false;

    public float proj;

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
            var step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, _destPos, step);
            yield return null;
        }

        yield return StartCoroutine(DashBack());
    }

    IEnumerator DashBack()
    {
        while (Vector2.Distance(transform.position, _startPos) > 0.001f)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, _startPos, step);
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
        
        Vector2 disPadlle = _destPos - _startPos;
        Vector2 disBase = (Vector2)transform.position - _startPos;
        
        proj = Vector2.Dot(disPadlle.normalized, disBase);
    }
}
