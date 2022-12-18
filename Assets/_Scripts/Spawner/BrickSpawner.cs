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
    
    private Dictionary<Vector2, GameObject> _brickDictionary;
    private Dictionary<Vector2, Vector3> _brickPosDictionary;

    private BrickManager _brickManager;

    private void Start()
    {
        Init();
        
        ClearBrickOnEditMode();
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

    private void Init()
    {
        _brickManager       = GetComponent<BrickManager>();
        _brickDictionary    = new Dictionary<Vector2, GameObject>();
        _brickPosDictionary = new Dictionary<Vector2, Vector3>();
    }

    public void GenerateBrick()
    {
        Vector3 brickSize = brick.transform.localScale;
        Vector3 newPos    = Vector3.zero;
        Vector2 index     = new Vector2(0,0);
        
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
                
                spawned.GetComponent<BrickStatus>().brickManager = _brickManager;
                spawned.GetComponent<BrickStatus>().index = index;

                _brickDictionary.Add(index, spawned);
                _brickPosDictionary.Add(index, spawned.transform.position);

                newPos.y += brickSize.y / 2 + offset.y;
                index.y++;
            }

            newPos.x += brickSize.x / 2 + offset.x;
            newPos.y = 0;
            
            index.x++;
            index.y = 0;
        }
    }

    public void ReGenerateBrickDestroyed()
    {
        Queue<Vector2> brickDestroyed = _brickManager.BrickDestroyed;
        if (brickDestroyed.Count > 0)
        {
            Vector2 index = brickDestroyed.Peek();
            
            Debug.Log("Regenerate Brick Index: " + index.x + ","+ index.y);

            Vector3 newPos = _brickPosDictionary[index];
            
            var spawned = Instantiate(brick, newPos, Quaternion.identity, transform);
            spawned.name = "Brick " + index.x + ","+ index.y;
                
            spawned.GetComponent<BrickStatus>().brickManager = _brickManager;
            spawned.GetComponent<BrickStatus>().index = index; 

            _brickManager.BrickDestroyed.Dequeue();
        }
    }

    public void ReGenerateBrickDisabled()
    {
        Queue<Vector2> brickDestroyed = _brickManager.BrickDestroyed;
        if (brickDestroyed.Count > 0)
        {
            Vector2 index = brickDestroyed.Peek();
            
            Debug.Log("Regenerate Brick Index: " + index.x + ","+ index.y);

            GameObject oneBrick = _brickDictionary[index];

            oneBrick.GetComponent<Brick>().EnableObject();

            _brickManager.BrickDestroyed.Dequeue();
        }
    }
    
    public void GenerateBrickOnEditMode()
    {
        Vector3 brickSize = brick.transform.localScale;
        Vector3 newPos    = Vector3.zero;
        Vector2 index     = new Vector2(0,0);
        
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

                newPos.y += brickSize.y / 2 + offset.y;
                index.y++;
            }

            newPos.x += brickSize.x / 2 + offset.x;
            newPos.y = 0;
            
            index.x++;
            index.y = 0;
        }
    }

    private void ClearBrickOnEditMode()
    {
        for (int i = transform.childCount; i > 0; i--)
        {
            Destroy(transform.GetChild(i-1).gameObject);
        }
    }
}
