using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float movementSpeed;
    public float speedUpValue;

    private float _startMovementSpeed;
    private Vector2 _startVelocity;

    private Rigidbody2D rb2D;
    void Start()
    {
        InitMove();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Hit the left Racket?
        if (col.CompareTag("PaddleLeft"))
        {
            ChangeDirection(-1, col.transform.position, col.bounds.size.y);
        }

        // Hit the right Racket?
        if (col.CompareTag("PaddleRight")) {
            ChangeDirection(1, col.transform.position, col.bounds.size.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider

        if (col.collider.CompareTag("Wall"))
        {
            AudioManager.Instance.Play("dinding");
        }

        if (col.collider.CompareTag("Brick"))
        {
            ResetMovementSpeed();
        }

        // Hit the left Racket?
        if (col.collider.CompareTag("PaddleLeft")){
            ChangeDirection(1, col.transform.position, col.collider.bounds.size.y);
            SpeedUp(speedUpValue);
        }

        // Hit the right Racket?
        if (col.collider.CompareTag("PaddleRight")) {
            ChangeDirection(-1, col.transform.position, col.collider.bounds.size.y);
            SpeedUp(speedUpValue);
        }
    }

    private void InitMove()
    {
        rb2D                = GetComponent<Rigidbody2D>();
        rb2D.velocity       = new Vector2(-1, Random.value * 0.5f) * movementSpeed;
        _startMovementSpeed = movementSpeed;
        _startVelocity      = rb2D.velocity;
    }

    private void SpeedUp(float speed)
    {
        movementSpeed += speed;
    }

    private void ResetMovementSpeed()
    {
        movementSpeed = _startMovementSpeed;
        rb2D.velocity = _startVelocity;
    }

    private void ChangeDirection(float x, Vector2 racketPos, float racketHeight)
    {
        AudioManager.Instance.Play("paddle");
        // Calculate hit Factor
        float y = 
            HitFactor(
                transform.position,
                racketPos,
                racketHeight
                );

        // Calculate direction, make length=1 via .normalized
        Vector2 dir = new Vector2(x, y).normalized;

        // Set Velocity with dir * speed
        rb2D.velocity = dir * movementSpeed;
    }

    private float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight) {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }
}
