using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class BrickManager : MonoBehaviour
{

    public int scorePerBrick = 1;
    public Queue<Vector2> BrickDestroyed;

    private int _score;
    public int Score
    {
        get { return _score;}
        set { _score = value; }
    }

    private void Start()
    {
        BrickDestroyed = new Queue<Vector2>();
    }

}
