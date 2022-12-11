using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflect : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        rb.velocity = Vector2.Reflect(rb.velocity, col.transform.right);
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        rb.velocity = Vector2.Reflect(rb.velocity, col.transform.right);
    }
}
