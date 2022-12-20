using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickStatus : MonoBehaviour {
    
    [Header("Status ID")] 
    public BrickManager brickManager;
    public Vector2 index;

    public void UpdateScore()
    {
        brickManager.Score += brickManager.scorePerBrick;
    }

    public void EnqueueBrickDestroyed()
    {
        brickManager.BrickDestroyed.Enqueue(index);
    }
}
