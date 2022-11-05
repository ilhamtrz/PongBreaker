using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class BrickManager : MonoBehaviour
{
    public List<Vector2> brickDestroyed;

    private void Start()
    {
        brickDestroyed = new List<Vector2>();
    }

}
