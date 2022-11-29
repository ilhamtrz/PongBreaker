using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownBorder : MonoBehaviour
{
    public bool onWall;
    private void OnTriggerEnter2D(Collider2D col)
    {
        onWall = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        onWall = false;
    }
}
