using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [Header("Key Code")]
    public KeyCode key;

    [Header("Paddle control")] 
    public Transform sprite;
    public Transform root;
    public float dashDistance;

    [Header("Movement")] 
    public AnimationCurve forwradCurve;
    public float forwardSpeed;
    
    public AnimationCurve backCurve;
    public float backSpeed;
    public bool collide = false;

    [Header("VFX")] public ParticleSystem trail;
    
    private Vector2 _startPos, _destPos;
    private Vector3 _startScale;
    private bool canDash = true;

    public bool dash = false;

    private void Update()
    {
        _startPos = root.position;
        _destPos = _startPos + (Vector2)transform.right * dashDistance;

        if (Input.GetKeyDown(key) && canDash)
        {
            trail.Play();
            canDash = false;
            StartCoroutine(DashForward());
        }
    }

    IEnumerator DashForward()
    {
        // Check if the position of the cube and sphere are approximately equal.
        while (Vector2.Distance(sprite.position, _destPos) > 0.001f && !collide)
        {
            dash = true;
            // Paddle
            var step = forwardSpeed * Time.deltaTime;
            sprite.position = Vector2.MoveTowards(sprite.position, _destPos, forwradCurve.Evaluate(step));

            yield return null;
        }

        trail.Stop();
        yield return StartCoroutine(DashBack());
    }

    IEnumerator DashBack()
    {
        while (Vector2.Distance(sprite.position, _startPos) > 0.001f)
        {
            dash = false;
            var step = backSpeed * Time.deltaTime;
            sprite.position = Vector2.MoveTowards(sprite.position, _startPos, backCurve.Evaluate(step));

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
