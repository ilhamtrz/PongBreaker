using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveDirection : MonoBehaviour
{
    public float speed;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        var direction = (transform.right * -1) + (transform.up * (Random.value - 0.5f));
        _rb.AddForce(direction * speed, ForceMode2D.Impulse);
        
    }

}
