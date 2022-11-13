using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject powerup;

    private PowerUpSpawner _powerUpSpawner;

    private GameObject oldSpawned;
    private void Start()
    {
        _powerUpSpawner = GetComponent<PowerUpSpawner>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (oldSpawned != null)
                Destroy(oldSpawned);

            oldSpawned = _powerUpSpawner.SpawnPowerup(powerup);
        }
    }
}
