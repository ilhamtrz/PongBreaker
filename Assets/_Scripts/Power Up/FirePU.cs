using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePU : MonoBehaviour
{
    public PowerUpManagerNew manager;
    public GameObject paddle1;
    public GameObject paddle2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == paddle1 || collision == paddle2)
        {
            manager.RemovePowerUp(gameObject);
        }
    }
}
