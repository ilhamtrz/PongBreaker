using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    [Header("Box Size")] 
    public float xSize = 1;
    public float ySize = 1;

    [Header("Prefab Brick")] 
    public GameObject brick;
    public Vector2 offset;

    private Vector2 _brickSize;

    private void Start()
    {
        _brickSize = brick.transform.localScale;
        GenerateBrick();
    }

    private void OnDrawGizmos()
    {
        var center = transform.position;
        center.x += xSize / 2;
        center.y += ySize / 2;
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(center, new Vector3(xSize,ySize,1));
    }

    void GenerateBrick()
    {
        Vector3 newPos = Vector3.zero;

        var n = new Vector2(0,0);
        while (newPos.x < xSize)
        {
            newPos.x += _brickSize.x / 2;
            
            while (newPos.y < ySize)
            {
                newPos.y += _brickSize.y / 2;

                if (newPos.y >  ySize || newPos.x > xSize)
                {
                    continue;
                }   
                
                var spawned = Instantiate(brick, transform);
                spawned.transform.position += newPos;
                spawned.name = "Brick " + n.x + ","+ n.y;

                newPos.y += _brickSize.y / 2 + offset.y;
                n.y++;
            }

            newPos.y = 0;
            n.y = 0;
            newPos.x += _brickSize.x / 2 + offset.x;
            n.x++;
        }
    }
}
