using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUpSpawner : MonoBehaviour
{
    [Header("Area Spawn")] 
    public Vector2 size;

    private void OnDrawGizmos()
    {
        var center = transform.position;
        var area = new Vector3(size.x, size.y, 1);
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(center, area);
    }

    public GameObject SpawnPowerup(GameObject Powerup)
    {
        var newPos = transform.position;
        var powerupSize = Powerup.transform.localScale;

        newPos.x += Random.value * (size.x - powerupSize.x) - (size.x/2 - powerupSize.x/2);
        newPos.y += Random.value * (size.y - powerupSize.y) - (size.y/2 - powerupSize.y/2);
        
        var spawned = Instantiate(Powerup);
        spawned.transform.position = newPos;

        return spawned;
    }

    
}
