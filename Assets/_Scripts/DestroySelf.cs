using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
