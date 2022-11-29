using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickStatus : MonoBehaviour
{
    [Header("Status ID")] 
    public BrickManager brickManager;
    public Vector2 index;

    private void OnDestroy()
    {
        brickManager.Score += brickManager.scorePerBrick;
        brickManager.brickDestroyed.Enqueue(index);
    }
}
