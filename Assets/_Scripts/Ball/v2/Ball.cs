using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float movementSpeed;

    private Rigidbody2D rb2D;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(-1, Random.value * 0.5f) * movementSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Hit the left Racket?
        if (col.CompareTag("PaddleLeft")) {
            Debug.Log("test");
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                col.transform.position,
                col.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            rb2D.velocity = dir * movementSpeed;
        }

        // Hit the right Racket?
        if (col.CompareTag("PaddleRight")) {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                col.transform.position,
                col.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * movementSpeed
            rb2D.velocity = dir * movementSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider
        

        // Hit the left Racket?
        if (col.collider.CompareTag("PaddleLeft")) {
            Debug.Log("test");
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                col.transform.position,
                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            rb2D.velocity = dir * movementSpeed;
        }

        // Hit the right Racket?
        if (col.collider.CompareTag("PaddleRight")) {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                col.transform.position,
                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * movementSpeed
            rb2D.velocity = dir * movementSpeed;
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
        float racketHeight) {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }
}
