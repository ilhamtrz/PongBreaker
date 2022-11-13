using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    [Header("Box Size")] 
    public float xSize = 1;
    public float ySize = 1;

    [Header("Prefab Brick")] 
    public GameObject brick;
    public Vector2 offset;
    
    public Dictionary<Vector2, GameObject> brickDictionary;
    private Dictionary<Vector2, Vector3> _brickPosDictionary;
    
    private bool generate = true;
    public bool Generate
    {
        get { return generate;  }
        set { generate = value; }
    }

    private void Start()
    {
        brickDictionary = new Dictionary<Vector2, GameObject>();
        _brickPosDictionary = new Dictionary<Vector2, Vector3>();
    }

    private void OnDrawGizmos()
    {
        var center = transform.position;
        center.x += xSize / 2;
        center.y += ySize / 2;
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(center, new Vector3(xSize,ySize,1));
    }
    
    public void GenerateBrick()
    {
        BrickManager brickManager = GetComponent<BrickManager>();
        
        Vector3 brickSize = brick.transform.localScale;
        
        Vector3 newPos = Vector3.zero;
        Vector2 index = new Vector2(0,0);
        
        while (newPos.x < xSize)
        {
            newPos.x += brickSize.x / 2;
            
            while (newPos.y < ySize)
            {
                newPos.y += brickSize.y / 2;

                if (newPos.y >  ySize || newPos.x > xSize)
                    break;

                var spawned = Instantiate(brick, transform);
                spawned.transform.position += newPos;
                spawned.name = "Brick " + index.x + ","+ index.y;
                
                spawned.GetComponent<BrickStatus>().brickManager = brickManager;
                spawned.GetComponent<BrickStatus>().index = index;

                if (brickDictionary != null || _brickPosDictionary != null)
                {
                    brickDictionary.Add(index, spawned);
                    _brickPosDictionary.Add(index, spawned.transform.position);
                }

                newPos.y += brickSize.y / 2 + offset.y;
                index.y++;
            }

            newPos.x += brickSize.x / 2 + offset.x;
            newPos.y = 0;
            
            index.x++;
            index.y = 0;
        }
    }
}
